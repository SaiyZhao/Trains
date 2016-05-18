using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trains.Tests
{
    [TestClass()]
    public class LengthOfShortestRouteTests
    {
        private TownsModel _towns;
        public TownsModel Towns
        {
            get
            {
                return _towns;
            }

            set
            {
                _towns = value;
            }
        }

        private IGetMatchRoutes _Route;
        public IGetMatchRoutes Route
        {
            get
            {
                return _Route;
            }

            set
            {
                _Route = value;
            }
        }

        public LengthOfShortestRouteTests()
        {
            Towns = new TownsModel();
            string routeStr = "AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7";
            Towns.CreateRouteGraphs(routeStr.ToUpper());

            Route = RouteFindFactory.CreateRouteControl(FindRouteType.LengthOfShortestRoute);
        }

        [TestMethod()]
        public void ShortestRouteWithCorrectValueTest()
        {
            RouteModel route = new RouteModel('B', 'B', "", 0, 0);
            int expected = 9;
            int actual = Route.GetResult(route, 0, Towns);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ShortestRouteWithInvalidValueTest()
        {
            RouteModel route = new RouteModel('B', 'F', "", 0, 0);
            int expected = 0;
            int actual = Route.GetResult(route, 0, Towns);
            Assert.AreEqual(expected, actual);
        }
    }
}
