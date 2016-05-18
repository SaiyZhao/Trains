using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trains
{
    /// <summary>  
    /// InterfaceName:IGetMatchRoutes  
    /// Version:1.0  
    /// Date:2016/05/17  
    /// Author:Dong Zhao  
    /// </summary>  
    /// <remarks>  
    /// This interface used to determine the common method structure.  
    /// </remarks> 
    public interface IGetMatchRoutes
    {
        /// <summary>  
        /// Public function used to determine the common method structure.
        /// </summary>  
        /// <param type="RouteModel" name="initialRoute">Initial RouteModel instance, contains conditions.</param>
        /// <param type="int" name="exactlyStops">Useful condition.</param>
        /// <param type="TownsModel" name="townRoutes">Initial TownsModel instance, contains RoutesGraphs and LimitRouteDepth</param>
        /// <returns type="int">Return the needed number.</returns>
        int GetResult(RouteModel initialRoute, int condition, TownsModel townRoutes);
    }
}
