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
    public class PhotoControllerTests : IDisposable
    {
        Mock<IPhotoRepo> mockRepo;
        PhotosProfile realProfile;
        MapperConfiguration configuration;
        Mapper mapper;

        public PhotoControllerTests()
        {
            mockRepo = new Mock<IPhotoRepo>();    
            realProfile = new PhotosProfile();
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
        public void GetAllPhotos_Return200OK_WhenDBIsEmpty()
        {
            mockRepo.Setup(repo => repo.GetAllFamilyPhotos()).Returns(GetFamilyPhotos(0));

            var controller = new PhotoController(mockRepo.Object, mapper);

            var result = controller.GetAllFamilyPhotos();

            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void GetAllPhotos_ReturnsOneItem_WhenDBHasOneResource()
        {
            mockRepo.Setup(repo => repo.GetAllFamilyPhotos()).Returns(GetFamilyPhotos(1));

            var controller = new PhotoController(mockRepo.Object, mapper);

            var result = controller.GetAllFamilyPhotos();

            var okResult = result.Result as OkObjectResult;

            var photos = okResult.Value as List<PhotoReadDto>;

            Assert.Single(photos);
        }

        [Fact]
        public void GetAllPhotos_Returns200OK_WhenDBHasOneResource()
        {
            mockRepo.Setup(repo => repo.GetAllFamilyPhotos()).Returns(GetFamilyPhotos(1));

            var controller = new PhotoController(mockRepo.Object, mapper);

            var result = controller.GetAllFamilyPhotos();

            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void GetAllPhotos_ReturnsCorrectType_WhenDBHasOneResource()
        {
            mockRepo.Setup(repo => repo.GetAllFamilyPhotos()).Returns(GetFamilyPhotos(1));

            var controller = new PhotoController(mockRepo.Object, mapper);

            var result = controller.GetAllFamilyPhotos();

            Assert.IsType<ActionResult<IEnumerable<PhotoReadDto>>>(result);
        }

        [Fact]
        public void GetPhotoByFamilyMember_Returns404NotFound_WhenIDDoesNotExist()
        {
            mockRepo.Setup(repo => repo.GetPhotosByFamilyMember(0)).Returns(() => null);

            var controller = new PhotoController(mockRepo.Object, mapper);

            var result = controller.GetPhotosByFamilyMember(1);

            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void GetPhotosByFamilyMember_Returns200OK_WhenIDExists()
        {
            mockRepo.Setup(repo =>
                repo.GetPhotosByFamilyMember(1)).Returns(new Photo {
                    Id = 1,
                    PhotoUrl = "www.superhero.com/terra-doesnt-remember.jpg"
                });

            var controller = new PhotoController(mockRepo.Object, mapper);

            var result = controller.GetPhotosByFamilyMember(1);

            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void GetPhotosByFamilyMember_ReturnsCorrectType_WhenIDExists()
        {
            mockRepo.Setup(repo =>
                repo.GetPhotosByFamilyMember(1)).Returns(new Photo {
                    Id = 1,
                    PhotoUrl = "www.superhero.com/terra-doesnt-remember.jpg"
                });

            var controller = new PhotoController(mockRepo.Object, mapper);

            var result = controller.GetPhotosByFamilyMember(1);

            Assert.IsType<ActionResult<PhotoReadDto>>(result);
        }

        [Fact]
        public void CreatePhoto_ReturnsCorrectResourceType_WhenValidObjectSubmitted()
        {
            mockRepo.Setup(repo =>
                repo.GetPhotosByFamilyMember(1)).Returns(new Photo {
                    Id = 1,
                    PhotoUrl = "www.superhero.com/terra-doesnt-remember.jpg"
                });

            var controller = new PhotoController(mockRepo.Object, mapper);

            var result = controller.CreatePhoto(new PhotoCreateDto { });

            Assert.IsType<ActionResult<PhotoReadDto>>(result);
        }

        [Fact]
        public void CreatePhoto_Returns201Created_WhenValidObjectSubmitted()
        {
            mockRepo.Setup(repo =>
                repo.GetPhotosByFamilyMember(1)).Returns(new Photo {
                    Id = 1,
                    PhotoUrl = "www.superhero.com/terra-doesnt-remember.jpg"
                });

            var controller = new PhotoController(mockRepo.Object, mapper);

            var result = controller.CreatePhoto(new PhotoCreateDto { });

            Assert.IsType<CreatedAtRouteResult>(result.Result);
        }

        [Fact]
        public void UpdatePhoto_Returns204NoContent_WhenValidObjectSubmitted()
        {
            mockRepo.Setup(repo =>
                repo.GetPhotosByFamilyMember(1)).Returns(new Photo {
                    Id = 1,
                    PhotoUrl = "www.superhero.com/terra-doesnt-remember.jpg"
                });

            var controller = new PhotoController(mockRepo.Object, mapper);

            var result = controller.UpdatePhoto(1, new PhotoUpdateDto { });

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void UpdatePhoto_Returns404NotFound_WhenIDDoesNotExist()
        {
            mockRepo.Setup(repo => repo.GetPhotosByFamilyMember(0)).Returns(() => null);

            var controller = new PhotoController(mockRepo.Object, mapper);

            var result = controller.UpdatePhoto(0, new PhotoUpdateDto { });

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void PartialPhotoUpdate_Returns404NotFound_WhenIDDoesNotExist()
        {
            mockRepo.Setup(repo => repo.GetPhotosByFamilyMember(0)).Returns(() => null);

            var controller = new PhotoController(mockRepo.Object, mapper);

            var result = controller.UpdatePhoto(0, new JsonPatchDocument<PhotoUpdateDto> { });

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void DeletePhoto_Returns204NoContent_WhenIDExists()
        {
            mockRepo.Setup(repo =>
                repo.GetPhotosByFamilyMember(1)).Returns(new Photo {
                    Id = 1,
                    PhotoUrl = "www.superhero.com/terra-doesnt-remember.jpg"
                });

            var controller = new PhotoController(mockRepo.Object, mapper);

            var result = controller.DeletePhoto(1);

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void DeletePhoto_Returns404NotFound_WhenIDDoesNotExist()
        {
            mockRepo.Setup(repo => repo.GetPhotosByFamilyMember(0)).Returns(() => null);

            var controller = new PhotoController(mockRepo.Object, mapper);

            var result = controller.DeletePhoto(0);

            Assert.IsType<NotFoundResult>(result);
        }

        private List<Photo> GetFamilyPhotos(int num)
        {
            var photos = new List<Photo>();
            if (num > 0)
            {
                photos.Add(new Photo
                {
                    Id = 0,
                    PhotoUrl = "www.superhero.com/terra-doesnt-remember.jpg"
                });
            }

            return photos;
        }
    }
}