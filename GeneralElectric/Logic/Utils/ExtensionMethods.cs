namespace Logic.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class ExtensionMethods
    {
        private static Random random = new Random();

        public static T RandomElement<T>(this IEnumerable<T> elements)
        {
            return elements.ElementAt(random.Next(0, elements.Count()));
        }

        public static IEnumerable<T> RandomElements<T>(this IEnumerable<T> elements)
        {
            HashSet<T> choosedElements = new HashSet<T>();
            int elementsCount = elements.Count(),
                quantity = random.Next(1, elementsCount);
            IEnumerable<T> elementsRange = elements.Where(service => !choosedElements.Contains(service));
            while (quantity-- > 0)
                choosedElements.Add(elementsRange.ElementAt(random.Next(0, elementsCount - choosedElements.Count)));
            return choosedElements;
        }

        public static T PopAt<T>(this List<T> list, int index)
        {
            if (index >= list.Count)
                return default(T);
            T selectedElement = list[index];
            list.RemoveAt(index);
            return selectedElement;
        }

        public static T RandomPop<T>(this List<T> list)
        {
            if (list.Count == 0)
                return default(T);
            return list.PopAt(random.Next(0, list.Count));
        }

        public static List<T> RandomPops<T>(this List<T> list, int quantity)
        {
            if (quantity < 0)
                return null;
            List<T> resultElements = new List<T>();
            while (quantity-- > 0 && list.Count > 0)
                resultElements.Add(list.RandomPop());
            return resultElements;
        }
    }
}
