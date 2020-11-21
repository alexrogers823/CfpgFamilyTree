using System.Collections.Generic;
using AutoMapper;
using CfpgFamilyTree.Data;
using CfpgFamilyTree.Dtos;
using CfpgFamilyTree.Models;
using Microsoft.AspNetCore.Mvc;

namespace CfpgFamilyTree.Controllers
{
    [Route("api/photos")]
    [ApiController]
    public class PhotoController : ControllerBase
    {
        private readonly IPhotoRepo _repository;
        private readonly IMapper _mapper;

        public PhotoController(IPhotoRepo repository, IMapper mapper)
        {
            _repository = repository; 
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult <IEnumerable<Photo>> GetAllFamilyPhotos()
        {
            var photos = _repository.GetAllFamilyPhotos();

            return Ok(_mapper.Map<IEnumerable<PhotoReadDto>>(photos));
        }

        [HttpGet("{id}", Name="GetPhotosByFamilyMember")]
        public ActionResult <Photo> GetPhotosByFamilyMember(int id)
        {
            var photo = _repository.GetPhotosByFamilyMember(id);
            if(photo != null)
            {
                return Ok(_mapper.Map<PhotoReadDto>(photo));
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult <PhotoCreateDto> CreatePhoto(PhotoCreateDto photoCreateDto)
        {
            var photoModel = _mapper.Map<Photo>(photoCreateDto);
            _repository.CreatePhoto(photoModel);
            _repository.SaveChanges();

            var photoReadDto = _mapper.Map<PhotoReadDto>(photoModel);

            return CreatedAtRoute(nameof(GetPhotosByFamilyMember), new {Id = photoReadDto.Id}, photoReadDto);
        }
    }
}