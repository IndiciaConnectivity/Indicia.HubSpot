using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Indicia.HubSpot.Core.Search.Dto
{
    [DataContract]
    public class SearchParameters
    {
        [DataMember(Name = "sorts")]
        public IEnumerable<string> Sorts { get; set; }

        [DataMember(Name = "properties")]
        public IEnumerable<string> Properties { get; set; }
        
        [DataMember(Name = "limit")]
        public int? Limit { get; set; }
        
        [DataMember(Name = "after")]
        public string After { get; set; }

        [DataMember(Name = "query")]
        public string Query { get; set; }
        
        [DataMember(Name = "filterGroups")]
        public IEnumerable<FilterGroup> FilterGroups { get; set; }
        
        [DataContract]
        public class Filter
        {
            [DataMember(Name = "propertyName")]
            public string PropertyName { get; set; }

            [DataMember(Name = "operator")]
            public FilterOperator Operator { get; set; }
        
            [DataMember(Name = "value")]
            public string Value { get; set; }
        }

        [DataContract]
        public enum FilterOperator
        {
            [EnumMember(Value = "EQ")]
            EqualTo,
            
            [EnumMember(Value = "NEQ")]
            NotEqualTo,
            
            [EnumMember(Value = "LT")]
            LessThan,
            
            [EnumMember(Value = "LTE")]
            LessThanOrEqualTo,
            
            [EnumMember(Value = "GT")]
            GreaterThan,
            
            [EnumMember(Value = "GTE")]
            GreaterThanOrEqualTo,
            
            [EnumMember(Value = "HAS_PROPERTY")]
            HasPropertyValue,
            
            [EnumMember(Value = "NOT_HAS_PROPERTY")]
            DoesNotHavePropertyValue,
            
            [EnumMember(Value = "CONTAINS_TOKEN")]
            ContainsToken,
            
            [EnumMember(Value = "NOT_CONTAINS_TOKEN")]
            DoesNotContainToken
        }
        
        [DataContract]
        public class FilterGroup
        {
            [DataMember(Name = "filters")]
            public IEnumerable<Filter> Filters { get; set; }
        }
    }
}