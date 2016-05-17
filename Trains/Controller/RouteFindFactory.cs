using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trains.Model;

namespace Trains.Controller
{
    public class RouteFindFactory
    {
        //private static routefindfactory instance;

        //private routefindfactory()
        //{ }

        //public static routefindfactory getinstance()
        //{
        //    if (instance == null)
        //    {
        //        instance = new routefindfactory();
        //    }
        //    return instance;
        //}

        public static DirectRouteController CreateRouteControl(FindRouteType type)
        {
            DirectRouteController routeControl = null;
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
                    routeControl = new DirectRouteController();
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
