using ReflectionExample.Models;
using ReflectionExample.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReflectionExample.Globals
{
    public static class Globals
    {
        public static string CategoriesJson => ReflectCategories.CategoriesJson ?? String.Empty;
        public static CategoriesModel CategoryList => ReflectCategories.CategoryList ?? null;
    }
}
