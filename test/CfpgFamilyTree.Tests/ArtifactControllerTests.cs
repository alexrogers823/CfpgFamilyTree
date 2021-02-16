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
    public class ArtifactControllerTests : IDisposable
    {
        Mock<IArtifactRepo> mockRepo;
        ArtifactsProfile realProfile;
        MapperConfiguration configuration;
        Mapper mapper;

        public ArtifactControllerTests()
        {
            mockRepo = new Mock<IArtifactRepo>();
            realProfile = new ArtifactsProfile();
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
        public void GetAllArtifacts_Returns200OK_WhenDBIsEmpty()
        {
            mockRepo.Setup(repo => repo.GetAllArtifacts()).Returns(GetArtifacts(0));

            var controller = new ArtifactController(mockRepo.Object, mapper);

            var result = controller.GetAllArtifacts();

            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void GetAllArtifacts_ReturnsOneResource_WhenDBHasOneResource()
        {
            mockRepo.Setup(repo => repo.GetAllArtifacts()).Returns(GetArtifacts(1));

            var controller = new ArtifactController(mockRepo.Object, mapper);

            var result = controller.GetAllArtifacts();

            var okResult = result.Result as OkObjectResult;

            var artifacts = okResult.Value as List<ArtifactReadDto>;

            Assert.Single(artifacts);
        }

        [Fact]
        public void GetAllArtifacts_Returns200OK_WhenDBHasOneResource()
        {
            mockRepo.Setup(repo => repo.GetAllArtifacts()).Returns(GetArtifacts(1));

            var controller = new ArtifactController(mockRepo.Object, mapper);

            var result = controller.GetAllArtifacts();

            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void GetAllArtifacts_ReturnsCorrectType_WhenDBHasOneResource()
        {
            mockRepo.Setup(repo => repo.GetAllArtifacts()).Returns(GetArtifacts(1));

            var controller = new ArtifactController(mockRepo.Object, mapper);

            var result = controller.GetAllArtifacts();

            Assert.IsType<ActionResult<IEnumerable<ArtifactReadDto>>>(result);
        }

        [Fact]
        public void GetArtifactById_Return404NotFound_WhenIDDoesNotExist()
        {
            mockRepo.Setup(repo => repo.GetArtifactById(0)).Returns(() => null);

            var controller = new ArtifactController(mockRepo.Object, mapper);

            var result = controller.GetArtifactById(1);

            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void GetArtifactById_Returns200OK_WhenIDExists()
        {
            mockRepo.Setup(repo => repo.GetArtifactById(1)).Returns(new Artifact
            {
                Id = 1,
                PhotoUrl = "www.heartofthecards.com/millenium-puzzle",
                Title = "Yugi solves the Millenium Puzzle"
            });

            var controller = new ArtifactController(mockRepo.Object, mapper);

            var result = controller.GetArtifactById(1);

            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void GetArtifactById_ReturnsCorrectType_WhenIDExists()
        {
            mockRepo.Setup(repo => repo.GetArtifactById(1)).Returns(new Artifact
            {
                Id = 1,
                PhotoUrl = "www.heartofthecards.com/millenium-puzzle",
                Title = "Yugi solves the Millenium Puzzle"
            });

            var controller = new ArtifactController(mockRepo.Object, mapper);

            var result = controller.GetArtifactById(1);

            Assert.IsType<ActionResult<ArtifactReadDto>>(result);
        }

        [Fact]
        public void CreateArtifact_ReturnsCorrectResourceType_WhenValidObjectSubmitted()
        {
            mockRepo.Setup(repo => repo.GetArtifactById(1)).Returns(new Artifact
            {
                Id = 1,
                PhotoUrl = "www.heartofthecards.com/millenium-puzzle",
                Title = "Yugi solves the Millenium Puzzle"
            });

            var controller = new ArtifactController(mockRepo.Object, mapper);

            var result = controller.CreateArtifact(new ArtifactCreateDto { });

            Assert.IsType<ActionResult<ArtifactReadDto>>(result);
        }

        [Fact]
        public void CreateArtifact_Returns201Created_WhenValidObjectSubmitted()
        {
            mockRepo.Setup(repo => repo.GetArtifactById(1)).Returns(new Artifact
            {
                Id = 1,
                PhotoUrl = "www.heartofthecards.com/millenium-puzzle",
                Title = "Yugi solves the Millenium Puzzle"
            });

            var controller = new ArtifactController(mockRepo.Object, mapper);

            var result = controller.CreateArtifact(new ArtifactCreateDto { });

            Assert.IsType<CreatedAtRouteResult>(result.Result);    
        }

        [Fact]
        public void UpdateArtifact_Returns204NoContent_WhenValidObjectSubmitted()
        {
            mockRepo.Setup(repo => repo.GetArtifactById(1)).Returns(new Artifact
            {
                Id = 1,
                PhotoUrl = "www.heartofthecards.com/millenium-puzzle",
                Title = "Yugi solves the Millenium Puzzle"
            });

            var controller = new ArtifactController(mockRepo.Object, mapper);

            var result = controller.UpdateArtifact(1, new ArtifactUpdateDto { });

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void UpdateArtifact_Returns404NotFound_WhenIDDoesNotExist()
        {
            mockRepo.Setup(repo => repo.GetArtifactById(0)).Returns(() => null);

            var controller = new ArtifactController(mockRepo.Object, mapper);

            var result = controller.UpdateArtifact(0, new ArtifactUpdateDto { });

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void PartialArtifactUpdate_Returns404NotFound_WhenIDDoesNotExist()
        {
            mockRepo.Setup(repo => repo.GetArtifactById(0)).Returns(() => null);

            var controller = new ArtifactController(mockRepo.Object, mapper);

            var result = controller.UpdateArtifact(0, new JsonPatchDocument<ArtifactUpdateDto> { });

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void DeleteArtifact_Returns204NoContent_WhenIDExists()
        {
            mockRepo.Setup(repo => repo.GetArtifactById(1)).Returns(new Artifact
            {
                Id = 1,
                PhotoUrl = "www.heartofthecards.com/millenium-puzzle",
                Title = "Yugi solves the Millenium Puzzle"
            });

            var controller = new ArtifactController(mockRepo.Object, mapper);

            var result = controller.DeleteArtifact(1);

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void DeleteArtifact_Returns404NotFound_WhenIDDoesNotExist()
        {
            mockRepo.Setup(repo => repo.GetArtifactById(0)).Returns(() => null);

            var controller = new ArtifactController(mockRepo.Object, mapper);

            var result = controller.DeleteArtifact(0);

            Assert.IsType<NotFoundResult>(result);
        }

        private List<Artifact> GetArtifacts(int num)
        {
            var artifacts = new List<Artifact>();
            if (num > 0)
            {
                artifacts.Add(new Artifact
                {
                    Id = 0,
                    PhotoUrl = "www.heartofthecards.com/millenium-puzzle",
                    Title = "Yugi solves the Millenium Puzzle"
                });
            }

            return artifacts;
        }
    }
}