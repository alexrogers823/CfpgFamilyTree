using System;
using System.Collections.Generic;
using System.Linq;
using CfpgFamilyTree.Models;

namespace CfpgFamilyTree.Data
{
    public class SqlPhotoRepo : IPhotoRepo
    {
        private readonly PhotoContext _context;

        public SqlPhotoRepo(PhotoContext context)
        {
            _context = context;
        }

        public void CreatePhoto(Photo photo)
        {
            if(photo == null)
            {
                throw new ArgumentNullException(nameof(photo));
            }
            _context.Photos.Add(photo);
        }

        public void DeletePhoto(Photo photo)
        {
            if(photo == null)
            {
                throw new ArgumentNullException(nameof(photo));
            }

            _context.Photos.Remove(photo);
        }

    public IEnumerable<Photo> GetAllFamilyPhotos()
        {
            return _context.Photos.ToList();
        }

        public Photo GetPhotosByFamilyMember(int id)
        {
            return _context.Photos.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdatePhoto(Photo photo)
        {
        
        }
  }
}