using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trains
{
    /// <summary>  
    /// EnumName:FindRouteType  
    /// Version:1.0  
    /// Date:2016/05/17  
    /// Author:Dong Zhao  
    /// </summary>  
    /// <remarks>  
    /// This enum used to determine the find route types.  
    /// </remarks> 
    public enum FindRouteType 
    {
        DirectRoute,
        RouteWithMaxStops,
        RouteWithExactlyStops,
        LengthOfShortestRoute,
        NumberOfRoutesLimitDistance        
    }
}
