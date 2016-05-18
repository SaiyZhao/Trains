using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trains
{
    /// <summary>  
    /// StructName:RouteModel  
    /// Version:1.0  
    /// Date:2016/05/17  
    /// Author:Dong Zhao  
    /// </summary>  
    /// <remarks>  
    /// This struct used to determine route structure.  
    /// </remarks> 
    public struct RouteModel
    {
        private char _startTown;

        public char StartTown
        {
            get { return _startTown; }
            set { _startTown = value; }
        }

        private char _endTown;

        public char EndTown
        {
            get { return _endTown; }
            set { _endTown = value; }
        }

        private string _routes;

        public string Routes
        {
            get { return _routes; }
            set { _routes = value; }
        }

        private int _distance;

        public int Distance
        {
            get { return _distance; }
            set { _distance = value; }
        }

        private int _count;

        public int Count
        {
            get { return _count; }
            set { _count = value; }
        }

        public RouteModel(char startTown, char endTown, string routes, int distance, int count)
        {
            this._startTown = startTown;
            this._endTown = endTown;
            this._routes = routes;
            this._distance = distance;
            this._count = count;
        }
    }
}
