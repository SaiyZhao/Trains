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
    public class RoutesOfExactlyStopsTests
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

        public RoutesOfExactlyStopsTests()
        {
            Towns = new TownsModel();
            string routeStr = "AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7";
            Towns.CreateRouteGraphs(routeStr.ToUpper());

            Route = RouteFindFactory.CreateRouteControl(FindRouteType.RouteWithExactlyStops);
        }

        [TestMethod()]
        public void RoutesOfExactlyStopsWithCorrectValueTest()
        {
            RouteModel route = new RouteModel('A', 'C', "", 0, 0);
            int expected = 3;
            int actual = Route.GetResult(route, 4, Towns);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RoutesOfExactlyStopsWithInvalidValueTest()
        {
            RouteModel route = new RouteModel('A', 'F', "", 0, 0);
            int expected = 0;
            int actual = Route.GetResult(route, 4, Towns);
            Assert.AreEqual(expected, actual);
        }
    }
}
