using System.Collections.Generic;
using CfpgFamilyTree.DataStructures;
using CfpgFamilyTree.Models;

namespace CfpgFamilyTree.Data 
{
    public interface IUserRepo 
    {
        bool SaveChanges();
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
        User LoginUser(string email, string inputPassword);
        UserJoinedInformation CombineMemberInformation(User user);
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
    }
}