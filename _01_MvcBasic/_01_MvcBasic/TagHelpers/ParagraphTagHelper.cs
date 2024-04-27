using Microsoft.AspNetCore.Razor.TagHelpers;

namespace _01_MvcBasic.TagHelpers
{
    [HtmlTargetElement("paragraph")]
    public class ParagraphTagHelper : TagHelper
    {
        public string ShortDescription { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Content.SetHtmlContent($"<b>Custom Tag Helper works {ShortDescription}</b>");
            base.Process(context, output);
        }
    }
}
