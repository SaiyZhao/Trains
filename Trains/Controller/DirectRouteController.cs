using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trains
{
    /// <summary>  
    /// ClassName:DirectRouteController  
    /// Version:1.0  
    /// Date:2016/05/17
    /// Author:Dong Zhao  
    /// </summary>  
    /// <remarks>  
    /// This class used to get distance of direct route.  
    /// </remarks>  
    public class DirectRouteController : IGetMatchRoutes
    {
        /// <summary>  
        /// Public function used to count the distance of route list.
        /// </summary>  
        /// <param type="RouteModel" name="initialRoute">Initial RouteModel instance, contains conditions.</param>
        /// <param type="int" name="condition">Condition value, should be 0 cause didn't use here.</param>
        /// <param type="TownsModel" name="townRoutes">Initial TownsModel instance, contains RoutesGraphs and LimitRouteDepth</param>
        /// <returns type="int">Return the distance of the whole route.</returns>
        public int GetResult(RouteModel initialRoute, int condition, TownsModel townRoutes)
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
