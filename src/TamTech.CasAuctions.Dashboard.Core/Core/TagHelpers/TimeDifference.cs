using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TamTech.CasAuctions.Dashboard.SDK.Core.TagHelpers
{
    [HtmlTargetElement("TimeAgo")]
  public class TimeDifference : TagHelper
    {
        public DateTime dateTime { get; set; }

        private readonly IStringLocalizer<TimeDifference> _localizer;

        public TimeDifference(IStringLocalizer<TimeDifference> localizer)
        {
            _localizer = localizer;
        }

        private string ConvertTime()
        {
            string result = string.Empty;
            var timeSpan = DateTime.UtcNow.Subtract(dateTime);

            if (timeSpan <= TimeSpan.FromSeconds(60))
            {
                result = string.Format("{0} seconds ago", timeSpan.Seconds);
            }
            else if (timeSpan <= TimeSpan.FromMinutes(60))
            {
                /*
                 result = timeSpan.Minutes > 1 ?
                    String.Format("about {0} minutes ago", timeSpan.Minutes) :
                    "about a minute ago";
                 */

                result = timeSpan.Minutes > 1 ? _localizer["minutes_ago", timeSpan.Minutes] : _localizer["minute_ago"];
            }
            else if (timeSpan <= TimeSpan.FromHours(24))
            {
                /*
                  result = timeSpan.Hours > 1 ?
                     String.Format("about {0} hours ago", timeSpan.Hours) :
                     "about an hour ago";
                     */
                result = timeSpan.Hours > 1 ? _localizer["hours_ago", timeSpan.Hours] : _localizer["hour_ago"];
            }
            else if (timeSpan <= TimeSpan.FromDays(30))
            {
                //result = timeSpan.Days > 1 ?
                //    String.Format("about {0} days ago", timeSpan.Days) :
                //    "";

                result = timeSpan.Days > 1 ?   _localizer["about_days_ago", timeSpan.Days] : _localizer["yesterday"];
            }
            else if (timeSpan <= TimeSpan.FromDays(365))
            {
                /* result = timeSpan.Days > 30 ?
                    String.Format("about {0} months ago", timeSpan.Days / 30) :
                    "about a month ago";*/
                result = timeSpan.Days > 30 ? _localizer["months_ago", timeSpan.Days / 30] : _localizer["month_ago"];
            }
            else
            {
                /* result = timeSpan.Days > 365 ?
                    String.Format("about {0} years ago", timeSpan.Days / 365) :
                    "about a year ago";*/

                result = timeSpan.Days > 365 ? _localizer["years_ago", timeSpan.Days / 365] : _localizer["year_ago"];
            }

            return result;
        }

        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = null;
            output.Content.SetHtmlContent(ConvertTime());
            return base.ProcessAsync(context, output);
        }
    }
}
