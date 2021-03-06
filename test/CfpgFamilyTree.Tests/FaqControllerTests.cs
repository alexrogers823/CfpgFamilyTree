using System;
using System.Collections.Generic;
using AutoMapper;
using CfpgFamilyTree.Controllers;
using CfpgFamilyTree.Data;
using CfpgFamilyTree.Dtos;
using CfpgFamilyTree.Models;
using CfpgFamilyTree.Profiles;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace CfpgFamilyTree.Tests
{
    public class FaqControllerTests : IDisposable
    {
        Mock<IFaqRepo> mockRepo;
        FaqProfile realProfile;
        MapperConfiguration configuration;
        IMapper mapper;

        public FaqControllerTests()
        {
            mockRepo = new Mock<IFaqRepo>();
            realProfile = new FaqProfile();
            configuration = new MapperConfiguration(cfg => cfg.AddProfile(realProfile));
            mapper = new Mapper(configuration);
        }

        public void Dispose()
        {
            mockRepo = null;
            realProfile = null;
            configuration = null;
            mapper = null;
        }

        [Fact]
        public void GetQuestions_Returns200OK_WhenDBIsEmpty()
        {
            mockRepo.Setup(repo => repo.GetAllQuestions()).Returns(GetQuestions(0));

            var controller = new FaqController(mockRepo.Object, mapper);

            var result = controller.GetAllQuestions();

            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void GetQuestions_ReturnsOneItem_WhenDBHasOneResource()
        {
            mockRepo.Setup(repo => repo.GetAllQuestions()).Returns(GetQuestions(1));

            var controller = new FaqController(mockRepo.Object, mapper);

            var result = controller.GetAllQuestions();

            var okResult = result.Result as OkObjectResult;

            var questions = okResult.Value as List<FaqReadDto>;

            Assert.Single(questions);
        }

        [Fact]
        public void GetQuestions_Returns200OK_WhenDBHasOneResource()
        {
            mockRepo.Setup(repo => repo.GetAllQuestions()).Returns(GetQuestions(1));

            var controller = new FaqController(mockRepo.Object, mapper);

            var result = controller.GetAllQuestions();

            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void GetQuestions_ReturnsCorrectType_WhenDBHasOneResource()
        {
            mockRepo.Setup(repo => repo.GetAllQuestions()).Returns(GetQuestions(1));

            var controller = new FaqController(mockRepo.Object, mapper);

            var result = controller.GetAllQuestions();

            Assert.IsType<ActionResult<IEnumerable<FaqReadDto>>>(result);
        }

        private List<Faq> GetQuestions(int num)
        {
            var questions = new List<Faq>();
            if (num > 0)
            {
                questions.Add(new Faq
                {
                    Id = 0,
                    Question = "Who is Constantine's lover?",
                    Answer = "Desmond"
                });
            }

            return questions;
        }
    }
}