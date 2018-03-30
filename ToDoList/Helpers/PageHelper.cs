using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using ToDoList.Models;

namespace ToDoList.Helpers
{
    public static class PageHelper
    {
        //Generate html for a set of page links from pageinfo object
        public static MvcHtmlString PageLinks(this HtmlHelper html,
                                                PageInfo pageInfo,
                                                Func<int,string> pageUrl)
        {
            StringBuilder s = new StringBuilder();
            for (int i = 1; i < pageInfo.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();
                if(i == pageInfo.CurrentPage)
                {
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-primary");

                }
                tag.AddCssClass("btn btn-default");
                s.Append(tag.ToString());
            }
            return MvcHtmlString.Create(s.ToString());
        }
    }
}