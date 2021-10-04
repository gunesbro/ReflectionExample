using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ReflectionExample.Attributes;

namespace ReflectionExample.Pages.Categories1.Sub_Categories
{
    [Category(Name = "Sub Category 3", Id = "Sub3", Order = 0, ParentId ="Cat4")]
    public class SubCategory3Model : PageModel
    {
        public void OnGet()
        {
        }
    }
}
