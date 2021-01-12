using System.ComponentModel.DataAnnotations;

namespace CfpgFamilyTree.Models
{
    public class Artifact
    {
        public int Id { get; set; }

        [Required]
        public string PhotoUrl { get; set; }

        [Required]
        public string Description { get; set; }
    }
}