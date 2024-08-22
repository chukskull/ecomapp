using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace ecomapp.Models.ModelsView
{
    public class ProductVM
    {
        [ValidateNever]
        public IEnumerable<SelectListItem> CategoryList { get; set; }
        public Product Product { get; set; }
    }
}