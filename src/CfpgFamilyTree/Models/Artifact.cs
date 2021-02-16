using System.ComponentModel.DataAnnotations;

namespace CfpgFamilyTree.Models
{
    public class Artifact
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string PhotoUrl { get; set; }

        [Required]
        public string Title { get; set; }

        public string ShortDescription { get; set; }

        public string LongDescription { get; set; }
    }
}