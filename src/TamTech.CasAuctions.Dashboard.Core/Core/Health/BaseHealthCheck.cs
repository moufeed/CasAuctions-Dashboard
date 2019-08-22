using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;         
using System.Net;
using System.Net.Http;   
using System.Threading;
using System.Threading.Tasks;
using TamTech.CasAuctions.Dashboard.SDK.Core.Extensions;
using TamTech.CasAuctions.Dashboard.SDK.Models.Shared;

namespace TamTech.CasAuctions.Dashboard.SDK.Core.Health
{
    public class BaseHealthCheck 
    {

        #region Props  

        public readonly ILogger _logger;
        public readonly BackendAPIsSettings _backendApiSettings;
        #endregion

        #region Ctors  
        public BaseHealthCheck(BackendAPIsSettings backendApiSettings, ILogger<BaseHealthCheck> logger)
        {
            _backendApiSettings = backendApiSettings;
            _logger = logger;
        }
        #endregion


      
        public async Task<PingResultModel> SendAsync(string uri)
        {
            try
            {
                var httpClient = new HttpClient();

                HttpRequestMessage request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(uri),
                };

                HttpResponseMessage response = await httpClient.SendAsync(request);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    string serialized = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<PingResultModel>(serialized);
                    return data;
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogException(ex, uri);
                throw;
            }
        }
    }
    public class PingResultModel
    {
        [JsonProperty("status")]
        public bool Status { get; set; }
    }
}
