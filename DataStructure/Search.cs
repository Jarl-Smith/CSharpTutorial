using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure {
    public class Search {
        /// <summary>
        /// 二分查找法(折半查找)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int BinarySearch<T>( T[] array , T target ) where T : IComparable<T> {
            int low = 0;
            int high = array.Length - 1;
            while ( low <= high ) {
                int middle = (low + high) / 2;
                if ( array[middle].CompareTo(target) == 0 ) {
                    return middle;
                } else if ( array[middle].CompareTo(target) > 0 ) {
                    high = middle - 1;
                } else {
                    low = middle + 1;
                }
            }
            return -1;
        }
    }
}
