using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BinaryChop
{
    public class SortedArray<T>
    {
        private readonly T[] sortedArray;

        public SortedArray(T[] array)
        {
            var list = new List<T>(array);
            sortedArray = list.OrderBy(l => l).ToArray();
        }

        public int Length => sortedArray.Length;

        public T this[int index]
        {
            get => sortedArray[index];
            //set => sortedArray[index] = value;
        }

        public IEnumerator GetEnumerator()
        {
            for(int i = 0; i < sortedArray.Length; i++)
            {
                yield return sortedArray[i];
            }
        }

        public SortedArray<T> Sub(int beginIndex, int endIndex)
        {
            return new SortedArray<T>(sortedArray.Skip(beginIndex).Take(endIndex - beginIndex + 1).ToArray());
        }
    }
}
