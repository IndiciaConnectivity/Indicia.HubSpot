using System;
using System.Collections.Generic;
using System.Linq;

namespace Indicia.HubSpot.Core
{
    public abstract class ApiRoutable
    {
        /// <summary>
        ///     The route to the HubSpot API appended directly after the base URI
        /// </summary>
        protected virtual string MidRoute { get; set; } = string.Empty;

        /// <summary>
        ///     Dictionary of Entity specific routes to be accessed by entity type
        /// </summary>                
        protected virtual Dictionary<Type, string> Routes { get; set; } = new Dictionary<Type, string>();

        /// <summary>
        ///     Provides the route to an endpoint relative to the specified type key.
        /// </summary>
        /// <typeparam name="T">The IHubSpotModel-based type key used for the route.</typeparam>
        /// <returns>The full route for the DTO without parameters</returns>
        public virtual string GetRoute<T>()
            where T : IHubSpotObject
        {
            var routeValue = TryGetRouteValue<T>();
            return $"{MidRoute.TrimEnd('/')}/{routeValue.TrimStart('/')}";
        }

        /// <summary>
        /// Provides the route to the midroute endpoint for the DTO group.
        /// This should be used when there is no need to add any parameters
        /// </summary>
        /// <returns>The cleaned midroute</returns>
        public virtual string GetRoute() 
            => $"{MidRoute.TrimEnd('/')}";

        /// <summary>
        /// Provides the route to the midroute endpoint for the DTO group,
        /// including the route parameters
        /// </summary>
        /// <param name="param"></param>
        /// <returns>The full route for the request</returns>
        public virtual string GetRoute(params string[] orderedRouteValues)
        {
            var orderValuesFiltered = FilterRouteValues(orderedRouteValues);
            var combinedParams = string.Join("/", orderValuesFiltered);
            return $"{GetRoute()}/{combinedParams}";
        }

        /// <summary>
        /// Combines the parameters provided into a full URI with separating '/' characters.
        /// </summary>
        /// <typeparam name="T">The IHubSpotModel-based type key used for the route.</typeparam>
        /// <param name="orderedRouteValues">One or more route parameters to be combined, sans</param>
        /// <returns>The full route for the request</returns>
        public virtual string GetRoute<T>(params string[] orderedRouteValues)
            where T : IHubSpotObject
        {
            var orderValuesFiltered = FilterRouteValues(orderedRouteValues);
            var combinedParams = string.Join("/", orderValuesFiltered);
            return $"{GetRoute<T>().TrimEnd('/')}/{combinedParams}";
        }

        /// <summary>
        /// Maps a specialized route to a target type and adds the mapping 
        /// the consuming API's route dictionary 
        /// </summary>
        /// <typeparam name="T">The target type to be used on this route</typeparam>
        /// <param name="newRoute">The specialized route to be mapped</param>
        public void AddRoute<T>(string newRoute)
            where T : IHubSpotObject 
            => Routes.Add(typeof(T), newRoute);

        protected string GetAssociationRoute<T>(IHubSpotObject fromObject, IHubSpotObject toObject)
            where T : IHubSpotObject
        {
            return GetRoute<T>(fromObject.Id, "associations", toObject.ObjectType,
                toObject.Id, $"{fromObject.ObjectType}_to_{toObject.ObjectType}");
        }

        protected string GetAssociationRoute<T, TAssoc>(IHubSpotObject fromObject)
            where T : IHubSpotObject
            where TAssoc : IHubSpotObject
        {
            var toObject = Activator.CreateInstance<TAssoc>();
            return GetRoute<T>(fromObject.Id, "associations", toObject.ObjectType);
        }
        
        /// <summary>
        /// Cleans the provided strings to not have any leading or training '/'s
        /// </summary>
        /// <param name="values">The string values to be cleaned</param>
        /// <returns>An array of cleaned string parameters</returns>
        private string[] FilterRouteValues(string[] values)
            => values?.Select(x => x.Trim('/')).ToArray() ?? new string[0];

        /// <summary>
        /// Reads through the DTO's route table to see if there is a specialized route for the target type
        /// </summary>
        /// <typeparam name="T">Target DTO type</typeparam>
        /// <returns>The specialized route for the DTO type or <see cref="string.Empty"/></returns>
        private string TryGetRouteValue<T>()
            where T : IHubSpotObject 
            => Routes.ContainsKey(typeof(T)) ? Routes[typeof(T)] : string.Empty;
    }
}
