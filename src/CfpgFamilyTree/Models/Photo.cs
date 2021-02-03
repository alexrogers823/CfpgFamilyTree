using System.ComponentModel.DataAnnotations;

namespace CfpgFamilyTree.Models 
{
    public class Photo 
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string PhotoUrl { get; set; }
    }
}