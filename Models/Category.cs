using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ecomapp
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(30)]
        [Required]
        [DisplayName("Name")]
        public string Name { get; set; } = string.Empty;
        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage = "The Range required a number between 1 - 100")]
        public int DisplayOrder { get; set; }
    }
}