using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using ReflectionExample.Attributes;
using ReflectionExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ReflectionExample.Reflection
{
    public static class ReflectCategories
    {
        private static string _categoriesJson;
        private static CategoriesModel _categoryList;


        public static void LoadCategories(this IApplicationBuilder app, Assembly assembly)
        {
            CategoriesModel categoriesModel = new();
            categoriesModel.Categories = new();
            categoriesModel.Errors = new();
            List<CategoryModel> subCategoryList = new();
            foreach (Type type in assembly.GetTypes())
            {
                if (type.GetCustomAttributes(typeof(CategoryAttribute), true).Length > 0)
                {
                    foreach (var attr in type.CustomAttributes)
                    {
                        string id = String.Empty, name = String.Empty, parentId = String.Empty;
                        int order = 999;
                        foreach (var arg in attr.NamedArguments)
                        {
                            object value = arg.TypedValue.Value;
                            id = arg.MemberName == "Id" ? value.ToString() : id;
                            name = arg.MemberName == "Name" ? value.ToString() : name;
                            order = arg.MemberName == "Order" ? (int)value : order;
                            parentId = arg.MemberName == "ParentId" ? value.ToString() : parentId;
                        }
                        if (!String.IsNullOrEmpty(id) && !String.IsNullOrEmpty(name))
                        {
                            if (String.IsNullOrEmpty(parentId))
                            {
                                CategoryListModel category = new();
                                string razorPage = GetRazorPage(type.FullName, type.Name);
                                category.Category = CategoryModel.NewCategory(id, name, order, razorPage);
                                categoriesModel.Categories.Add(category);
                            }
                            else
                            {
                                string razorPage = GetRazorPage(type.FullName, type.Name);
                                CategoryModel subCategory = CategoryModel.NewCategory(id, name, order, razorPage, parentId);
                                subCategoryList.Add(subCategory);
                            }
                        }
                        else
                        {
                            Errors error = Errors.NewError($"{type.Namespace}.{type.Name}", "Missing implementation! Id or Name cannot be empty!");
                            categoriesModel.Errors.Add(error);
                        }
                    }
                }
            }
            //Add sub categories to List
            if (subCategoryList.Count > 0)
            {
                foreach (var sub in subCategoryList)
                {
                    var parent = categoriesModel.Categories.FirstOrDefault(x => x.Category.Id == sub.ParentId);
                    if (parent != null)
                    {
                        if (parent.SubCategories == null)
                            parent.SubCategories = new();

                        parent.SubCategories.Add(sub);
                        parent.SubCategories = parent.SubCategories.OrderBy(o => o.Order).ToList();
                    }
                    else
                    {
                        Errors error = Errors.NewError($"{sub.RazorPage}", "Parent Not Found! info: Sub categories cannot be parent");
                        categoriesModel.Errors.Add(error);
                    }
                }
            }
            categoriesModel.Categories = categoriesModel.Categories.OrderBy(o => o.Category.Order).ToList();
            _categoryList = categoriesModel;
            _categoriesJson = Newtonsoft.Json.JsonConvert.SerializeObject(categoriesModel, Formatting.Indented);
        }

        private static string GetRazorPage(string fullName, string name)
        {
            string categoryRootFolder = "Pages";
            int startIndex = fullName.IndexOf(categoryRootFolder) + categoryRootFolder.Length;
            int endIndex = fullName.IndexOf(name) + name.Length;

            string razorPage = fullName.Substring(startIndex, (endIndex - startIndex));
            razorPage = razorPage.Replace(".", "/").Replace("Model", "");

            return razorPage;
        }

        public static string CategoriesJson => _categoriesJson ?? String.Empty;
        public static CategoriesModel CategoryList => _categoryList ?? null;


    }
}
