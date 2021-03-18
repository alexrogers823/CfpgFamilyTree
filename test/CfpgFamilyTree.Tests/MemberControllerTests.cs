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
    public class MemberControllerTests : IDisposable
    {
        Mock<IMemberRepo> mockRepo;
        MembersProfile realProfile;
        MapperConfiguration configuation;
        Mapper mapper;

        public MemberControllerTests()
        {
            mockRepo = new Mock<IMemberRepo>();
            realProfile = new MembersProfile();
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
        public void GetAllFamilyMembers_Returns200OK_WhenDBIsEmpty()
        {
            mockRepo.Setup(repo => repo.GetAllFamilyMembers()).Returns(GetFamilyMembers(0));

            var controller = new MemberController(mockRepo.Object, mapper);

            var result = controller.GetAllFamilyMembers();

            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void GetAllFamilyMembers_ReturnsOneItem_WhenDBHasOneResource()
        {
            mockRepo.Setup(repo => repo.GetAllFamilyMembers()).Returns(GetFamilyMembers(1));

            var controller = new MemberController(mockRepo.Object, mapper);

            var result = controller.GetAllFamilyMembers();

            var okResult = result.Result as OkObjectResult;

            var members = okResult.Value as List<MemberReadDto>;

            Assert.Single(members);
        }

        [Fact]
        public void GetAllFamilyMembers_Returns200OK_WhenDBHasOneResource()
        {
            mockRepo.Setup(repo => repo.GetAllFamilyMembers()).Returns(GetFamilyMembers(1));

            var controller = new MemberController(mockRepo.Object, mapper);

            var result = controller.GetAllFamilyMembers();

            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void GetAllFamilyMembers_ReturnsCorrectType_WhenDBHasOneResource()
        {
            mockRepo.Setup(repo => repo.GetAllFamilyMembers()).Returns(GetFamilyMembers(1));

            var controller = new MemberController(mockRepo.Object, mapper);

            var result = controller.GetAllFamilyMembers();

            Assert.IsType<ActionResult<IEnumerable<MemberReadDto>>>(result);
        }

        [Fact]
        public void GetFamilyMemberById_Returns404NotFound_WhenIDDoesNotExist()
        {
            mockRepo.Setup(repo => repo.GetFamilyMemberById(0)).Returns(() => null);

            var controller = new MemberController(mockRepo.Object, mapper);

            var result = controller.GetFamilyMemberById(1);

            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void GetFamilyMemberById_Returns200OK_WhenIDExists()
        {
            mockRepo.Setup(repo =>
                repo.GetFamilyMemberById(1)).Returns(new Member {
                    FirstName = "Jesus",
                    MiddleName = null,
                    LastName = "Christ",
                    PreferredName = "Emmanuel",
                    Suffix = null,
                    ProfilePhotoUrl = "www.kingofkings.com/jesus-christ.jpg",
                    BirthDay = 25,
                    BirthMonth = 12,
                    BirthYear = 0000,
                    DeathDay = 10,
                    DeathMonth = 4,
                    DeathYear = 0033,
                    Birthplace = "Bethlehem, North Africa",
                    Residence = "Bethlehem, North Africa",
                    IsAlive = false,
                    HasSpouse = false,
                    PrimaryParentId = 1,
                    SecondaryParentId = 2,
                    IsActiveUser = false,
                    SpouseId = null,
                    UserId = null
                });

            var controller = new MemberController(mockRepo.Object, mapper);

            var result = controller.GetFamilyMemberById(1);

            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void GetFamilyMemberById_ReturnsCorrectType_WhenIDExists()
        {
            mockRepo.Setup(repo =>
                repo.GetFamilyMemberById(1)).Returns(new Member {
                    FirstName = "Jesus",
                    MiddleName = null,
                    LastName = "Christ",
                    PreferredName = "Emmanuel",
                    Suffix = null,
                    ProfilePhotoUrl = "www.kingofkings.com/jesus-christ.jpg",
                    BirthDay = 25,
                    BirthMonth = 12,
                    BirthYear = 0000,
                    DeathDay = 10,
                    DeathMonth = 4,
                    DeathYear = 0033,
                    Birthplace = "Bethlehem, North Africa",
                    Residence = "Bethlehem, North Africa",
                    IsAlive = false,
                    HasSpouse = false,
                    PrimaryParentId = 1,
                    SecondaryParentId = 2,
                    IsActiveUser = false,
                    SpouseId = null,
                    UserId = null
                });

            var controller = new MemberController(mockRepo.Object, mapper);

            var result = controller.GetFamilyMemberById(1);

            Assert.IsType<ActionResult<MemberReadDto>>(result);
        }

        [Fact]
        public void CreateMember_ReturnsCorrectResourceType_WhenValidObjectSubmitted()
        {
            mockRepo.Setup(repo =>
                repo.GetFamilyMemberById(1)).Returns(new Member {
                    FirstName = "Jesus",
                    MiddleName = null,
                    LastName = "Christ",
                    PreferredName = "Emmanuel",
                    Suffix = null,
                    ProfilePhotoUrl = "www.kingofkings.com/jesus-christ.jpg",
                    BirthDay = 25,
                    BirthMonth = 12,
                    BirthYear = 0000,
                    DeathDay = 10,
                    DeathMonth = 4,
                    DeathYear = 0033,
                    Birthplace = "Bethlehem, North Africa",
                    Residence = "Bethlehem, North Africa",
                    IsAlive = false,
                    HasSpouse = false,
                    PrimaryParentId = 1,
                    SecondaryParentId = 2,
                    IsActiveUser = false,
                    SpouseId = null,
                    UserId = null
                });

            var controller = new MemberController(mockRepo.Object, mapper);

            var result = controller.CreateMember(new MemberCreateDto { });

            Assert.IsType<ActionResult<MemberReadDto>>(result);
        }

        [Fact]
        public void CreateMember_Returns201CreatedAtRoute_WhenValidObjectSubmitted()
        {
            mockRepo.Setup(repo =>
                repo.GetFamilyMemberById(1)).Returns(new Member {
                    FirstName = "Jesus",
                    MiddleName = null,
                    LastName = "Christ",
                    PreferredName = "Emmanuel",
                    Suffix = null,
                    ProfilePhotoUrl = "www.kingofkings.com/jesus-christ.jpg",
                    BirthDay = 25,
                    BirthMonth = 12,
                    BirthYear = 0000,
                    DeathDay = 10,
                    DeathMonth = 4,
                    DeathYear = 0033,
                    Birthplace = "Bethlehem, North Africa",
                    Residence = "Bethlehem, North Africa",
                    IsAlive = false,
                    HasSpouse = false,
                    PrimaryParentId = 1,
                    SecondaryParentId = 2,
                    IsActiveUser = false,
                    SpouseId = null,
                    UserId = null
                });

            var controller = new MemberController(mockRepo.Object, mapper);

            var result = controller.CreateMember(new MemberCreateDto { });

            Assert.IsType<CreatedAtRouteResult>(result.Result);
        }

        [Fact]
        public void UpdateMember_Returns204NoContent_WhenValidObjectSubmitted()
        {
            mockRepo.Setup(repo =>
                repo.GetFamilyMemberById(1)).Returns(new Member {
                    FirstName = "Jesus",
                    MiddleName = null,
                    LastName = "Christ",
                    PreferredName = "Emmanuel",
                    Suffix = null,
                    ProfilePhotoUrl = "www.kingofkings.com/jesus-christ.jpg",
                    BirthDay = 25,
                    BirthMonth = 12,
                    BirthYear = 0000,
                    DeathDay = 10,
                    DeathMonth = 4,
                    DeathYear = 0033,
                    Birthplace = "Bethlehem, North Africa",
                    Residence = "Bethlehem, North Africa",
                    IsAlive = false,
                    HasSpouse = false,
                    PrimaryParentId = 1,
                    SecondaryParentId = 2,
                    IsActiveUser = false,
                    SpouseId = null,
                    UserId = null
                });

            var controller = new MemberController(mockRepo.Object, mapper);

            var result = controller.UpdateMember(1, new MemberUpdateDto { });

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void UpdateMember_Returns404NotFound_WhenIDDoesNotExist()
        {
            mockRepo.Setup(repo => repo.GetFamilyMemberById(0)).Returns(() => null);

            var controller = new MemberController(mockRepo.Object, mapper);

            var result = controller.UpdateMember(0, new MemberUpdateDto { });

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void PartialUpdateMember_Returns404NotFound_WhenIDDoesNotExist()
        {
            mockRepo.Setup(repo => repo.GetFamilyMemberById(0)).Returns(() => null);

            var controller = new MemberController(mockRepo.Object, mapper);

            var result = controller.UpdateMember(0, new JsonPatchDocument<MemberUpdateDto> { });

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void DeleteMember_Returns204NoContent_WhenIDExists()
        {
            mockRepo.Setup(repo =>
                repo.GetFamilyMemberById(1)).Returns(new Member {
                    FirstName = "Jesus",
                    MiddleName = null,
                    LastName = "Christ",
                    PreferredName = "Emmanuel",
                    Suffix = null,
                    ProfilePhotoUrl = "www.kingofkings.com/jesus-christ.jpg",
                    BirthDay = 25,
                    BirthMonth = 12,
                    BirthYear = 0000,
                    DeathDay = 10,
                    DeathMonth = 4,
                    DeathYear = 0033,
                    Birthplace = "Bethlehem, North Africa",
                    Residence = "Bethlehem, North Africa",
                    IsAlive = false,
                    HasSpouse = false,
                    PrimaryParentId = 1,
                    SecondaryParentId = 2,
                    IsActiveUser = false,
                    SpouseId = null,
                    UserId = null
                });

            var controller = new MemberController(mockRepo.Object, mapper);

            var result = controller.DeleteMember(1);

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void DeleteMember_Returns404NotFound_WhenIDDoesNotExist()
        {
            mockRepo.Setup(repo => repo.GetFamilyMemberById(0)).Returns(() => null);

            var controller = new MemberController(mockRepo.Object, mapper);

            var result = controller.DeleteMember(0);

            Assert.IsType<NotFoundResult>(result);
        }

        private List<Member> GetFamilyMembers(int num)
        {
            var members = new List<Member>();
            if (num > 0)
            {
                members.Add(new Member
                {
                    FirstName = "Jesus",
                    MiddleName = null,
                    LastName = "Christ",
                    PreferredName = "Emmanuel",
                    Suffix = null,
                    ProfilePhotoUrl = "www.kingofkings.com/jesus-christ.jpg",
                    BirthDay = 25,
                    BirthMonth = 12,
                    BirthYear = 0000,
                    DeathDay = 10,
                    DeathMonth = 4,
                    DeathYear = 0033,
                    Birthplace = "Bethlehem, North Africa",
                    Residence = "Bethlehem, North Africa",
                    IsAlive = false,
                    HasSpouse = false,
                    PrimaryParentId = 1,
                    SecondaryParentId = 2,
                    IsActiveUser = false,
                    SpouseId = null,
                    UserId = null
                });
            }

            return members;
        }
    }
}