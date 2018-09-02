using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventageGame {

    enum SortMethod {
        Bubble,
        Selection,
        Insertion
    }

    class Util {
        public static Random random = new Random();
        /// <summary>
        /// 排序方法
        /// </summary>
        /// <typeparam name="T">数组类型</typeparam>
        /// <typeparam name="TResult">类型中可比较的成员</typeparam>
        /// <param name="array">数组</param>
        /// <param name="handler">委托</param>
        /// <param name="sortMethod">选定的排序方法</param>
        /// <param name="desc">默认为false,即升序</param>
        public static void Sort<T, TResult>( T[] array , Func<T , TResult> handler , SortMethod sortMethod , bool desc = false ) where TResult : IComparable<TResult> {
            switch ( sortMethod ) {
                case SortMethod.Bubble: bubbleSort(array , handler , desc); break;
                case SortMethod.Selection: selectionSort(array , handler , desc); break;
                case SortMethod.Insertion: insertionSort(array , handler , desc); break;
            }
        }

        /// <summary>
        /// 冒泡排序，对于少数元素之外的数列排序是很没有效率的。
        /// </summary>
        /// <typeparam name="T">数组类型</typeparam>
        /// <typeparam name="TResult">类型中可比较的成员</typeparam>
        /// <param name="array">数组</param>
        /// <param name="handler">委托</param>
        /// <param name="desc">默认为false，即升序</param>
        static void bubbleSort<T, TResult>( T[] array , Func<T , TResult> handler , bool desc = false ) where TResult : IComparable<TResult> {
            for ( int i = 0 ; i < array.Length - 1 ; i++ ) {
                for ( int j = 0 ; j < array.Length - 1 - i ; j++ ) {
                    if ( handler(array[j]).CompareTo(handler(array[j + 1])) > 0 ) {
                        T temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
            if ( desc ) {
                Array.Reverse(array);
            }
        }
        /// <summary>
        /// 选择排序，插入排序不适合对于数据量比较大的排序应用。但是，如果需要排序的数据量很小，比如量级小于千，那么插入排序还是一个不错的选择。
        /// </summary>
        /// <typeparam name="T">数组类型</typeparam>
        /// <typeparam name="TResult">类型中可比较的成员</typeparam>
        /// <param name="array">数组</param>
        /// <param name="handler">委托</param>
        /// <param name="desc">默认为false，即升序</param>
        static void selectionSort<T, TResult>( T[] array , Func<T , TResult> handler , bool desc = false ) where TResult : IComparable<TResult> {
            for ( int i = 0 ; i < array.Length ; i++ ) {
                for ( int j = i + 1 ; j < array.Length ; j++ ) {
                    if ( handler(array[i]).CompareTo(handler(array[j])) > 0 ) {
                        T temp = array[j];
                        array[j] = array[i];
                        array[i] = temp;
                    }
                }
            }
            if ( desc ) {
                Array.Reverse(array);
            }
        }
        /// <summary>
        /// 插入排序，
        /// </summary>
        /// <typeparam name="T">数组类型</typeparam>
        /// <typeparam name="TResult">类型中可比较的成员</typeparam>
        /// <param name="array">数组</param>
        /// <param name="handler">委托</param>
        /// <param name="desc">默认为false，即升序</param>
        static void insertionSort<T, TResult>( T[] array , Func<T , TResult> handler , bool desc = false ) where TResult : IComparable<TResult> {
            for ( int i = 1 ; i < array.Length ; i++ ) {     // 类似抓扑克牌排序
                T get = array[i];                 // 右手抓到一张扑克牌
                int j = i - 1;                  // 拿在左手上的牌总是排序好的
                while ( j >= 0 && handler(array[j]).CompareTo(handler(get)) > 0 ) {   // 将抓到的牌与手牌从右向左进行比较
                    array[j + 1] = array[j];            // 如果该手牌比抓到的牌大，就将其右移
                    j--;
                }
                array[j + 1] = get; // 直到该手牌比抓到的牌小(或二者相等)，将抓到的牌插入到该手牌右边(相等元素的相对次序未变，所以插入排序是稳定的)
            }
            if ( desc ) {
                Array.Reverse(array);
            }
        }
    }
}
