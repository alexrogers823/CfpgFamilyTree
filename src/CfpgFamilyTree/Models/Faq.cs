using System.ComponentModel.DataAnnotations;

namespace CfpgFamilyTree.Models
{
    public class Faq
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Question { get; set; }

        [Required]
        public string Answer { get; set; }
    }
}