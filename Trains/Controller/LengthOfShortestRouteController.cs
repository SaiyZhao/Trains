using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trains
{
    /// <summary>  
    /// ClassName:LengthOfShortestRouteController  
    /// Version:1.0  
    /// Date:2016/05/17  
    /// Author:Dong Zhao  
    /// </summary>  
    /// <remarks>  
    /// This class used to get the shortest route  
    /// </remarks> 
    public class LengthOfShortestRouteController : IGetMatchRoutes
    {
        /// <summary>  
        /// Public function used to count shortest route between two towns.
        /// </summary>  
        /// <param type="RouteModel" name="initialRoute">Initial RouteModel instance, contains conditions.</param>
        /// <param type="int" name="shortestDistance">Shortest distance value, should be 0 in the first call.</param>
        /// <param type="TownsModel" name="townRoutes">Initial TownsModel instance, contains RoutesGraphs and LimitRouteDepth</param>
        /// <returns type="int">Return the shortest distance value.</returns>
        public int GetResult(RouteModel initialRoute, int shortestDistance, TownsModel townRoutes)
        {
            //If the routes length exceed the limit route depth, stop recursion.
            if (initialRoute.Routes.Length > townRoutes.LimitRouteDepth)
            {
                return shortestDistance;
            }
            //Find the matched route, save the shortest value.
            if (initialRoute.Distance > 0 && initialRoute.StartTown == initialRoute.EndTown)
            {
                if (shortestDistance == 0 || initialRoute.Distance < shortestDistance)
                {
                    shortestDistance = initialRoute.Distance;
                }
                return shortestDistance;
            }
            else
            {
                //If the current distance exceed the saved shortest distance, stop recursion.
                if (shortestDistance > 0 && initialRoute.Distance > shortestDistance)
                {
                    return shortestDistance;
                }
                else
                {
                    if (townRoutes.RouteGraphs.ContainsKey(initialRoute.StartTown))
                    {
                        initialRoute.Routes += initialRoute.StartTown;
                        foreach (KeyValuePair<char, int> dic in townRoutes.RouteGraphs[initialRoute.StartTown])
                        {
                            initialRoute.StartTown = dic.Key;
                            initialRoute.Distance += dic.Value;
                            //Use recursion
                            shortestDistance = GetResult(initialRoute, shortestDistance, townRoutes);

                            initialRoute.Distance -= dic.Value;
                        }
                    }
                }
            }
            return shortestDistance;
        }
    }
}
