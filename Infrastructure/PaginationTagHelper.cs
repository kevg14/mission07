using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Mission07.Models.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mission07.Controllers.Infrastructure
{


    [HtmlTargetElement("div", Attributes = "page-non")]

    public class PaginationTagHelper : TagHelper
    {
        //I am dynamically creating the page links

        private IUrlHelperFactory uhf;

        public PaginationTagHelper(IUrlHelperFactory temp)
        {
            uhf = temp;

        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext vc { get; set; }

        //different than the viewcontext
        public PageInfo PageNon { get; set; }

        public string PageAction { get; set; }

        //improving pages
        public string PageClass { get; set; }
        public bool PageClassesEnabled { get; set; }
        public string PageClassNormal { get; set; }
        public string PageClassSelected { get; set; }

        public override void Process (TagHelperContext thc, TagHelperOutput tho)
        {
            IUrlHelper uh = uhf.GetUrlHelper(vc);

            TagBuilder final = new TagBuilder("div");

            for(int i = 1; i <PageNon.TotalPages; ++i)
            {
                TagBuilder tb = new TagBuilder("a");

                tb.Attributes["href"] = uh.Action(PageAction, new { pageNum = i });

                if (PageClassesEnabled)
                {
                    tb.AddCssClass(PageClass);
                    tb.AddCssClass(i == PageNon.CurrentPage ? PageClassSelected : PageClassNormal);
                }
                tb.AddCssClass(PageClass);
                tb.InnerHtml.Append(i.ToString());

                final.InnerHtml.AppendHtml(tb);
            }
            tho.Content.AppendHtml(final.InnerHtml);
        }
    }
}
