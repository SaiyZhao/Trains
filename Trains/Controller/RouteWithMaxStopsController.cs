using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trains
{
    /// <summary>  
    /// ClassName:RouteWithMaxStopsController  
    /// Version:1.0  
    /// Date:2016/05/17  
    /// Author:Dong Zhao  
    /// </summary>  
    /// <remarks>  
    /// This class used to get the number of routes which stops less than the max stops.  
    /// </remarks> 
    public class RouteWithMaxStopsController : IGetMatchRoutes
    {
        /// <summary>  
        /// Public function used to count the route number which stops less than the max stops.
        /// </summary>  
        /// <param type="RouteModel" name="initialRoute">Initial RouteModel instance, contains conditions.</param>
        /// <param type="int" name="exactlyStops">Exacrly distance value, should be 0 in the first call.</param>
        /// <param type="TownsModel" name="townRoutes">Initial TownsModel instance, contains RoutesGraphs and LimitRouteDepth</param>
        /// <returns type="int">Return the number of the matched routes.</returns>
        public int GetResult(RouteModel initialRoute, int maxStops, TownsModel townRoutes)
        {
            //If the stops exceed max stops, stop recursion
            if (maxStops < 0)
            {
                return initialRoute.Count;
            }
            else
            {
                //Find the matched route, add count.
                if (maxStops >= 0 && initialRoute.StartTown == initialRoute.EndTown && initialRoute.Routes.Length > 0)
                {
                    //Print matched route.
                    Console.WriteLine("Match route '{0}', distance is {1}", initialRoute.Routes + initialRoute.StartTown, initialRoute.Distance);
                    initialRoute.Count++;
                }
                if (townRoutes.RouteGraphs.ContainsKey(initialRoute.StartTown))
                {
                    initialRoute.Routes += initialRoute.StartTown;
                    foreach (KeyValuePair<char, int> dic in townRoutes.RouteGraphs[initialRoute.StartTown])
                    {
                        initialRoute.StartTown = dic.Key;
                        initialRoute.Distance += dic.Value;
                        //Use recursion
                        initialRoute.Count = GetResult(initialRoute, maxStops - 1, townRoutes);

                        initialRoute.Distance -= dic.Value;
                    }
                }
            }

            return initialRoute.Count;
        }
    }
}
