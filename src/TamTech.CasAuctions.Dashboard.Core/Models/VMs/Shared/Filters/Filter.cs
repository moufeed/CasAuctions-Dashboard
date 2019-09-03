using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.CasAuctions.Dashboard.SDK.Models.VMs.Shared.Filters
{
    public class Filter
    {

        [JsonProperty("PageNumber")]
        public int PageNumber { get; set; } = 1;

        [JsonProperty("PageSize")]
        public int PageSize { get; set; } = 10;

        [JsonProperty("sort_by")]
        public string SortBy { get; set; } = null;

        [JsonProperty("desc")]
        public bool Desc { get; set; } = false;

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("full_name")]
        public string FullName { get; set; }

        [JsonProperty("username")]
        public string UserName { get; set; }

        [JsonProperty("emil")]
        public string Email { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; } = null;

        [JsonProperty("city_id")]
        public int? CityId { get; set; } = null;

        [JsonProperty("status_id")]
        public int? StatusId { get; set; } = null;

        [JsonProperty("sector_id")]
        public int? SectorId { get; set; } = null;

        [JsonProperty("section_id")]
        public Guid? SectionId { get; set; } = null;

        [JsonProperty("prent_id")]
        public Guid? ParentId { get; set; } = null;

        [JsonProperty("type")]
        public int? Type { get; set; }

        [JsonProperty("visibility")]
        public int? Visibility { get; set; }

        [JsonProperty("att_id")]
        public int AttId { get; set; }

        [JsonProperty("role_id")]
        public string RoleId { get; set; } = "";

        [JsonProperty("continuation_token")]
        public string ContinuationToken { get; set; } = null;

        [JsonProperty("section")]
        public string Section { get; set; } = "";

        [JsonProperty("author_name")]
        public string AuthorName { get; set; } = "";


        [JsonProperty("search")]
        public string Search { get; set; } = null;

        [JsonProperty("sector_slug")]
        public string SectorSlug { get; set; } = null;

        [JsonProperty("val_ids")]
        public string valIds { get; set; } = null;

        [JsonProperty("type_ids")]
        public string TypeIds { get; set; } = null;

        [JsonProperty("rating")]
        public int? Rating { get; set; }

        [JsonProperty("type_id")]
        public int? TypeId { get; set; }

        [JsonProperty("mobile")]
        public int? Moblie { get; set; }

        [JsonProperty("values")]
        public List<value> Values { get; set; }

 




        public override bool Equals(object obj)
        {
            var filters = obj as Filter;

            return filters != null &&
                   Desc == filters.Desc &&
                   CityId == filters.CityId &&
                   StatusId == filters.StatusId &&
                   Desc == filters.Desc &&
                   Type == filters.Type &&
                   Rating == filters.Rating &&
                   TypeId == filters.TypeId &&
                   Moblie == filters.Moblie &&
                   AttId == filters.AttId &&
                   EqualityComparer<Guid?>.Default.Equals(SectionId, filters.SectionId) &&
                   string.IsNullOrWhiteSpace(SortBy) == string.IsNullOrWhiteSpace(filters.SortBy) &&
                   string.IsNullOrWhiteSpace(Title) == string.IsNullOrWhiteSpace(filters.Title) &&
                   string.IsNullOrWhiteSpace(RoleId) == string.IsNullOrWhiteSpace(filters.RoleId) &&
                   string.IsNullOrWhiteSpace(Section) == string.IsNullOrWhiteSpace(filters.Section) &&
                   string.IsNullOrWhiteSpace(AuthorName) == string.IsNullOrWhiteSpace(filters.AuthorName) &&
                   string.IsNullOrWhiteSpace(Email) == string.IsNullOrWhiteSpace(filters.Email) &&
                   string.IsNullOrWhiteSpace(FullName) == string.IsNullOrWhiteSpace(filters.FullName) &&
                   string.IsNullOrWhiteSpace(Search) == string.IsNullOrWhiteSpace(filters.Search) &&
                   string.IsNullOrWhiteSpace(SectorSlug) == string.IsNullOrWhiteSpace(filters.SectorSlug) &&
                   string.IsNullOrWhiteSpace(Name) == string.IsNullOrWhiteSpace(filters.Name);
        }
        public static bool operator ==(Filter filters1, Filter filters2)
        {
            return EqualityComparer<Filter>.Default.Equals(filters1, filters2);
        }

        public static bool operator !=(Filter filters1, Filter filters2)
        {
            return !(filters1 == filters2);
        }

    }

    public class value
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("is_checked")]
        public bool IsChecked { get; set; }
    }
}
