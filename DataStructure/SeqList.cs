using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure {
    /// <summary>
    /// 顺序表，数据元素位置连续
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SeqList<T> : IListDS<T> {
        private int maxsize; //顺序表的容量
        private T[] data; //数组，用于存储顺序表中的数据元素
        private int last; //指示顺序表最后一个元素的位置
        //索引器
        public T this[int index]
        {
            get
            {
                return data[index];
            }
            set
            {
                data[index] = value;
            }
        }
        //最后一个数据元素位置属性
        public int Last
        {
            get
            {
                return last;
            }
        }
        //容量属性
        public int MaxSize
        {
            get
            {
                return maxsize;
            }
            set
            {
                maxsize = value;
            }
        }

        //构造器
        public SeqList( int size ) {
            maxsize = size;
            data = new T[size];
            last = -1;
        }
        //求顺序表的长度
        public int GetLength( ) {
            return last + 1;
        }
        //清空顺序表
        public void Clear( ) {
            last = -1;
        }
        //判断顺序表是否为空
        public bool IsEmpty( ) {
            return last == -1;
        }
        //判断顺序表是否满
        public bool IsFull( ) {
            return last == maxsize - 1;
        }
        //附加操作
        public void Append( T item ) {
            if ( IsFull() ) {
                Console.WriteLine("List is full");
                return;
            } else {
                data[++last] = item;
            }
        }
        //插入操作
        public void Insert( T item , int i ) {
            if ( IsFull() ) {
                Console.WriteLine("List is full");
            }
            if ( i < 1 || i > last + 2 ) {
                Console.WriteLine("Position is error");
                return;
            }
            if ( i == last + 2 ) {
                data[++last] = item;
            } else {
                for ( int j = last ; j >= i - 1 ; --j ) {
                    data[j + 1] = data[j];
                }
                data[i - 1] = item;
            }
        }
        //删除操作
        public T Delete( int i ) {
            T temp = default(T);
            if ( IsEmpty() ) {
                Console.WriteLine("List is empty");
                return temp;
            }
            if ( i < 1 || i > last + 1 ) {
                Console.WriteLine("Position is error!");
                return temp;
            }
            if ( i == last + 1 ) {
                temp = data[last--];
            } else {
                temp = data[i - 1];
                for ( int j = i ; j <= last ; ++j ) {
                    data[j] = data[j + 1];
                }
            }
            --last;
            return temp;
        }
        //取表元
        public T GetElem( int i ) {
            if ( IsEmpty() || (i < 1) || (i > last + 1) ) {
                Console.WriteLine("List is empty or Position is error!");
                return default(T);
            }
            return data[i - 1];
        }
        //按值查找
        public int Locate( T value ) {
            if ( IsEmpty() ) {
                Console.WriteLine("List is Empty!");
                return -1;
            }
            int i = 0;
            for ( i = 0 ; i <= last ; i++ ) {
                if ( value.Equals(data[i]) ) {
                    return i;
                }
            }
            return -1;
        }
    }
}
