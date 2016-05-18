using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trains
{
    /// <summary>  
    /// ClassName:RouteFindFactory  
    /// Version:1.0  
    /// Date:2016/05/17  
    /// Author:Dong Zhao  
    /// </summary>  
    /// <remarks>  
    /// This class used to create the correct route route distance.  
    /// </remarks> 
    public class RouteFindFactory
    {

        /// <summary>  
        /// Public function used to create the correct find route distance.
        /// </summary>  
        /// <param type="FindRouteType" name="type">Find route type, used to determine the route instance.</param>
        /// <returns type="IGetMatchRoutes">Return the correct find route distance.</returns>
        public static IGetMatchRoutes CreateRouteControl(FindRouteType type)
        {
            IGetMatchRoutes routeControl = null;
            switch (type)
            {
                case FindRouteType.DirectRoute:
                    routeControl = new DirectRouteController();
                    break;
                case FindRouteType.RouteWithMaxStops:
                    routeControl = new RouteWithMaxStopsController();
                    break;
                case FindRouteType.RouteWithExactlyStops:
                    routeControl = new RouteWithExactlyStopsController();
                    break;
                case FindRouteType.LengthOfShortestRoute:
                    routeControl = new LengthOfShortestRouteController();
                    break;
                case FindRouteType.NumberOfRoutesLimitDistance:
                    routeControl = new NumberOfRoutesLimitDistanceController();
                    break;
                default:
                    break;
            }
            return routeControl;
        }
    }
}
