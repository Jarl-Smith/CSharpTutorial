using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure {
    /// <summary>
    /// 循环顺序队列
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CSeqQueue<T> : IQueue<T> {
        public int MaxSize { get; private set; } //循环顺序队列的容量
        private T[] data; //数组，用于存储循环顺序队列中的数据元素
        private int front; //指示循环顺序队列的队头
        private int rear; //指示循环顺序队列的队尾

        public CSeqQueue( int size ) {
            data = new T[size];
            MaxSize = size;
            front = rear = -1;
        }

        public void Clear( ) {
            front = rear = -1;
        }

        public T GetFront( ) {
            if ( IsEmpty() ) {
                Console.WriteLine("Queue is empty");
                return default(T);
            } else {
                return data[(front + 1) % MaxSize];
            }
        }

        public int GetLength( ) {
            return (rear - front + MaxSize) % MaxSize;
        }

        public void In( T item ) {
            if ( IsFull() ) {
                Console.WriteLine("Queue is full");
                return;
            } else {
                data[++rear] = item;
            }
        }

        public bool IsEmpty( ) {
            return front == rear;
        }

        public bool IsFull( ) {
            if ( (rear + 1) % MaxSize == front ) {
                return true;
            } else {
                return false;
            }
        }

        public T Out( ) {
            if ( IsEmpty() ) {
                Console.WriteLine("Queue is empty");
                return default(T);
            }
            front = (front + 1) % MaxSize;
            return data[front];
        }
    }
}
