using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTech.CasAuctions.Dashboard.SDK.Core.Providers.Requests;
using TamTech.CasAuctions.Dashboard.SDK.Core.Providers.Requests.Models;
using TamTech.CasAuctions.Dashboard.SDK.Models.Dtos;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.APIsConsumptionServices
{
    public class BaseAPIService
    {
        #region Props 
        public readonly IRequestProvider ReqProvider; 
        #endregion


        #region Ctors
        public BaseAPIService(IRequestProvider requestProvider)
        {
            ReqProvider = requestProvider;
        }
        #endregion



        public StatisticsDto MapToStatisticsDto(IEnumerable<NumericalStatisticsItemDto> data)
        {
            if (data == null) return null;
            List<string> Labels = new List<string>();
            List<int> Data = new List<int>();
            return new StatisticsDto
            {
                Statistics = data?.Select(m =>
                {
                    Labels.Add(m.Description);
                    Data.Add(m.Count);
                    return m;
                }).ToList(),
                Labels = Labels,
                Data = Data
            };
        }

        public IRequestProviderResult<StatisticsDto> MapToStatisticsDto(IRequestProviderResult<IEnumerable<NumericalStatisticsItemDto>> result)
        {
            return new RequestProviderResult<StatisticsDto>
            {
                Data = MapToStatisticsDto(result.Data),
                Header = result.Header,
                JsonHeader = result.JsonHeader,
                Messages = result.Messages,
                StatusCode = result.StatusCode,
                Success = result.Success,
            };
        }


        public IRequestProviderResult<StatisticsDto> MapToChartsDTo(IRequestProviderResult<IEnumerable<ChartsStatistics>> data)
        {

            var result = new RequestProviderResult<StatisticsDto>();
            if (data == null || data.Data == null)
            {
                result.Success = false;
                return result;
            }
            result.Success = true;
            result.Data = new StatisticsDto
            {
                Labels = data.Data?.Select(m => m.key).ToList(),
                Data = data.Data?.Select(m => m.Count).ToList()
            };
            return result;

        }


    }


    public class DeleteModel<T>
    {
        public DeleteModel(T id)
        {
            Id = id;
        }

        [JsonProperty("id")]
        public T Id { get; set; }
    }

}
