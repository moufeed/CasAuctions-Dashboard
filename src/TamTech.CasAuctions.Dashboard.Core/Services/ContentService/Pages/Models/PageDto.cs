using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using TamTech.CasAuctions.Dashboard.SDK.Models.Dtos.Common;
using TamTech.CasAuctions.Dashboard.SDK.Services.ContentService.Pages.Enums;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.ContentService.Pages.Models
{

    public class PageDto : ContentItem
    {
        public List<string> Keywords { get; set; } = new List<string>(); 

        public DateTime? ContentPublishDate {  get; set; } 

        public int Type { get; set; }

        public PageTypeEnum TypeEnum {
            get
            {
                 switch(Type)
                    {
                    case (int)PageTypeEnum.Html:
                        {
                             return PageTypeEnum.Html;
                        }
                    case (int)PageTypeEnum.Sections:
                        {
                            return PageTypeEnum.Sections;
                        }
                    default:
                        {
                            return PageTypeEnum.Html;
                        }
                }
            }

            set { }
        } 

        public string HtmlContent { get; set; }

        public Dictionary<string, string> SectionsContent { get; set; } = new Dictionary<string, string>();

        public string Key { get; set; }
         

    }
}
