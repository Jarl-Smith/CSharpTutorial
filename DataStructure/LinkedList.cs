using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure {
    /// <summary>
    /// 单链表
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LinkedList<T> : IListDS<T> {
        private Node<T> Head { get; set; }//单链表的头引用

        public LinkedList( ) {
            Head = null;
        }
        public LinkedList( Node<T> node ) {
            Head = node;
        }

        /// <summary>
        /// 在单链表的末尾添加新元素
        /// </summary>
        /// <param name="item"></param>
        public void Append( T item ) {
            Node<T> p = Head;
            while ( p.Next != null ) {
                p = p.Next;
            }
            Node<T> temp = new Node<T>(item);
            p.Next = temp;
        }
        /// <summary>
        /// 清空单链表
        /// </summary>
        public void Clear( ) {
            Head = null;
        }

        public T Delete( int i ) {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 获取表元
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public T GetElem( int i ) {
            T temp = default(T);
            if ( IsEmpty() ) {
                Console.WriteLine("Linked List is Empty");
                return temp;
            }
            int len = GetLength();
            if ( i > len ) {
                Console.WriteLine("Position is error");
                return temp;
            }
            Node<T> p = Head;
            int index = 1;
            while ( index < i ) {
                index++;
                p = p.Next;
            }
            return p.Data;
        }

        /// <summary>
        /// 求单链表长度
        /// </summary>
        /// <returns></returns>
        public int GetLength( ) {
            Node<T> p = Head;
            int len = 0;
            while ( p != null ) {
                len++;
                p = p.Next;
            }
            return len;
        }
        /// <summary>
        /// 在单链表的第i个结点的位置前插入一个值为item的结点
        /// </summary>
        /// <param name="item"></param>
        /// <param name="i"></param>
        public void Insert( T item , int i ) {
            if ( IsEmpty() || i < 1 ) {
                Console.WriteLine("List is empty or position error");
                return;
            }
            if ( i == 1 ) {
                Node<T> temp = new Node<T>(item);
                temp.Next = Head;
                Head = temp;
                return;
            }
            Node<T> p = Head;
            Node<T> r = new Node<T>();
            int j = 1;
            while ( p.Next != null && j < i ) {
                r = p;
                p = p.Next;
                ++j;
            }
            if ( j == i ) {
                Node<T> q = new Node<T>(item);
                q.Next = p;
                r.Next = q;
            }
        }

        public bool IsEmpty( ) {
            return Head == null;
        }
        /// <summary>
        /// 在单链表中查找值为value的结点
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int Locate( T value ) {
            if ( IsEmpty() ) {
                Console.WriteLine("List is Empty!");
                return -1;
            }
            Node<T> p = new Node<T>();
            p = Head;
            int i = 1;
            while ( !p.Data.Equals(value) && p.Next != null ) {
                p = p.Next;
                ++i;
            }
            return i;
        }
    }
}
