using Movidesk.Api.Client.Http;
using Movidesk.Api.Client.Models;
using Movidesk.Api.Client.Utils;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Movidesk.Api.Client.Resources
{
    /// <summary>
    /// Interface to call Movidesk API of persons.
    /// <see cref="https://atendimento.movidesk.com/kb/pt-br/article/189/"/>
    /// </summary>
    public interface IPersonResource
    {
        /// <summary>
        /// Returns a person by id
        /// </summary>
        /// <param name="id">id of person</param>
        /// <returns>Person</returns>
        Task<ApiResponse<Person>> GetById(string id);

        /// <summary>
        /// Return a list of person. Can use OData to filter the request
        /// </summary>
        /// <param name="odata">filter</param>
        /// <returns>List of person</returns>
        Task<ApiResponse<List<Person>>> Get(OData odata = null);

        /// <summary>
        /// Post (Create) a person. Return only the ID created.
        /// You can use <paramref name="returnAllProperties"/> to return all properties of Person.
        /// </summary>
        /// <param name="person">person to create</param>
        /// <param name="returnAllProperties">fill the return person</param>
        /// <returns>Person</returns>
        Task<ApiResponse<Person>> Post(Person person, bool returnAllProperties = false);

        /// <summary>
        /// Patch (Update) a person. You should only fill the properties you wish to update.
        /// </summary>
        /// <param name="id">id of person</param>
        /// <param name="person">properties to update</param>
        /// <returns>Message from server</returns>
        Task<HttpResponseMessage> Patch(string id, Person person);

        /// <summary>
        /// Delete a person by ID.
        /// </summary>
        /// <param name="id">id person to delete</param>
        /// <returns>Message from server</returns>
        Task<HttpResponseMessage> Delete(string id);
    }
}