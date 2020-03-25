using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Prototype_YeminiEx
{
    public static class ExtentionMethods
    {
        public static T DeepCopySerializer<T>(this T self)
        {
            using (var ms = new MemoryStream())
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(ms, self);
                ms.Position = 0;
                object copy = bf.Deserialize(ms);
                return (T) copy;
            }
        }
    }

    [Serializable]
    public class Point
    {
        public int X, Y;

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Point()
        {

        }
    }

    [Serializable]
    public class Line
    {
        public Point Start, End;

        public Line DeepCopy()
        {
            var newStart = new Point { X = Start.X, Y = Start.Y };
            var newEnd = new Point { X = End.X, Y = End.Y };
            return new Line { Start = newStart, End = newEnd };
        }

        public Line MegaDeepCopy()
        {
            return ExtentionMethods.DeepCopySerializer(this);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
