using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RestSharp.Serializers;

namespace Indicia.HubSpot.Core.Serializers
{
    internal class NewtonsoftRestSharpSerializer : ISerializer
    {
        private static readonly JsonSerializerSettings SerializerSettings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            Converters = new List<JsonConverter>
            {
                new StringEnumConverter()
            }
        };
        
        public string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.None, SerializerSettings);
        }

        public NewtonsoftRestSharpSerializer()
        {
            ContentType = "application/json";
        }

        /// <summary>
        /// Content type for serialized content
        /// </summary>
        public string ContentType { get; set; }
    }
}
