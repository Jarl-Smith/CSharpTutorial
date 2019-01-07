using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure {
    public class Sorting {
        /// <summary>
        /// 冒泡排序
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="array"></param>
        /// <param name="handler"></param>
        /// <param name="desc"></param>
        public static void Bubble<T, TValue>( T[] array , Func<T , TValue> handler , bool desc = false ) where TValue : IComparable<TValue> {
            for ( int i = 0 ; i < array.Length - 1 ; i++ ) {
                for ( int j = 0 ; j < array.Length - 1 - i ; j++ ) {
                    if ( desc ) {
                        if ( handler(array[j]).CompareTo(handler(array[j + 1])) < 0 ) {
                            T temp = array[j];
                            array[j] = array[j + 1];
                            array[j + 1] = temp;
                        }
                    } else {
                        if ( handler(array[j]).CompareTo(handler(array[j + 1])) > 0 ) {
                            T temp = array[j];
                            array[j] = array[j + 1];
                            array[j + 1] = temp;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 选择排序
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="array"></param>
        /// <param name="handler"></param>
        /// <param name="desc"></param>
        public static void Selection<T, TValue>( T[] array , Func<T , TValue> handler , bool desc = false ) where TValue : IComparable<TValue> {
            for ( int i = 0 ; i < array.Length - 1 ; i++ ) {
                for ( int j = i + 1 ; j < array.Length ; j++ ) {
                    if ( desc ) {
                        if ( handler(array[i]).CompareTo(handler(array[j])) < 0 ) {
                            T temp = array[i];
                            array[i] = array[j];
                            array[j] = temp;
                        }
                    } else {
                        if ( handler(array[i]).CompareTo(handler(array[j])) > 0 ) {
                            T temp = array[i];
                            array[i] = array[j];
                            array[j] = temp;
                        }
                    }
                }
            }
        }
    }
}
