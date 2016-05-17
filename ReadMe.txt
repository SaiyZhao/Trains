My software has two class files:
RouteControls class contains all the calculate functions. Each function will handle one calculate situation.
Program class is the default class along with the Main function.

This software base on Windows console, to execute it please follow below steps:
1. Use Visual Studio which version newest than 10.0.
2. Open Trains.sln in the zip package.
3. Run debug, the popup cmd window will display all the result.
4. Change the code of Main function to test other conditions.

Below public functions can direct call and test, the details of the function can find in the code annotation:
1. routeControls.CreateRouteGraphs.
2. routeControls.GetRouteDistance.
3. routeControls.GetRouteWithMaxStops.
4. routeControls.GetRoutesWithExactlyStops.
5. routeControls.GetLengthOfShortestRoute.
6. routeControls.GetNumberOfRoutesLimitDistance.

