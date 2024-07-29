using System.ComponentModel.DataAnnotations;

namespace ecomapp
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public int DisplayOrder { get; set; }
    }
}