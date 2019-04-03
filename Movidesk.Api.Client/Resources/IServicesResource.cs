using Movidesk.Api.Client.Http;
using Movidesk.Api.Client.Models;
using Movidesk.Api.Client.Utils;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Movidesk.Api.Client.Resources
{
    /// <summary>
    /// Interface to call Movidesk API of services.
    /// <see cref="https://atendimento.movidesk.com/kb/pt-br/article/7440"/>
    /// </summary>
    public interface IServicesResource
    {
        /// <summary>
        /// Returns a service by id.
        /// </summary>
        /// <param name="id">id of service</param>
        /// <returns>Service</returns>
        Task<ApiResponse<Service>> GetById(int id);

        /// <summary>
        /// Returns a list of service. You can use <paramref name="odata"/> to filter the request.
        /// </summary>
        /// <param name="odata">filter request</param>
        /// <returns>List of services</returns>
        Task<ApiResponse<List<Service>>> Get(OData odata = null);

        /// <summary>
        /// Post (Create) a service. Return only the ID created.
        /// You can use <paramref name="returnAllProperties"/> to return all properties of Service.
        /// </summary>
        /// <param name="service"></param>
        /// <param name="returnAllProperties"></param>
        /// <returns></returns>
        Task<ApiResponse<Service>> Post(Service service, bool returnAllProperties = false);

        /// <summary>
        /// Patch (Update) a service. You should only fill the properties you wish to update.
        /// </summary>
        /// <param name="id">id of service</param>
        /// <param name="service">properties to update</param>
        /// <returns>Message from server</returns>
        Task<HttpResponseMessage> Patch(int id, Service service);

        /// <summary>
        /// Deletes a service by ID.
        /// </summary>
        /// <param name="id">id to delete</param>
        /// <returns>Message from server</returns>
        Task<HttpResponseMessage> Delete(int id);
    }
}