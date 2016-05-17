using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trains.Model;

namespace Trains.Controller
{
    public class LengthOfShortestRouteController : DirectRouteController
    {
        /// <summary>  
        /// Public function used to count shortest route between two towns.
        /// </summary>  
        /// <param type="RouteModel" name="initialRoute">Initial RouteModel instance, contains conditions.</param>
        /// <param type="int" name="shortestDistance">Shortest distance value, should be 0 in the first call.</param>
        /// <param type="TownsModel" name="townRoutes">Initial TownsModel instance, contains RoutesGraphs and LimitRouteDepth</param>
        /// <returns type="int">Return the shortest distance value.</returns>
        public override int GetResult(RouteModel initialRoute, int shortestDistance, TownsModel townRoutes)
        {
            if (initialRoute.Routes.Length > townRoutes.LimitRouteDepth)
            {
                return shortestDistance;
            }
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
                        }
                    }
                }
            }
            return shortestDistance;
        }
    }
}
