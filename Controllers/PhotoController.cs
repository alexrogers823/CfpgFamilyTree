using System.Collections.Generic;
using CfpgFamilyTree.Data;
using CfpgFamilyTree.Models;
using Microsoft.AspNetCore.Mvc;

namespace CfpgFamilyTree.Controllers
{
    [Route("api/photos")]
    [ApiController]
    public class PhotoController : ControllerBase
    {
        private readonly IPhotoRepo _repository;
        public PhotoController()
        {
            // _repository = _repository; 
        }

        [HttpGet]
        public ActionResult <IEnumerable<Photo>> GetAllFamilyPhotos()
        {
            var photos = _repository.GetAllFamilyPhotos();

            return Ok(photos);
        }

        [HttpGet("{id}")]
        public ActionResult <Photo> GetPhotosByFamilyMember(int id)
        {
            var photo = _repository.GetPhotosByFamilyMember(id);

            return Ok(photo);
        }
    }
}