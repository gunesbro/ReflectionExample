using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ReflectionExample.Attributes;

namespace ReflectionExample.Pages.Categories
{
    [Category(Name= "Sub Category 1", Id= "Sub1", ParentId = "Cat1", Order = 2)]
    public class SubCategory1Model : PageModel
    {
        public void OnGet()
        {
        }
    }
}
