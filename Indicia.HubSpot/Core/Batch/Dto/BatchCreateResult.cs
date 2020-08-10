using System.Runtime.Serialization;

namespace Indicia.HubSpot.Core.Batch.Dto
{
    [DataContract]
    public class BatchCreateResult<T> : BatchResultsResult<T>
        where T : IHubSpotObject, new()
    {
        
    }
}