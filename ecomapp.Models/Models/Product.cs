using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ecomapp.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        [Required]
        public string ISBN { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        [Range(0, 1000)]
        [DisplayName("List Price")]
        public double ListPrice { get; set; }

        [Required]
        [Range(0, 1000)]
        [DisplayName("Price for 1-50")]
        public double Price { get; set; }

        [Required]
        [Range(0, 1000)]
        [DisplayName("Price for 50+")]
        public double Price50 { get; set; }

        [Required]
        [Range(0, 1000)]
        [DisplayName("Price for 100+")]
        public double Price100 { get; set; }


        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category Category { get; set; }
        public string ImageUrl { get; set; }
    }
}