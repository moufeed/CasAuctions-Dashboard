using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.TelemetryAnalyticService.Models
{
    public class TelemetryReultModel
    {
        [JsonProperty("tables")]
        public List<Table> Tables { get; set; }
    }
    public class Column
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
    public class Table
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("columns")]
        public List<Column> Columns { get; set; }

        [JsonProperty("rows")]
        public List<List<object>> Rows { get; set; }
    }
    
}
