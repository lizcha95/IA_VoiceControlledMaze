namespace Logic.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class ExtensionMethods
    {
        private static Random random = new Random();

        /// <summary>
        /// Selects a random element of a sequence.
        /// </summary>
        /// <typeparam name="T">The type of the sequence.</typeparam>
        /// <param name="elements">The sequence.</param>
        /// <returns>A randomly selected element of the sequence.</returns>
        public static T RandomElement<T>(this IEnumerable<T> elements) =>
            elements.ElementAt(random.Next(0, elements.Count()));

        /// <summary>
        /// Selects a random collection of elements of a sequence.
        /// </summary>
        /// <typeparam name="T">The type of the sequence.</typeparam>
        /// <param name="elements">The sequence.</param>
        /// <returns>A randomly selected collection of element of the sequence.</returns>
        public static IEnumerable<T> RandomElements<T>(this IEnumerable<T> elements)
        {
            HashSet<T> choosedElements = new HashSet<T>();
            int elementsCount = elements.Count(),
                quantity = random.Next(1, elementsCount); // Random quantity of elements to select.
            // Using the hast set to prevent repeated elements.
            IEnumerable<T> elementsRange = elements.Where(service => !choosedElements.Contains(service));
            while (quantity-- > 0)
                choosedElements.Add(elementsRange.ElementAt(random.Next(0, elementsCount - choosedElements.Count)));
            return choosedElements;
        }

        /// <summary>
        /// Performs a simple cross between two sequences in the specified crossing position and creates a child using the result.
        /// </summary>
        /// <typeparam name="T">The type of the sequence.</typeparam>
        /// <param name="parent1">The first sequence to cross.</param>
        /// <param name="parent2">The second sequence to cross.</param>
        /// <param name="crossingPosition">The crossing point of the sequences.</param>
        /// <returns>A child result of the sequences crossing process.</returns>
        public static IEnumerable<T> CrossWith<T>(this IEnumerable<T> parent1, IEnumerable<T> parent2, int crossingPosition)
        {
            // Convert the parents to list to use the GetRange method.
            List<T> listParent1 = parent1.ToList(),
                listParent2 = parent2.ToList();
            return listParent1.GetRange(0, crossingPosition).Concat(listParent2.GetRange(crossingPosition, listParent2.Count - crossingPosition));
        }

        /// <summary>
        /// Shuffles a sequence of elements randomly.
        /// </summary>
        /// <typeparam name="T">The type of the sequence.</typeparam>
        /// <param name="elements">The sequence.</param>
        /// <returns>The same sequence with its elements in a shuffled-randomly order.</returns>
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> elements) =>
            elements.OrderBy(element => random.Next());

        /// <summary>
        /// Returns the element of the specified position of a <see cref="List{T}"/> before removing it.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="List{T}"/>.</typeparam>
        /// <param name="list">The list to pop the element.</param>
        /// <param name="index">The index of the popping element.</param>
        /// <returns>The element of the specified index before removing it from the <see cref="List{T}"/>.</returns>
        public static T PopAt<T>(this List<T> list, int index)
        {
            if (index >= list.Count)
                return default(T);
            T selectedElement = list[index];
            list.RemoveAt(index);
            return selectedElement;
        }

        /// <summary>
        /// Returns the element of a random selected position of a <see cref="List{T}"/> before removing it.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="List{T}"/>.</typeparam>
        /// <param name="list">The list to random pop the element.</param>
        /// <returns>The element of the random selected index before removing it from the <see cref="List{T}"/>.</returns>
        public static T RandomPop<T>(this List<T> list)
        {
            if (list.Count == 0)
                return default(T);
            return list.PopAt(random.Next(0, list.Count));
        }

        /// <summary>
        /// Returns a specified quantity of elements of random selected positions of a <see cref="List{T}"/> before removing them.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="List{T}"/>.</typeparam>
        /// <param name="list">The <see cref="List{T}"/> to random pop the elements.</param>
        /// <param name="quantity">The quantity of elements to pop randomly.</param>
        /// <returns>A <see cref="List{T}"/> of "quantity" random popped elements.</returns>
        public static List<T> RandomPops<T>(this List<T> list, int quantity)
        {
            if (quantity < 0)
                return default(List<T>);
            List<T> resultElements = new List<T>();
            while (quantity-- > 0 && list.Count > 0)
                resultElements.Add(list.RandomPop());
            return resultElements;
        }

        /// <summary>
        /// Returns a random couple of elements of the <see cref="List{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="List{T}"/>.</typeparam>
        /// <param name="list">The <see cref="List{T}"/> to random pop a couple of elements.</param>
        /// <returns></returns>
        public static Tuple<T, T> PopRandomCouple<T>(this List<T> list)
        {
            if (list.Count < 2)
                return default(Tuple<T, T>);
            return new Tuple<T, T>(list.RandomPop(), list.RandomPop());
        }

        /// <summary>
        /// Rounds the multiplication of the given numbers.
        /// </summary>
        /// <param name="base">The base double for the operation.</param>
        /// <param name="multiplier">The multiplier for the operation.</param>
        /// <returns>The result of the operation.</returns>
        public static int RoundWithMultiplier(this double @base, double multiplier) =>
            (int)Math.Round(@base * multiplier);

        /// <summary>
        /// Converts a <see cref="KeyValuePair{TKey, int}"/> into a collection.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <param name="keyValuePair">The <see cref="KeyValuePair{TKey, int}"/> to convert.</param>
        /// <returns>A collection using the <see cref="KeyValuePair{TKey, int}"/>.</returns>
        public static IEnumerable<TKey> ToCollection<TKey>(this KeyValuePair<TKey, int> keyValuePair) =>
            Enumerable.Repeat(keyValuePair.Key, keyValuePair.Value);
    }
}
