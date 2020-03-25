using System;
using System.Collections;
using System.Collections.Generic;

namespace Composite_YeminiEx
{
    public interface IValueContainer : IEnumerable<int> // remove the : for ex
    {

    }

    public class SingleValue : IValueContainer
    {
        public int Value;

        public IEnumerator<int> GetEnumerator()
        {
            yield return Value; // Leave it empty for the ex
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class ManyValues : List<int>, IValueContainer
    {

    }

    public static class ExtensionMethods
    {
        public static int Sum(this List<IValueContainer> containers)
        {
            int result = 0;
            foreach (var c in containers)
            foreach (var i in c)
                result += i;
            return result;
        }
    }
}
