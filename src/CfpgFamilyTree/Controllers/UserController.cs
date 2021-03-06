using System.Collections.Generic;
using AutoMapper;
using CfpgFamilyTree.Data;
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

        public UserController(IUserRepo repository, IMapper mapper)
        {
            _repository = repository; 
            _mapper = mapper;
        }
        
        [HttpGet]
        public ActionResult <IEnumerable<UserReadDto>> GetAllUsers()
        {
            var users = _repository.GetAllUsers();

            return Ok(_mapper.Map<IEnumerable<UserReadDto>>(users));
        }

        [HttpGet("{id}", Name="GetUserById")]
        public ActionResult <UserReadDto> GetUserById(int id)
        {
            var user = _repository.GetUserById(id);
            if(user != null)
            {
                return Ok(_mapper.Map<UserReadDto>(user));
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