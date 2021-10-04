using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReflectionExample.Models
{
    public class CategoriesModel
    {
        public List<CategoryListModel> Categories { get; set; }
        public List<Errors> Errors { get; set; }
    }

    public class CategoryListModel
    {
        public CategoryModel Category { get; set; }
        public List<CategoryModel> SubCategories { get; set; }
    }

    public class CategoryModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public string ParentId { get; set; }
        public string RazorPage { get; set; }
        public static CategoryModel NewCategory(string id, string name, int order,string razorPage, string parentId = null)
        {
            CategoryModel category = new();
            category.Id = id;
            category.Name = name;
            category.Order = order;
            category.ParentId = parentId;
            category.RazorPage = razorPage;
            return category;
        }
    }

    public class Errors
    {
        public string Location { get; set; }
        public string ErrorMessage { get; set; }

        public static Errors NewError(string location, string errorMessage)
        {
            Errors error = new();
            error.Location = location;
            error.ErrorMessage = errorMessage;
            return error;
        }
    }
}
