using System.Collections.Generic;
using CfpgFamilyTree.Data;
using CfpgFamilyTree.Models;
using Microsoft.AspNetCore.Mvc;

namespace CfpgFamilyTree.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo _repository;

        public UserController()
        {
            // _repository = _repository; 
        }
        
        [HttpGet]
        public ActionResult <IEnumerable<User>> GetAllUsers()
        {
            var users = _repository.GetAllUsers();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public ActionResult <User> GetUserById(int id)
        {
            var user = _repository.GetUserById(id);

            return Ok(user);
        }
    }
}