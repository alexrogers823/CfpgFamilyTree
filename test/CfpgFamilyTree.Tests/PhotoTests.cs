using Xunit;
using CfpgFamilyTree.Models;

namespace CfpgFamilyTree.Tests
{
    public class PhotoTests
    {
        [Fact]
        public void CanChangePhotoUrl()
        {
            Photo testPhoto = new Photo
            {
                PhotoUrl = "yellowBrickRoad.com/tinMan.jpg"
            };

            testPhoto.PhotoUrl = "prideRock.com/simba.jpg";

            Assert.Equal("prideRock.com/simba.jpg", testPhoto.PhotoUrl);
        }
    }
}