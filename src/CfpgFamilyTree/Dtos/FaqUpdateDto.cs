using System.ComponentModel.DataAnnotations;

namespace CfpgFamilyTree.Dtos
{
    public class FaqUpdateDto
    {
        [Required]
        public string Question { get; set; }

        [Required]
        public string Answer { get; set; }
    }
}