using System.ComponentModel.DataAnnotations;

namespace CfpgFamilyTree.Dtos
{
    public class PhotoUpdateDto
    {
        public int Id { get; set; }

        [Required]
        public string PhotoUrl { get; set; }
    }
}