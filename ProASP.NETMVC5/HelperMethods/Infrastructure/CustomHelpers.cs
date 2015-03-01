using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelperMethods.Infrastructure
{
    public static class CustomHelpers
    {
        // This is the C# equivalent of the following inline helper.
        // It's imperative nature is harder to parse and less 'html'.
        //
        // @helper ListArrayItems(String[] items) { 
        //     <ul>
        //         @foreach (string str in items) {
        //             <li>@str</li>
        //         }
        //     </ul>
        // }
        public static MvcHtmlString ListArrayItems(this HtmlHelper html, String[] list)
        {
            TagBuilder listTagBuilder = new TagBuilder("ul");

            foreach (String str in list)
            {
                TagBuilder listItemTagBuilder = new TagBuilder("li");
                listItemTagBuilder.SetInnerText(str);
                listTagBuilder.InnerHtml += listItemTagBuilder.ToString();
            }

            return new MvcHtmlString(listTagBuilder.ToString());
        }

        public static MvcHtmlString DisplayMessage(this HtmlHelper htmlHelper, String message)
        {
            // HtmlHelper.Encode() is required to prevent form elements from being rendered verbatim.
            // e.g. 
            String encodedMessage = htmlHelper.Encode(message);
            String result = String.Format("This is the message: <p>{0}</p>", encodedMessage);

            return new MvcHtmlString(result);
        }
    }
}