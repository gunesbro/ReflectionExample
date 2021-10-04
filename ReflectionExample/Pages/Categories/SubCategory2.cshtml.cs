using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ReflectionExample.Attributes;

namespace ReflectionExample.Pages.Categories
{
    [Category(Name = "Sub Category 2", Id = "Sub2", Order = 1, ParentId = "Sub1")]
    public class SubCategory2Model : PageModel
    {
        public void OnGet()
        {
        }
    }
}
