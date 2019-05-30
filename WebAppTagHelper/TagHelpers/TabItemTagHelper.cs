using Microsoft.AspNetCore.Razor.TagHelpers;

namespace WebAppTagHelper.TagHelpers
{
    [RestrictChildren("tab-item")]
    public class TabItemTagHelper : TagHelper
    {

        public string Title { get; set; }

        public override void Process(
            TagHelperContext context, TagHelperOutput output)
        {
            string activePage = context.Items["ActivePage"] as string;
            string activeLink = string.Empty;
            if (activePage == Title)
                activeLink = "active";

            output.TagName = "li";
            var str = string.Format("<a class= 'nav-link {0}' href = '#' >{1}</a>", activeLink, Title);
            output.Content.SetHtmlContent(str);
            output.Attributes.Add("class", "nav-item");
        }
    }
}

