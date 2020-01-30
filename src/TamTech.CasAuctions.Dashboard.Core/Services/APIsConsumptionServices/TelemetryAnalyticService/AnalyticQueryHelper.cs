using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.APIsConsumptionServices.TelemetryAnalyticService
{
    public class AnalyticQueryHelper
    {
        

        public static string GetCountActiveUsersQuery(DateTime fromDate, DateTime toDate)
        {        
           string query = $@"union   customEvents
                            | where timestamp  between(datetime('{fromDate.ToUniversalTime().ToString("o")}')..datetime('{toDate.ToUniversalTime().ToString("o")}'))
                            | where name == 'RealTimeConnected'
                            | summarize CountOfRecords = dcount(tostring(customDimensions['UserId']))";
            return $"query={ HttpUtility.UrlEncode(query)}";
        }
    }







    public class AnalyticQueryTester
    {
        private const string URL = "https://api.applicationinsights.io/v1/apps/{0}/query?query={1}";


        const string query = @"union   customEvents
                            | where timestamp  between(datetime('2020-01-23T02:13:00.794Z')..datetime('2020-01-30T09:30:00.794Z'))
                            | where name == 'RealTimeConnected'
                              | summarize CountOfRecords = dcount(tostring(customDimensions['UserId']))";
        public static async Task<string> GetTelemetry(string parameterString = query)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("x-api-key", "lf0ncl43nqsfkobk2s2k8dqhsojjj67v148ixxjq" /*ConfigurationManager.AppSettings["InsightAPIKey"]*/);
            var req = string.Format(URL, "0e5fbd2d-785a-40b8-94f1-6df43fb3d526"/*ConfigurationManager.AppSettings["InsightAPPId"]*/, HttpUtility.UrlEncode(parameterString));
            HttpResponseMessage response = client.GetAsync(req).Result;
            response.EnsureSuccessStatusCode();
            string content = await response.Content.ReadAsStringAsync();
            dynamic ddddd = JsonConvert.DeserializeObject<dynamic>(content);
            return content;
        }
      
    }





}
