using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace Indicia.HubSpot.Core
{
    public abstract partial class HubSpotObjectApi<T> : ApiRoutable, IHubSpotObjectApi<T>
        where T : class, IHubSpotObject, new()
    {
        private readonly IHubSpotClient _client;
        
        protected abstract string EntityRoute { get; }
        protected override string MidRoute => $"/crm/v3/objects{EntityRoute}";

        protected HubSpotObjectApi(IHubSpotClient client)
        {
            _client = client;
        }

        public IEnumerable<string> AllProperties => typeof(T).GetProperties()
            .Select(p => p.GetCustomAttribute<DataMemberAttribute>())
            .Where(a => a != null)
            .Select(a => a.Name);

        // The main functionality of this class is in the partials (Associations, Crud, Batch, Search)
    }
}