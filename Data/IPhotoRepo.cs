using System.Collections.Generic;
using CfpgFamilyTree.Models;

namespace CfpgFamilyTree.Data 
{
    public interface IPhotoRepo 
    {
        bool SaveChanges();
        IEnumerable<Photo> GetAllFamilyPhotos();
        Photo GetPhotosByFamilyMember(int id);
        void CreatePhoto(Photo photo);
        void UpdatePhoto(Photo photo);
    }
}