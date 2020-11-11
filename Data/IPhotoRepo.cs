using System.Collections.Generic;
using CfpgFamilyTree.Models;

namespace CfpgFamilyTree.Data 
{
    public interface IPhotoRepo 
    {
        IEnumerable<Photo> GetAllFamilyPhotos();
        Photo GetPhotosByFamilyMember(int id);
    }
}