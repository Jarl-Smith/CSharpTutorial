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
        public LinkedList( T data ) {
            Head = new Node<T>(data);
        }
        public LinkedList( Node<T> node ) {
            Head = node;
        }

        /// <summary>
        /// 在单链表的末尾添加新元素
        /// </summary>
        /// <param name="item"></param>
        public void Append( T item ) {
            Node<T> q = new Node<T>(item);
            if ( IsEmpty() ) {
                Head = q;
                return;
            }
            Node<T> p = Head;
            while ( p.Next != null ) {
                p = p.Next;
            }
            p.Next = q;
        }
        /// <summary>
        /// 清空单链表
        /// </summary>
        public void Clear( ) {
            Head = null;
        }
        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public T Delete( int i ) {
            if ( IsEmpty() || i < 0 ) {//表空和位置错误情况
                Console.WriteLine("position is error or linkedlist is empty");
                return default(T);
            }
            Node<T> p = Head;
            Node<T> q = Head;
            if ( i == 1 ) {//头结点
                Head = Head.Next;
                return p.Data;
            }
            int j = 1;
            while ( p.Next != null && j < i ) {
                q = p;
                p = p.Next;
                j++;
            }
            if ( j == i ) {//找到了
                q.Next = p.Next;
                return p.Data;
            } else {//位置超出链表长度
                Console.WriteLine("Position is error");
                return default(T);
            }
        }
        /// <summary>
        /// 获取表元
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public T GetElem( int i ) {
            if ( IsEmpty() || i < 0 ) {
                Console.WriteLine("linkedlist is empty or position is error");
                return default(T);
            }
            Node<T> p = Head;
            int j = 1;
            if ( p.Next != null && j < i ) {
                j++;
                p = p.Next;
            }
            if ( j == i ) {
                return p.Data;
            } else {
                Console.WriteLine("Position is error");
                return default(T);
            }
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
            if ( IsEmpty() ) {
                Console.WriteLine("List is empty");
                return;
            }
            Node<T> latter = Head;
            Node<T> former = Head;
            int j = 1;
            while ( latter.Next != null && j < i ) {
                former = latter;
                latter = latter.Next;
                ++j;
            }
            if ( j == i ) {
                former.Next = new Node<T>(item);
                former.Next.Next = latter;
            } else {
                Console.WriteLine("Position is error");
            }
        }
        /// <summary>
        /// 判断链表是否为空
        /// </summary>
        /// <returns></returns>
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
            Node<T> current = Head;
            int j = 1;
            do {
                if ( current.Data.Equals(value) ) {
                    return j;
                }
                j++;
                current = current.Next;
            } while ( current.Next != null );
            return -1;
        }
    }
}
