namespace Indicia.HubSpot.Core.Parameters
{
    /// <summary>
    /// Marker interface to allow the GetQueryParameters extension method.
    /// Don't let the individual interfaces inherit from this. Let the contexts themselves inherit from this instead.
    /// This is because not all parameters are query parameters.
    /// </summary>
    public interface IQueryParameters
    {
    }
}