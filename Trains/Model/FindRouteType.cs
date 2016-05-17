using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trains.Model
{
    public enum FindRouteType 
    {
        DirectRoute,
        RouteWithMaxStops,
        RouteWithExactlyStops,
        LengthOfShortestRoute,
        NumberOfRoutesLimitDistance        
    }
}
