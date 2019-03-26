using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MindfireSolutions.CustomHelper
{
    public static class FileUploader
    {
        public static MvcHtmlString Image(this HtmlHelper helper, string src, string altText)
        {
            var builder = new TagBuilder("img");

            builder.Attributes.Add("src", src);

            builder.Attributes.Add("alt", altText);

            builder.Attributes.Add("class", "image-view");

            return MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));
        }

        public static MvcHtmlString FileFor(this HtmlHelper helper, string Id, string File)
        {
            var builder = new TagBuilder("input");

            builder.MergeAttribute("type", "file");

            builder.MergeAttribute("Id", Id);

            builder.MergeAttribute("name", File);           

            builder.MergeAttribute("style", "color:black");

            return MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));

        }

    }
}