using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace RWA.Helpers
{
    public static class FullNameExtension
    {
        public static MvcHtmlString FullName(this HtmlHelper helper, string name, string surname)
        {            
            return MvcHtmlString.Create(string.Format("{0} {1}", name, surname));
        }
    }
}