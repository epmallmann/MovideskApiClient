using Movidesk.Api.Client.Http;
using Movidesk.Api.Client.Models;
using Movidesk.Api.Client.Utils;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Movidesk.Api.Client.Resources
{
    public interface ITimeAgreementResource
    {
        Task<ApiResponse<TimeAgreement>> GetByName(string name);

        Task<ApiResponse<List<TimeAgreement>>> Get(OData odata);

        Task<ApiResponse<TimeAgreement>> Post(TimeAgreement timeAgreement);

        Task<HttpResponseMessage> Patch(string name, TimeAgreement timeAgreement);

        Task<HttpResponseMessage> Delete(string name);
    }
}