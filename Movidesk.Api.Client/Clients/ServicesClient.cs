using Movidesk.Api.Client.Http;
using Movidesk.Api.Client.Models;
using Movidesk.Api.Client.Utils;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Movidesk.Api.Client.Clients
{
    /// <summary>
    /// Class to call Movidesk API of Services.
    /// https://atendimento.movidesk.com/kb/pt-br/article/7440
    /// </summary>
    public class ServicesClient : MovideskApiClient
    {
        public ServicesClient(MovideskApiClientOptions options) : base(options, "/services")
        {
        }

        /// <summary>
        /// Get a single service
        /// </summary>
        /// <param name="id">id o service</param>
        /// <returns>a service</returns>
        public async Task<ApiResponse<Service>> Get(int id)
        {
            var result = await Get<Service>($"&id={id}");
            return result;
        }

        /// <summary>
        /// Get a list of service
        /// </summary>
        /// <returns>list of service</returns>
        public async Task<ApiResponse<List<Service>>> Get(OData odata = null)
        {
            var result = await Get<List<Service>>(odata?.ToString());
            return result;
        }

        /// <summary>
        /// Post a new service
        /// </summary>
        /// <param name="service">service to create</param>
        /// <param name="returnAllProperties">return complete service or only ID</param>
        /// <returns></returns>
        public async Task<ApiResponse<Service>> Post(Service service, bool returnAllProperties = false)
        {
            var result = await Post<Service>($"&returnAllProperties={returnAllProperties}", service);
            return result;
        }

        /// <summary>
        /// Update a service. You should use an anonymous class to update the service.
        /// Usage: await Patch(1, new { name = "thename" });
        /// </summary>
        /// <param name="id">id service to update</param>
        /// <param name="service">the service object</param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> Patch(int id, Service service)
        {
            var result = await Patch($"&id={id}", service);
            return result;
        }

        /// <summary>
        /// Delete a service
        /// </summary>
        /// <param name="id">service id to delete</param>
        /// <returns></returns>
        public new async Task<HttpResponseMessage> Delete(int id)
        {
            var result = await base.Delete(id);
            return result;
        }
    }
}