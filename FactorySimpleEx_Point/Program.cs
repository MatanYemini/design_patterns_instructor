using System;

namespace FactorySimpleEx_Point
{
    public class Point
    {
        private double x, y;

        private Point(double x, double y) // enables 
        {
            this.x = x;
            this.y = y;
        }

        public Point(double a,
            double b, // names do not communicate intent
            CoordinateSystem cs = CoordinateSystem.Cartesian)
        {
            switch (cs)
            {
                case CoordinateSystem.Polar:
                    x = a * Math.Cos(b);
                    y = a * Math.Sin(b);
                    break;
                default:
                    x = a;
                    y = b;
                    break;
            }

            // steps to add a new system
            // 1. augment CoordinateSystem
            // 2. change ctor
        }

        // factory property
        public static Point Origin => new Point(0, 0); // like a property - every time you will get 

        // singleton field
        public static Point Origin2 = new Point(0, 0); // better - available every time we want

        // make it lazy
        public static class Factory
        {
            public static Point NewCartesianPoint(double x, double y)
            {
                return new Point(x, y);
            }
        }
        // factory method

        public static Point NewCartesianPoint(double x, double y)
        {
            return new Point(x, y);
        }

        public static Point NewPolarPoint(double rho, double theta)
        {
            //...
            return null;
        }

        public enum CoordinateSystem
        {
            Cartesian,
            Polar
        }

       
    }

    class PointFactory
    {
        public static Point NewCartesianPoint(float x, float y)
        {
            return new Point(x, y); // needs to be public
        }
    }

    class Demo
    {
        static void Main(string[] args)
        {
            var p1 = new Point(2, 3, Point.CoordinateSystem.Cartesian);
            var origin = Point.Origin;

            var p2 = Point.Factory.NewCartesianPoint(1, 2);
            //var LikeGlobFactory = PointFactory.NewCartesianPoint(2, 2);
            var p = Point.Factory.NewCartesianPoint(1, 1);
        }
    }
}
