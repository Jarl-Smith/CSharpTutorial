using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure {
    public class SeqStack<T> : IStack<T> {
        private T[] data;//数组，用于存储顺序栈中的数据元素
        private int maxSize;//顺序栈的容量
        private int top;//指示顺序栈的栈顶
        /// <summary>
        /// 索引器
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 容量属性
        /// </summary>
        public int Maxsize
        {
            get
            {
                return maxSize;
            }
            set
            {
                maxSize = value;
            }
        }
        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="size"></param>
        public SeqStack( int size ) {
            data = new T[size];
            maxSize = size;
            top = -1;
        }
        /// <summary>
        /// 清空栈
        /// </summary>
        public void Clear( ) {
            top = -1;
        }
        /// <summary>
        /// 求栈的长度
        /// </summary>
        /// <returns></returns>
        public int GetLength( ) {
            return top + 1;
        }
        /// <summary>
        /// 判断栈是否空
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty( ) {
            return top < 0;
        }
        /// <summary>
        /// 判断栈是否满
        /// </summary>
        /// <returns></returns>
        public bool IsFull( ) {
            return top + 1 == maxSize;
        }
        /// <summary>
        /// 访问栈顶元素
        /// </summary>
        /// <returns></returns>
        public T Peek( ) {
            if ( IsEmpty() ) {
                Console.WriteLine("Stack is empty");
                return default(T);
            }
            return data[top];
        }
        /// <summary>
        /// 出栈
        /// </summary>
        /// <returns></returns>
        public T Pop( ) {
            if ( IsEmpty() ) {
                Console.WriteLine("Stack is empty");
                return default(T);
            }
            T temp = data[top--];
            return temp;
        }
        /// <summary>
        /// 入栈
        /// </summary>
        /// <param name="item"></param>
        public void Push( T item ) {
            if ( IsFull() ) {
                Console.WriteLine("Stack is full");
                return;
            }
            data[++top] = item;
        }
    }
}
