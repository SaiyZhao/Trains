using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Trains
{
    /// <summary>  
    /// ClassName:TownsModel  
    /// Version:1.0  
    /// Date:2016/05/17  
    /// Author:Dong Zhao  
    /// </summary>  
    /// <remarks>  
    /// This class used to determine the route graphs and the limit route depth of the route graphs.  
    /// </remarks> 
    public class TownsModel
    {
        private Dictionary<char, Dictionary<char, int>> _routeGraphs;

        public Dictionary<char, Dictionary<char, int>> RouteGraphs
        {
            get { return _routeGraphs; }
            set { _routeGraphs = value; }
        }

        private int _limitRouteDepth;

        public int LimitRouteDepth
        {
            get { return _limitRouteDepth; }
            set { _limitRouteDepth = value; }
        }

        public TownsModel()
        {
            RouteGraphs = new Dictionary<char, Dictionary<char, int>>();
        }

        /// <summary>  
        /// Create route graphs function.
        /// </summary>  
        /// <param type="string" name="routeString"> Route list string need to serialize.</param> 
        /// <returns type="bool">Return create result.</returns>
        public bool CreateRouteGraphs(string routeString)
        {
            bool createResult = true;

            foreach (string route in routeString.Split(','))
            {
                string trimRoute = route.Trim();
                //Check the value is valid.
                if (trimRoute.Length == 3 && Regex.IsMatch(trimRoute[0].ToString(), @"[A-Z]") && Regex.IsMatch(trimRoute[1].ToString(), @"[A-Z]") && Regex.IsMatch(trimRoute[2].ToString(), @"[0-9]"))
                {
                    AddRouteGraphs(trimRoute[0], trimRoute[1], Convert.ToInt32(trimRoute[2].ToString()));
                }
                else
                {
                    Console.WriteLine("Create route failed: Invalid route {0}.", trimRoute);
                    return false;
                }
            }

            //Sort sub dictionary, it will save time when found the shortest distance of two town.
            Dictionary<char, Dictionary<char, int>> sortDic = new Dictionary<char, Dictionary<char, int>>();
            foreach (char key in RouteGraphs.Keys)
            {
                sortDic.Add(key, (from p in RouteGraphs[key] orderby p.Value select p).ToDictionary(pair => pair.Key, pair => pair.Value));
            }
            _routeGraphs = sortDic;

            //Set limit route depth, avoid recursive infinite loop.
            SetLimitRouteDepth();

            return createResult;
        }

        /// <summary>  
        /// Private function used to add routes to dictionary.
        /// </summary>  
        /// <param type="char" name="fromTown">From town value.</param> 
        /// <param type="char" name="toTown">To town value.</param> 
        /// <param type="int" name="distance">Distance between two town.</param> 
        /// <returns type="void">Do not need return anything.</returns>
        private void AddRouteGraphs(char fromTown, char toTown, int distance)
        {
            Dictionary<char, int> dicToTown = new Dictionary<char, int>();
            dicToTown.Add(toTown, distance);
            if (!RouteGraphs.ContainsKey(fromTown))
            {
                RouteGraphs.Add(fromTown, dicToTown);
            }
            else if (!RouteGraphs[fromTown].ContainsKey(toTown))
            {
                RouteGraphs[fromTown].Add(toTown, distance);
            }
            else
            {
                RouteGraphs[fromTown][toTown] = distance;
            }
        }

        /// <summary>  
        /// Private function used to set the limit route depth value, this value used in shortest route found function.
        /// </summary>  
        /// <param></param> 
        /// <returns type="void">Do not need return anything.</returns>
        private void SetLimitRouteDepth()
        {
            LimitRouteDepth = 1;
            if (RouteGraphs.Count > 0)
            {
                foreach (Dictionary<char, int> route in RouteGraphs.Values)
                {
                    LimitRouteDepth *= route.Count;
                }
            }
        }
    }


}
