using System.Collections.Generic;
using AutoMapper;
using CfpgFamilyTree.Data;
using CfpgFamilyTree.Dtos;
using CfpgFamilyTree.Models;
using Microsoft.AspNetCore.JsonPatch;
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
        public ActionResult <IEnumerable<PhotoReadDto>> GetAllFamilyPhotos()
        {
            var photos = _repository.GetAllFamilyPhotos();

            return Ok(_mapper.Map<IEnumerable<PhotoReadDto>>(photos));
        }

        [HttpGet("{id}", Name="GetPhotosByFamilyMember")]
        public ActionResult <PhotoReadDto> GetPhotosByFamilyMember(int id)
        {
            var photo = _repository.GetPhotosByFamilyMember(id);
            if(photo != null)
            {
                return Ok(_mapper.Map<PhotoReadDto>(photo));
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult <PhotoReadDto> CreatePhoto(PhotoCreateDto photoCreateDto)
        {
            var photoModel = _mapper.Map<Photo>(photoCreateDto);
            _repository.CreatePhoto(photoModel);
            _repository.SaveChanges();

            var photoReadDto = _mapper.Map<PhotoReadDto>(photoModel);

            return CreatedAtRoute(nameof(GetPhotosByFamilyMember), new {Id = photoReadDto.Id}, photoReadDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdatePhoto(int id, PhotoUpdateDto photoUpdateDto)
        {
            var photoModel = _repository.GetPhotosByFamilyMember(id);
            if (photoModel == null)
            {
                return NotFound();
            }

            _mapper.Map(photoUpdateDto, photoModel);
            _repository.UpdatePhoto(photoModel);
            _repository.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult UpdatePhoto(int id, JsonPatchDocument<PhotoUpdateDto> patchDoc)
        {
            var photoModel = _repository.GetPhotosByFamilyMember(id);

            if(photoModel == null)
            {
                return NotFound();
            }

            var photoPatch = _mapper.Map<PhotoUpdateDto>(photoModel);
            patchDoc.ApplyTo(photoPatch, ModelState);
            if(!TryValidateModel(photoPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(photoPatch, photoModel);

            _repository.UpdatePhoto(photoModel);
            _repository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeletePhoto(int id)
        {
            var photoModel = _repository.GetPhotosByFamilyMember(id);

            if(photoModel == null)
            {
                return NotFound();
            }

            _repository.DeletePhoto(photoModel);
            _repository.SaveChanges();

            return NoContent();

        }
    }
}