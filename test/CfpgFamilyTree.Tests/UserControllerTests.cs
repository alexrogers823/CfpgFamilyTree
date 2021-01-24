using System;
using System.Collections.Generic;
using AutoMapper;
using CfpgFamilyTree.Controllers;
using CfpgFamilyTree.Data;
using CfpgFamilyTree.Dtos;
using CfpgFamilyTree.Models;
using CfpgFamilyTree.Profiles;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace CfpgFamilyTree.Tests
{
    public class UserControllerTests : IDisposable
    {
        Mock<IUserRepo> mockRepo;
        UsersProfile realProfile;
        MapperConfiguration configuation;
        Mapper mapper;

        public UserControllerTests()
        {
            mockRepo = new Mock<IUserRepo>();
            realProfile = new UsersProfile();
            configuation = new MapperConfiguration(cfg => cfg.AddProfile(realProfile));
            mapper = new Mapper(configuation);
        }

        public void Dispose()
        {
            mockRepo = null;
            realProfile = null;
            configuation = null;
            mapper = null;
        }

        [Fact]
        public void GetUsers_Returns200OK_WhenDBIsEmpty()
        {
            mockRepo.Setup(repo => repo.GetAllUsers()).Returns(GetUsers(0));

            var controller = new UserController(mockRepo.Object, mapper);

            var result = controller.GetAllUsers();

            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void GetUsers_ReturnsOneItem_WhenDBHasOneResource()
        {
            mockRepo.Setup(repo => repo.GetAllUsers()).Returns(GetUsers(1));

            var controller = new UserController(mockRepo.Object, mapper);

            var result = controller.GetAllUsers();

            var okResult = result.Result as OkObjectResult;

            var users = okResult.Value as List<UserReadDto>;

            Assert.Single(users);
        }

        [Fact]
        public void GetUsers_Returns200OK_WhenDBHasOneResource()
        {
            mockRepo.Setup(repo => repo.GetAllUsers()).Returns(GetUsers(1));

            var controller = new UserController(mockRepo.Object, mapper);

            var result = controller.GetAllUsers();

            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void GetUsers_ReturnsCorrectType_WhenDBHasOneResource()
        {
            mockRepo.Setup(repo => repo.GetAllUsers()).Returns(GetUsers(1));

            var controller = new UserController(mockRepo.Object, mapper);

            var result = controller.GetAllUsers();

            Assert.IsType<ActionResult<IEnumerable<UserReadDto>>>(result);
        }

        [Fact]
        public void GetUserById_Returns404NotFound_WhenIDDoesNotExist()
        {
            mockRepo.Setup(repo => repo.GetUserById(0)).Returns(() => null);

            var controller = new UserController(mockRepo.Object, mapper);

            var result = controller.GetUserById(1);

            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void GetUserById_Returns200OK_WhenIDExists()
        {
            mockRepo.Setup(repo =>
                repo.GetUserById(1)).Returns(new User {
                    Id = 1,
                    FirstName = "Barack",
                    MiddleName = "Hussein",
                    LastName = "Obama",
                    Email = "blackpresident@gmail.com",
                    Password = "m1chelle"
                });
            
            var controller = new UserController(mockRepo.Object, mapper);

            var result = controller.GetUserById(1);

            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void GetUserById_ReturnsCorrectType_WhenIdExists()
        {
            mockRepo.Setup(repo =>
                repo.GetUserById(1)).Returns(new User {
                    Id = 1,
                    FirstName = "Barack",
                    MiddleName = "Hussein",
                    LastName = "Obama",
                    Email = "blackpresident@gmail.com",
                    Password = "m1chelle"
                });
            
            var controller = new UserController(mockRepo.Object, mapper);

            var result = controller.GetUserById(1);

            Assert.IsType<ActionResult<UserReadDto>>(result);
        }

        [Fact]
        public void CreateUser_ReturnsCorrectResourceType_WhenValidObjectSubmitted()
        {
            mockRepo.Setup(repo =>
                repo.GetUserById(1)).Returns(new User {
                    Id = 1,
                    FirstName = "Barack",
                    MiddleName = "Hussein",
                    LastName = "Obama",
                    Email = "blackpresident@gmail.com",
                    Password = "m1chelle"
                });

            var controller = new UserController(mockRepo.Object, mapper);

            var result = controller.CreateUser(new UserCreateDto { });

            Assert.IsType<ActionResult<UserCreateDto>>(result);
        }

        [Fact]
        public void CreateUser_Returns201Created_WhenValidObjectSubmitted()
        {
            mockRepo.Setup(repo =>
                repo.GetUserById(1)).Returns(new User {
                    Id = 1,
                    FirstName = "Barack",
                    MiddleName = "Hussein",
                    LastName = "Obama",
                    Email = "blackpresident@gmail.com",
                    Password = "m1chelle"
                });

            var controller = new UserController(mockRepo.Object, mapper);

            var result = controller.CreateUser(new UserCreateDto { });

            Assert.IsType<CreatedAtRouteResult>(result.Result);
        }

        [Fact]
        public void UpdateUser_Returns204NoContent_WhenValidObjectSubmitted()
        {
            mockRepo.Setup(repo =>
                repo.GetUserById(1)).Returns(new User {
                    Id = 1,
                    FirstName = "Barack",
                    MiddleName = "Hussein",
                    LastName = "Obama",
                    Email = "blackpresident@gmail.com",
                    Password = "m1chelle"
                });

            var controller = new UserController(mockRepo.Object, mapper);

            var result = controller.UpdateUser(1, new UserUpdateDto { });

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void UpdateUser_Returns404NotFound_WhenIDDoesNotExist()
        {
            mockRepo.Setup(repo => repo.GetUserById(1)).Returns(() => null);

            var controller = new UserController(mockRepo.Object, mapper);

            var result = controller.UpdateUser(0, new UserUpdateDto { });

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void PartialUserUpdate_Returns404NotFound_WhenIDDoesNotExist()
        {
            mockRepo.Setup(repo => repo.GetUserById(0)).Returns(() => null);

            var controller = new UserController(mockRepo.Object, mapper);

            var result = controller.UpdateUser(0, new JsonPatchDocument<UserUpdateDto> { });

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void DeleteUser_Returns204NoContent_WhenIDExists()
        {
            mockRepo.Setup(repo =>
                repo.GetUserById(1)).Returns(new User {
                    Id = 1,
                    FirstName = "Barack",
                    MiddleName = "Hussein",
                    LastName = "Obama",
                    Email = "blackpresident@gmail.com",
                    Password = "m1chelle"
                });

            var controller = new UserController(mockRepo.Object, mapper);

            var result = controller.DeleteUser(1);

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void DeleteUser_Returns404NotFound_WhenIDDoesNotExist()
        {
            mockRepo.Setup(repo => repo.GetUserById(0)).Returns(() => null);

            var controller = new UserController(mockRepo.Object, mapper);

            var result = controller.DeleteUser(0);

            Assert.IsType<NotFoundResult>(result);
        }

        private List<User> GetUsers(int num)
        {
            var users = new List<User>();
            if (num > 0)
            {
                users.Add(new User
                {
                    Id = 0,
                    FirstName = "Barack",
                    MiddleName = "Hussein",
                    LastName = "Obama",
                    Email = "blackpresident@gmail.com",
                    Password = "m1chelle"
                });
            }

            return users;
        }
    }
}