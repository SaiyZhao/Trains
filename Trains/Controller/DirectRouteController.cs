using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trains.Model;

namespace Trains.Controller
{
    public class DirectRouteController
    {
        /// <summary>  
        /// Public function used to count the distance of  route list.
        /// </summary>  
        /// <param type="string" name="route">The route list need to count the distance.</param>
        /// <returns type="int">Return the distance of the whole route.</returns>
        public virtual int GetResult(RouteModel initialRoute, int condition, TownsModel townRoutes)
        {
            string route = initialRoute.Routes;
            int totalRoute = 0;
            for (int i = 0; i < route.Length - 1; i++)
            {
                if (townRoutes.RouteGraphs.Count < 1 || !townRoutes.RouteGraphs.ContainsKey(route[i]) || !townRoutes.RouteGraphs[route[i]].ContainsKey(route[i + 1]))
                {
                    return -1;
                }
                else
                {
                    totalRoute += townRoutes.RouteGraphs[route[i]][route[i + 1]];
                }
            }

            return totalRoute;
        }
    }
}
