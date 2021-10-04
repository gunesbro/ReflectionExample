using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ReflectionExample.Attributes;

namespace ReflectionExample.Pages.Categories
{
    [Category(Name = "Category 2",Id="Cat2", Order = 3)]
    public class Category2Model : PageModel
    {
        public void OnGet()
        {
        }
    }
}
