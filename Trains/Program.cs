using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Trains.Model;
using Trains.Controller;

namespace Trains
{    
    /// <summary>  
    /// ClassName:Program  
    /// Version:1.0  
    /// Date:2016/05/10  
    /// Author:Dong Zhao  
    /// </summary>  
    /// <remarks>  
    /// Default class.  
    /// </remarks>  
    public class Program
    {        
        /// <summary>  
        /// Public static variable, route controls class instance.
        /// </summary>  
        public static RouteControls routeControls;

        /// <summary>  
        /// The main function  
        /// </summary>  
        /// <param type="string[]" name="args">Main function arg list</param>  
        static void Main(string[] args)
        {
            try
            {
                ////Initialize routeControls instance
                //routeControls = new RouteControls();
                ////Set route string, should be match fromTown+toTown+distance of each route, use "," to split each route.
                //string routeStr = "AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7";
                //if (routeControls.CreateRouteGraphs(routeStr.ToUpper()))
                //{
                //    Console.WriteLine("1. Start get the distance of the route A-B-C.");
                //    Console.WriteLine("Output #1: {0}.", HandleNoRoute(routeControls.GetRouteDistance("ABC")));
                //    Console.WriteLine();
                //    Console.WriteLine("2. Start get the distance of the route A-D.");
                //    Console.WriteLine("Output #2: {0}.", HandleNoRoute(routeControls.GetRouteDistance("AD")));
                //    Console.WriteLine();
                //    Console.WriteLine("3. Start get the distance of the route A-D-C.");
                //    Console.WriteLine("Output #3: {0}.", HandleNoRoute(routeControls.GetRouteDistance("ADC")));
                //    Console.WriteLine();
                //    Console.WriteLine("4. Start get the distance of the route A-E-B-C-D.");
                //    Console.WriteLine("Output #4: {0}.", HandleNoRoute(routeControls.GetRouteDistance("AEBCD")));
                //    Console.WriteLine();
                //    Console.WriteLine("5. Start get the distance of the route A-E-D.");
                //    Console.WriteLine("Output #5: {0}.", HandleNoRoute(routeControls.GetRouteDistance("AED")));
                //    Console.WriteLine();
                //    Console.WriteLine("6. Start get the number of trips starting at C and ending at C with a maximum of 3 stops.");
                //    Console.WriteLine("Output #6: {0}.", HandleNoRoute(routeControls.GetRouteWithMaxStops('C', 'C', 3, "", 0, 0)));
                //    Console.WriteLine();
                //    Console.WriteLine("7. Start get the number of trips starting at A and ending at C with exactly 4 stops.");
                //    Console.WriteLine("Output #7: {0}.", HandleNoRoute(routeControls.GetRoutesWithExactlyStops('A', 'C', 4, "", 0, 0)));
                //    Console.WriteLine();
                //    Console.WriteLine("8. Start get the length of the shortest route (in terms of distance to travel) from A to C.");
                //    Console.WriteLine("Output #8: {0}.", HandleNoRoute(routeControls.GetLengthOfShortestRoute('A', 'C', 0, "", 0)));
                //    Console.WriteLine();
                //    Console.WriteLine("9. Start get the length of the shortest route (in terms of distance to travel) from B to B.");
                //    Console.WriteLine("Output #9: {0}.", HandleNoRoute(routeControls.GetLengthOfShortestRoute('B', 'B', 0, "", 0)));
                //    Console.WriteLine();
                //    Console.WriteLine("10. Start get the number of different routes from C to C with a distance of less than 30.");
                //    Console.WriteLine("Output #10: {0}.", HandleNoRoute(routeControls.GetNumberOfRoutesLimitDistance('C', 'C', 30, "", 0, 0)));
                //    Console.WriteLine();
                //}

                TownsModel towns = new TownsModel();
                DirectRouteController directRoute = RouteFindFactory.CreateRouteControl(FindRouteType.DirectRoute);
                DirectRouteController routeWithMaxStops = RouteFindFactory.CreateRouteControl(FindRouteType.RouteWithMaxStops);
                DirectRouteController routeWithExactlyStops = RouteFindFactory.CreateRouteControl(FindRouteType.RouteWithExactlyStops);
                DirectRouteController lengthOfShortestRoute = RouteFindFactory.CreateRouteControl(FindRouteType.LengthOfShortestRoute);
                DirectRouteController numberOfRoutesLimitDistance = RouteFindFactory.CreateRouteControl(FindRouteType.NumberOfRoutesLimitDistance);
                //Initialize routeControls instance
                //routeControls = new RouteControls();
                //Set route string, should be match fromTown+toTown+distance of each route, use "," to split each route.
                string routeStr = "AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7";
                if (towns.CreateRouteGraphs(routeStr.ToUpper()))
                {
                    Console.WriteLine("1. Start get the distance of the route A-B-C.");
                    Console.WriteLine("Output #1: {0}.", HandleNoRoute(directRoute.GetResult(new RouteModel(' ', ' ', "ABC", 0, 0), 0, towns)));
                    Console.WriteLine();
                    Console.WriteLine("2. Start get the distance of the route A-D.");
                    Console.WriteLine("Output #2: {0}.", HandleNoRoute(directRoute.GetResult(new RouteModel(' ', ' ', "AD", 0, 0), 0, towns)));
                    Console.WriteLine();
                    Console.WriteLine("3. Start get the distance of the route A-D-C.");
                    Console.WriteLine("Output #3: {0}.", HandleNoRoute(directRoute.GetResult(new RouteModel(' ', ' ', "ADC", 0, 0), 0, towns)));
                    Console.WriteLine();
                    Console.WriteLine("4. Start get the distance of the route A-E-B-C-D.");
                    Console.WriteLine("Output #4: {0}.", HandleNoRoute(directRoute.GetResult(new RouteModel(' ', ' ', "AEBCD", 0, 0), 0, towns)));
                    Console.WriteLine();
                    Console.WriteLine("5. Start get the distance of the route A-E-D.");
                    Console.WriteLine("Output #5: {0}.", HandleNoRoute(directRoute.GetResult(new RouteModel(' ', ' ', "AED", 0, 0), 0, towns)));
                    Console.WriteLine();
                    Console.WriteLine("6. Start get the number of trips starting at C and ending at C with a maximum of 3 stops.");
                    Console.WriteLine("Output #6: {0}.", HandleNoRoute(routeWithMaxStops.GetResult(new RouteModel('C', 'C', "", 0, 0), 3, towns)));
                    Console.WriteLine();
                    Console.WriteLine("7. Start get the number of trips starting at A and ending at C with exactly 4 stops.");
                    Console.WriteLine("Output #7: {0}.", HandleNoRoute(routeWithExactlyStops.GetResult(new RouteModel('A', 'C', "", 0, 0), 4, towns)));
                    Console.WriteLine();
                    Console.WriteLine("8. Start get the length of the shortest route (in terms of distance to travel) from A to C.");
                    Console.WriteLine("Output #8: {0}.", HandleNoRoute(lengthOfShortestRoute.GetResult(new RouteModel('A', 'C', "", 0, 0), 0, towns)));
                    Console.WriteLine();
                    Console.WriteLine("9. Start get the length of the shortest route (in terms of distance to travel) from B to B.");
                    Console.WriteLine("Output #9: {0}.", HandleNoRoute(lengthOfShortestRoute.GetResult(new RouteModel('B', 'B', "", 0, 0), 0, towns)));
                    Console.WriteLine();
                    Console.WriteLine("10. Start get the number of different routes from C to C with a distance of less than 30.");
                    Console.WriteLine("Output #10: {0}.", HandleNoRoute(numberOfRoutesLimitDistance.GetResult(new RouteModel('C', 'C', "", 0, 0), 30, towns)));
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:{0}", ex.ToString());
            }
            finally
            {
                Console.Read();
            }
        }

        /// <summary>  
        /// Public static function, used to check the result is no route or not.
        /// </summary>  
        /// <param type="int" name="result">Result from routeControls funcitons.</param> 
        /// <returns type="bool">Return result string.</returns>
        public static string HandleNoRoute(int result)
        {
            if (result == -1 || result == 0)
            {
                return "NO SUCH ROUTE";
            }
            else
            {
                return result.ToString();
            }
        }
    }
}
