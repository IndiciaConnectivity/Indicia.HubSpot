using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.Serialization;

namespace Indicia.HubSpot.Core.Crud.Dto
{
    [DataContract]
    public class ObjectApiResult
    {
        [DataMember(Name = "properties")]
        public Dictionary<string, object> Properties { get; set; } = new Dictionary<string, object>(); // Not an IDictionary, since the deserialization does not like that.
        
        [DataMember(Name = "id")]
        public string Id { get; set; }
        
        [DataMember(Name = "createdAt")]
        public DateTimeOffset CreatedAt { get; set; }
        
        [DataMember(Name = "archived")]
        public bool Archived { get; set; }
        
        [DataMember(Name = "updatedAt")]
        public DateTimeOffset UpdatedAt { get; set; }

        public T ToHubSpotObject<T>()
            where T : IHubSpotObject, new()
        {
            var result = new T();
            var resultProperties = result.GetType().GetProperties();

            foreach (var prop in resultProperties)
            {
                var memberAttrib = prop.GetCustomAttribute(typeof(DataMemberAttribute)) as DataMemberAttribute;

                if (memberAttrib == null || prop.SetMethod == null || !Properties.ContainsKey(memberAttrib.Name))
                    continue;

                var propValue = Deserialize(Properties[memberAttrib.Name], prop.PropertyType);
                prop.SetValue(result, propValue);
            }

            result.Id = Id;

            return result;
        }

        private static object Deserialize(object inputObj, Type propertyType)
        {
            var conv = TypeDescriptor.GetConverter(propertyType);

            if (inputObj != null && propertyType == inputObj.GetType())
            {
                return inputObj;
            }
            
            if (!(inputObj is string valueAsString) || string.IsNullOrEmpty(valueAsString))
                return null;

            return conv.ConvertFromInvariantString(valueAsString);
        }
    }
}