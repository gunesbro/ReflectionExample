using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ReflectionExample.Attributes;

namespace ReflectionExample.Pages.Categories
{
    [Category(Name = "Category 3", Id = "Cat3", Order = 2)]
    public class Category3Model : PageModel
    {
        public void OnGet()
        {
        }
    }
}
