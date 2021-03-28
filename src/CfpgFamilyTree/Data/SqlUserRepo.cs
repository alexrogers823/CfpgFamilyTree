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

        public SqlUserRepo(CfpgContext context)
        {
            _context = context;
        }

        public void CreateUser(User user)
        {
            if(user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            user.Password = _hashPassword(user.Password); // This might work
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

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateUser(User user)
        {
        
        }

        private string _hashPassword(string password)
        {
            byte[] salt = new byte[128 / 8];
            new RNGCryptoServiceProvider().GetBytes(salt);

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8
            ));

            return hashed;
        }

        private bool _authenticateUser(User user)
        {
            throw new NotImplementedException();
        }
  } 
}