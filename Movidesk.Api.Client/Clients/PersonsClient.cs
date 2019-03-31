using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Movidesk.Api.Client.Http;
using Movidesk.Api.Client.Models;
using Movidesk.Api.Client.Utils;

namespace Movidesk.Api.Client.Clients
{
    /// <summary>
    /// Class to call Movidesk API of persons.
    /// https://atendimento.movidesk.com/kb/pt-br/article/189/
    /// </summary>
    public class PersonsClient : MovideskApiClient
    {
        private Dictionary<string, string> _odata = new Dictionary<string, string>();

        public PersonsClient(MovideskApiClientOptions options) : base(options, "/persons")
        {
        }

        public async Task<ApiResponse<Person>> Get(string id)
        {
            var result = await base.Get<Person>($"&id={id}");
            return result;
        }

        public async Task<ApiResponse<List<Person>>> Get(OData odata = null)
        {   
            var result = await base.Get<List<Person>>(odata?.ToString());
            return result;
        }

        public async Task<ApiResponse<Person>> Post(Person person, bool returnAllProperties = false)
        {
            var result = await base.Post<Person>($"&returnAllProperties={returnAllProperties}", person);
            return result;
        }

        public async Task<HttpResponseMessage> Patch(int id, object person)
        {
            var result = await Patch($"&id={id}", person);
            return result;
        }

        public new async Task<HttpResponseMessage> Delete(int id)
        {
            var result = await base.Delete(id);
            return result;
        }
    }
}
