using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CfpgFamilyTree.Data;
using CfpgFamilyTree.DataStructures;
using CfpgFamilyTree.Dtos;
using CfpgFamilyTree.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CfpgFamilyTree.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo _repository;
        private readonly IMapper _mapper;
        private readonly CfpgContext _dbContext;

        public UserController(IUserRepo repository, IMapper mapper, CfpgContext dbContext)
        {
            _repository = repository; 
            _mapper = mapper;
            _dbContext = dbContext;
        }
        
        [HttpGet]
        public ActionResult <IEnumerable<UserReadDto>> GetAllUsers()
        {
            var users = _repository.GetAllUsers();

            return Ok(_mapper.Map<IEnumerable<UserReadDto>>(users));
        }

        [HttpGet("{id}", Name="GetUserById")]
        public ActionResult GetUserById(int id)
        {
            var user = _repository.GetUserById(id);
            if(user != null)
            {
                // return Ok(_mapper.Map<UserReadDto>(user));
                var query = from userObj in _dbContext.Users.DefaultIfEmpty()
                    join member in _dbContext.Members on userObj.Id equals member.UserId
                    select new {
                        Id = userObj.Id,
                        FirstName = member.FirstName,
                        MiddleName = member.MiddleName,
                        LastName = member.LastName,
                        PreferredName = member.PreferredName,
                        Email = userObj.Email,
                        Birthplace = member.Birthplace,
                        Residence = member.Residence,
                        CreatedOn = userObj.CreatedOn,
                        LastLoggedIn = userObj.LastLoggedIn
                    };

                return Ok(query);
            }


            return NotFound();
        }

        [HttpPost]
        public ActionResult <UserCreateDto> CreateUser(UserCreateDto userCreateDto)
        {
            var userModel = _mapper.Map<User>(userCreateDto);
            _repository.CreateUser(userModel);
            _repository.SaveChanges();

            var userReadDto = _mapper.Map<UserReadDto>(userModel);
            
            return CreatedAtRoute(nameof(GetUserById), new {Id = userReadDto.Id}, userReadDto);
        }

        [HttpPost("login", Name="LoginUser")]
        public ActionResult LoginUser(UserLoginDto userLoginDto)
        {
            var user = _repository.LoginUser(userLoginDto.Email, userLoginDto.InputPassword);
            _repository.UpdateUser(user); // Last logged in
            _repository.SaveChanges();

            // return Ok(_mapper.Map<UserReadDto>(user));
            UserJoinedInformation combined = _repository.CombineMemberInformation(user);

            return Ok(combined);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateUser(int id, UserUpdateDto userUpdateDto)
        {
            var userModel = _repository.GetUserById(id);
            if (userModel == null)
            {
                return NotFound();
            }

            _mapper.Map(userUpdateDto, userModel);
            _repository.UpdateUser(userModel);
            _repository.SaveChanges();

            return NoContent();
        }


        [HttpPatch("{id}")]
        public ActionResult UpdateUser(int id, JsonPatchDocument<UserUpdateDto> patchDoc)
        {
            var userModel = _repository.GetUserById(id);

            if(userModel == null)
            {
                return NotFound();
            }

            var userPatch = _mapper.Map<UserUpdateDto>(userModel);
            patchDoc.ApplyTo(userPatch, ModelState);
            if(!TryValidateModel(userPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(userPatch, userModel);

            _repository.UpdateUser(userModel);
            _repository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            var userModel = _repository.GetUserById(id);

            if(userModel == null)
            {
                return NotFound();
            }

            _repository.DeleteUser(userModel);
            _repository.SaveChanges();

            return NoContent();

        }
    }
}