using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ReflectionExample.Attributes;
using ReflectionExample.Reflection;

namespace ReflectionExample.Pages.Categories
{
    [Category(Name = "Category 1", Id= "Cat1", Order = 1)]
    public class Category1Model : PageModel
    {
        public void OnGet()
        {
            
        }
    }
}
