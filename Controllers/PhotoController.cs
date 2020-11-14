using System.Collections.Generic;
using CfpgFamilyTree.Data;
using CfpgFamilyTree.Models;
using Microsoft.AspNetCore.Mvc;

namespace CfpgFamilyTree.Controllers
{
    public class PhotoController : ControllerBase
    {
        private readonly IPhotoRepo _repository;
        public ActionResult <IEnumerable<Photo>> GetAllFamilyPhotos()
        {
            var photos = _repository.GetAllFamilyPhotos();

            return Ok(photos);
        }

        public ActionResult <Photo> GetPhotosByFamilyMember(int id)
        {
            var photo = _repository.GetPhotosByFamilyMember(id);

            return Ok(photo);
        }
    }
}