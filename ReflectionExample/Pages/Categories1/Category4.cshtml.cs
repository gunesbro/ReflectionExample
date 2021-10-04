using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ReflectionExample.Attributes;

namespace ReflectionExample.Pages.Categories1
{
    [Category(Name = "Category 4", Id = "Cat4", Order = 0)]
    public class Category4Model : PageModel
    {
        public void OnGet()
        {
        }
    }
}
