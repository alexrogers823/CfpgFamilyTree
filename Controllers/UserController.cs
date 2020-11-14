using System.Collections.Generic;
using CfpgFamilyTree.Data;
using CfpgFamilyTree.Models;
using Microsoft.AspNetCore.Mvc;

namespace CfpgFamilyTree.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly IUserRepo _repository;

        public ActionResult <IEnumerable<User>> GetAllUsers()
        {
            var users = _repository.GetAllUsers();

            return Ok(users);
        }

        public ActionResult <User> GetUserById(int id)
        {
            var user = _repository.GetUserById(id);

            return Ok(user);
        }
    }
}