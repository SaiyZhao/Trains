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
    public class DirectRouteTests
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

        public DirectRouteTests()
        {
            Towns = new TownsModel();
            string routeStr = "AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7";
            Towns.CreateRouteGraphs(routeStr.ToUpper());

            Route = RouteFindFactory.CreateRouteControl(FindRouteType.DirectRoute);
        }

        [TestMethod()]
        public void DirectRouteWithCorrectValueTest()
        {
            RouteModel routeAEBCD = new RouteModel(' ', ' ', "AEBCD", 0, 0);
            int expected = 22;
            int actual = Route.GetResult(routeAEBCD, 0, Towns);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void DirectRouteWithInvalidValueTest()
        {
            RouteModel routeAEBCDB = new RouteModel(' ', ' ', "AEBCDB", 0, 0);
            int expected = -1;
            int actual = Route.GetResult(routeAEBCDB, 0, Towns);
            Assert.AreEqual(expected, actual);
        }
    }
}
