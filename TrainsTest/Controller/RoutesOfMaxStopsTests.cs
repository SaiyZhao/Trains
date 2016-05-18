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
    public class RoutesOfMaxStopsTests
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

        public RoutesOfMaxStopsTests()
        {
            Towns = new TownsModel();
            string routeStr = "AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7";
            Towns.CreateRouteGraphs(routeStr.ToUpper());

            Route = RouteFindFactory.CreateRouteControl(FindRouteType.RouteWithMaxStops);
        }

        [TestMethod()]
        public void RoutesOfMaxStopsWithCorrectValueTest()
        {
            RouteModel route = new RouteModel('C', 'C', "", 0, 0);
            int expected = 2;
            int actual = Route.GetResult(route, 3, Towns);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RoutesOfMaxStopsWithInvalidValueTest()
        {
            RouteModel route = new RouteModel('D', 'F', "", 0, 0);
            int expected = 0;
            int actual = Route.GetResult(route, 3, Towns);
            Assert.AreEqual(expected, actual);
        }
    }
}
