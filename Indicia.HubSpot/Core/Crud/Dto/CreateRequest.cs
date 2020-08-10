using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;

namespace Indicia.HubSpot.Core.Crud.Dto
{
    [DataContract]
    internal class CreateRequest
    {
        public CreateRequest(IHubSpotObject obj)
        {
            var properties = obj.GetType().GetProperties();

            foreach (var prop in properties)
            {
                var memberAttrib = prop.GetCustomAttribute(typeof(DataMemberAttribute)) as DataMemberAttribute;
                var value = prop.GetValue(obj);

                if (value == null || memberAttrib == null)                
                    continue;

                Properties[memberAttrib.Name] = value;
            }
        }

        [DataMember(Name = "properties")]
        public IDictionary<string, object> Properties { get; set; } = new Dictionary<string, object>();
    }
}