using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace WebAppTagHelper.TagHelpers
{
    [HtmlTargetElement("mod-test")]
    public class ModTestTagHelper : TagHelper
    {
        public ModelExpression HelperFor { get; set; }

        public override void Process
            (TagHelperContext context, TagHelperOutput output)
        {
            output.Content.SetContent(HelperFor.Model.ToString());
        }
    }
}
