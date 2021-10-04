using Microsoft.AspNetCore.Razor.TagHelpers;
using ReflectionExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionExample.TagHelpers
{
    [HtmlTargetElement("reflect-navbar")]
    public class Navbar : TagHelper
    {
        
        [HtmlAttributeName("nav-header")]
        public string Header { get; set; } = "";
        public CategoriesModel CategoryModel { get; set; } = Globals.Globals.CategoryList;

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "Reflect-Nabvar";
            output.TagMode = TagMode.StartTagAndEndTag;
            var sb = new StringBuilder();
            sb.AppendFormat(@"<h4>{0}</h4>",Header);
            foreach (var item in CategoryModel.Categories)
            {
                sb.AppendFormat(@"
                        <div>
                                <nav>
                                    <ul>
                                        <li>
                                            <a href='{0}'>
                                                {1}
                                            </a>
                                           [sub-categories]
                                        </li>
                                    </ul>
                                </nav>
                            </div>", item.Category.RazorPage, item.Category.Name);
                if (item.SubCategories != null)
                {
                    string subStr = "<ul>";
                    foreach (var sub in item.SubCategories)
                    {
                        subStr += String.Format(@" 
                        <li>
                                <a href='{0}'>
                                         {1}
                                </a>
                         </li>", sub.RazorPage, sub.Name);
                    }
                    subStr += "</ul>";
                    sb = sb.Replace("[sub-categories]", subStr);
                }
                else
                    sb = sb.Replace("[sub-categories]", "");
            }
            output.PreContent.SetHtmlContent(sb.ToString());
            base.Process(context, output);
        }
    }
}
