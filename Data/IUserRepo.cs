using System.Collections.Generic;
using CfpgFamilyTree.Models;

namespace CfpgFamilyTree.Data 
{
    public interface IUserRepo 
    {
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
    }
}