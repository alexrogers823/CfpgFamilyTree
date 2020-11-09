using System.Collections.Generic;
using CfpgFamilyTree.Models;

namespace CfpgFamilyTree.Data 
{
    public interface IPhoto 
    {
        IEnumerable<Photo> GetAllFamilyPhotos();
        Photo GetPhotosByFamilyMember(int id);
    }
}