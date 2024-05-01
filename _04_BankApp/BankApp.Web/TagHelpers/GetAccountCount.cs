using BankApp.Web.Data.Context;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace BankApp.Web.TagHelpers
{
    [HtmlTargetElement("getAccountCount")]
    public class GetAccountCount : TagHelper
    {
        public int ApplicationUserId { get; set; }
        private readonly AppDbContext _context;

        public GetAccountCount(AppDbContext context)
        {
            _context = context;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var accountCount = _context.Accounts.Count(x => x.ApplicationUserId == ApplicationUserId);
            var html = $"<span class='badge bg-danger'>{accountCount}</span>";

            output.Content.SetHtmlContent(html);

        }
    }
}
