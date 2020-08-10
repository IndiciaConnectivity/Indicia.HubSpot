using System.Runtime.Serialization;

namespace Indicia.HubSpot.Core.Batch.Dto
{
    [DataContract]
    public class BatchUpdateResult<T> : BatchResultsResult<T>
        where T : IHubSpotObject, new()
    {
        
    }
}