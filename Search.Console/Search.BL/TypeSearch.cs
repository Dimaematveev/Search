using System.Collections.Generic;
using System.Linq;

namespace Search.BL
{
    public class TypeSearch
    {

        public int[] Items { get; }
        public int CountCompare { get; private set; }
        public string NameTypeSearch{ get; private set; }

        public TypeSearch(ICollection<int> items)
        {
            Items = items.OrderBy(x => x).ToArray();
            CountCompare = 0;
        }

        /// <summary>
        /// Поиск интерполяционный
        /// </summary>
        /// <param name="toFind"> элемент который ищем</param>
        /// <returns></returns>
        public int InterpolationSearch(int toFind)
        {
            NameTypeSearch = "Интерполяционный поиск";
            // Возвращает индекс элемента со значением toFind или -1, если такого элемента не существует
            int mid;
            var sortedArray = Items;
            int low = 0;
            int high = sortedArray.Length - 1;

            var sAl = sortedArray[low];
            var sAh = sortedArray[high];

            CountCompare = 1;

            while (sAl.CompareTo(toFind) == -1 && sAh.CompareTo(toFind) == 1)
            {
                CountCompare++;
                if (sAh.CompareTo(sAl) == 0) // Защита от деления на 0
                    break;
                mid = low + ((toFind - sAl) * (high - low)) / (sAh - sAl);
                var sAm = sortedArray[mid];
                if (sAm.CompareTo(toFind) == -1)
                {
                    low = mid + 1;
                    sAl = sortedArray[low];
                }
                else if (sAm.CompareTo(toFind) == 1)
                { 
                    high = mid - 1;
                    sAh = sortedArray[high];
                }
                else
                    return mid;
            }

            if (sAl.CompareTo(toFind) == 0)
                return low;
            if (sAh.CompareTo(toFind) == 0)
                return high;

            return -1; // Not found
        }

        /// <summary>
        /// Поиск Бинарный
        /// </summary>
        /// <param name="toFind"> элемент который ищем</param>
        /// <returns></returns>
        public int BinarySearch(int toFind)
        {
            NameTypeSearch = "Бинарный поиск";
            // Возвращает индекс элемента со значением toFind или -1, если такого элемента не существует
            int mid;
            var sortedArray = Items;

            int begin = 0;
            int end = sortedArray.Length - 1;

            var sAb = sortedArray[begin];
            var sAe = sortedArray[end];

            CountCompare = 1;

            while (end - begin > 2)
            {
                CountCompare++;

                if (sAe.CompareTo(sAb) == 0) // Защита от деления на 0
                    break;
                mid = (begin + end) / 2;
                var sAm = sortedArray[mid];

                if (sAm.CompareTo(toFind) == -1)
                {
                    begin = mid + 1;
                    sAb = sortedArray[begin];
                }
                else if (sAm.CompareTo(toFind) == 1)
                {
                    end = mid - 1;
                    sAe = sortedArray[end];
                }
                else
                    return mid;
            }

            if (sAb.CompareTo(toFind) == 0)
                return begin;
            if (sAe.CompareTo(toFind) == 0)
                return end;

            return -1; // Not found
        }
    }
}
