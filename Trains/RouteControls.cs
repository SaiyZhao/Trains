using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Text.RegularExpressions;

namespace Trains
{
    /// <summary>  
    /// ClassName:RouteControls  
    /// Version:1.0  
    /// Date:2016/05/10  
    /// Author:Dong Zhao  
    /// </summary>  
    /// <remarks>  
    /// This class used to provide route control functions.  
    /// </remarks>  
    public class RouteControls
    {     
        /// <summary>  
        /// Private variable, save whole route graphs.
        /// </summary>  
        private Dictionary<char, Dictionary<char, int>> _routeGraphs;
        
        /// <summary>  
        /// Route graphs attribute.
        /// </summary>  
        /// <value>  
        /// Readonly attribute. Return route graphs dictionary.
        /// </value>  
        public Dictionary<char, Dictionary<char, int>> RouteGraphs
        {
            get { return _routeGraphs; }
        }

        /// <summary>  
        /// Private variable, save limit route depth value.
        /// </summary>  
        private int _limitRouteDepth;

        /// <summary>  
        /// Limit route depth attribute.
        /// </summary>  
        /// <value>  
        /// Return limit route depth.
        /// </value>  
        public int LimitRouteDepth
        {
            get { return _limitRouteDepth; }
            set { _limitRouteDepth = value; }
        }

