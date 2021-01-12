using System.ComponentModel.DataAnnotations;

namespace CfpgFamilyTree.Dtos
{
    public class ArtifactUpdateDto
    {
        public int Id { get; set; }

        [Required]
        public string PhotoUrl { get; set; }

        [Required]
        public string Description { get; set; }
    }
}