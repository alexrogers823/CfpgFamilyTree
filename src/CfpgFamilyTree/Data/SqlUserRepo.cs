using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using CfpgFamilyTree.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace CfpgFamilyTree.Data
{
    public class SqlUserRepo : IUserRepo
    {
        private readonly CfpgContext _context;
        private byte[] salt;

        public SqlUserRepo(CfpgContext context)
        {
            _context = context;
            salt = new byte[128 / 8];
        }

        public void CreateUser(User user)
        {
            if(user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            user.Password = _hashPassword(user.Password); // This might work
            user.CreatedOn = DateTime.Now;
            user.LastLoggedIn = DateTime.Now;

            _context.Users.Add(user);
        }

        public void DeleteUser(User user)
        {
            if(user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            _context.Users.Remove(user);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public User GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(p => p.Id == id);
        }

        public User LoginUser(string email, string inputPassword)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email);

            if(user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            if(_authenticateUser(user, inputPassword))
            {
                user.LastLoggedIn = DateTime.Now;
                return user;
            } else {
                throw new MemberAccessException(nameof(user));
            }
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateUser(User user)
        {

        }

        private string _hashPassword(string password)
        {
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
                return Convert.ToBase64String(encData_byte);
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }

        private bool _authenticateUser(User user, string inputPassword)
        {
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            System.Text.Decoder utf8Decode = encoder.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(user.Password);
            int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            string decrypted = new String(decoded_char);

            return decrypted == inputPassword;
        }
    } 
}