        /// <summary>  
        /// Default constructor
        /// </summary>  
        /// <param></param>   
        public RouteControls()
        {
            _routeGraphs = new Dictionary<char, Dictionary<char, int>>();
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
            foreach(char key in RouteGraphs.Keys)
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
            else if(!RouteGraphs[fromTown].ContainsKey(toTown))
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

        /// <summary>  
        /// Public function used to count the distance of  route list.
        /// </summary>  
        /// <param type="string" name="route">The route list need to count the distance.</param>
        /// <returns type="int">Return the distance of the whole route.</returns>
        public int GetRouteDistance(string route)
        {
            int totalRoute = 0;
            for (int i = 0; i < route.Length - 1; i++)
            {
                if (RouteGraphs.Count < 1 || !RouteGraphs.ContainsKey(route[i]) || !RouteGraphs[route[i]].ContainsKey(route[i + 1]))
                {
                    return -1;
                }
                else 
                {
                    totalRoute += RouteGraphs[route[i]][route[i + 1]];
                }
            }

            return totalRoute;
        }


        /// <summary>  
        /// Public function used to count the route number which stops less than the max stops.
        /// </summary>  
        /// <param type="char" name="startTown">Start town value.</param>
        /// <param type="char" name="endTown">End town value.</param>
        /// <param type="int" name="maxStops">Max stops value.</param>
        /// <param type="string" name="routes">Route path, should be "" in the first call.</param>
        /// <param type="int" name="distance">Distance of the route path, should be 0 in the first call.</param>
        /// <param type="int" name="counts">Number of the matched routes, should be 0 in the first call.</param>
        /// <returns type="int">Return the number of the matched routes.</returns>
        public int GetRouteWithMaxStops(char startTown, char endTown, int maxStops, string routes, int distance, int counts)
        {
            if (maxStops < 0)
            {
                return counts;
            }
            else
            {
                if (maxStops >= 0 && startTown == endTown && routes.Length > 0)
                {
                    //Print matched route.
                    Console.WriteLine("Match route '{0}', distance is {1}", routes + startTown, distance);
                    counts++;
                }
                if (RouteGraphs.ContainsKey(startTown))
                {
                    routes += startTown;
                    foreach (KeyValuePair<char, int> dic in RouteGraphs[startTown])
                    {
                        //Use recursion
                        counts = GetRouteWithMaxStops(dic.Key, endTown, maxStops - 1, routes, distance + dic.Value, counts);
                    }
                }
            }

            return counts;
        }

        /// <summary>  
        /// Public function used to count the route number which stops match the exactly stops.
        /// </summary>  
        /// <param type="char" name="startTown">Start town value.</param>
        /// <param type="char" name="endTown">End town value.</param>
        /// <param type="int" name="maxStops">Exactly stops value.</param>
        /// <param type="string" name="routes">Route path, should be "" in the first call.</param>
        /// <param type="int" name="distance">Distance of the route path, should be 0 in the first call.</param>
        /// <param type="int" name="counts">Number of the matched routes, should be 0 in the first call.</param>
        /// <returns type="int">Return the number of the matched routes.</returns>
        public int GetRoutesWithExactlyStops(char startTown, char endTown, int exactlyStops, string routes, int distance, int counts)
        {
            if (exactlyStops < 0)
            {
                return counts;
            }
            else
            {
                if (exactlyStops == 0 && startTown == endTown && routes.Length > 0)
                {
                    //Print matched route.
                    Console.WriteLine("Match route '{0}', distance is {1}", routes + startTown, distance);
                    counts++;
                }

                if (RouteGraphs.ContainsKey(startTown))
                {
                    routes += startTown;
                    foreach (KeyValuePair<char, int> dic in RouteGraphs[startTown])
                    {
                        //Use recursion
                        counts = GetRoutesWithExactlyStops(dic.Key, endTown, exactlyStops - 1, routes, distance + dic.Value, counts);
                    }
                }
            }

            return counts;
        }

        /// <summary>  
        /// Public function used to count shortest route between two towns.
        /// </summary>  
        /// <param type="char" name="startTown">Start town value.</param>
        /// <param type="char" name="endTown">End town value.</param>
        /// <param type="int" name="shortestDistance">Shortest distance value, should be 0 in the first call.</param>
        /// <param type="string" name="routes">Route path, should be "" in the first call.</param>
        /// <param type="int" name="distance">Distance of the route path, should be 0 in the first call.</param>
        /// <returns type="int">Return the shortest distance value.</returns>
        public int GetLengthOfShortestRoute(char startTown, char endTown, int shortestDistance, string routes, int distance)
        {
            if (routes.Length > LimitRouteDepth)
            {
                return shortestDistance;
            }
            if (distance > 0 && startTown == endTown)
            {
                if (shortestDistance == 0 || distance < shortestDistance)
                {
                    shortestDistance = distance;
                }
                return shortestDistance;
            }
            else
            {
                if (shortestDistance > 0 && distance > shortestDistance)
                {
                    return shortestDistance;
                }
                else
                {
                    if (RouteGraphs.ContainsKey(startTown))
                    {
                        routes += startTown;
                        foreach (KeyValuePair<char, int> dic in RouteGraphs[startTown])
                        {
                            //Use recursion
                            shortestDistance = GetLengthOfShortestRoute(dic.Key, endTown, shortestDistance, routes, distance + dic.Value);
                        }
                    }
                }
            }
            return shortestDistance;
        }


        /// <summary>  
        /// Public function used to count the route number which total distance less than the limit distance.
        /// </summary>  
        /// <param type="char" name="startTown">Start town value.</param>
        /// <param type="char" name="endTown">End town value.</param>
        /// <param type="int" name="limitDistance">Limit disatance value.</param>
        /// <param type="string" name="routes">Route path, should be "" in the first call.</param>
        /// <param type="int" name="distance">Distance of the route path, should be 0 in the first call.</param>
        /// <param type="int" name="counts">Number of the matched routes, should be 0 in the first call.</param>
        /// <returns type="int">Return the number of the matched routes.</returns>
        public int GetNumberOfRoutesLimitDistance(char startTown, char endTown, int limitDistance, string routes, int distance, int counts)
        {
            if (distance > limitDistance)
            {
                return counts;
            }
            else
            {
                if (distance < limitDistance && startTown == endTown && routes.Length > 0)
                {
                    //Print matched route.
                    Console.WriteLine("Match route is '{0}', distance is {1}", routes + startTown, distance);
                    counts++;
                }

                if (RouteGraphs.ContainsKey(startTown))
                {
                    routes += startTown;
                    foreach (KeyValuePair<char, int> dic in RouteGraphs[startTown])
                    {
                        //Use recursion
                        counts = GetNumberOfRoutesLimitDistance(dic.Key, endTown, limitDistance, routes, distance + dic.Value, counts);
                    }
                }
            }

            return counts;
        }
    }
}

