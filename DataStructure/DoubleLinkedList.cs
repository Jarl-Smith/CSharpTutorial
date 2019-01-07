using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure {
    public class DoubleLinkedList<T> : IListDS<T> {
        public DbNode<T> Head { get; private set; }//双链表的头引用
        private int count;

        public DoubleLinkedList( ) {
            Head = null;
            count = 0;
        }
        public DoubleLinkedList( T data ) {
            Head = new DbNode<T>(data , null , null);
            count = 1;
        }
        public DoubleLinkedList( DbNode<T> node ) {
            Head = node;
            count = 1;
        }

        public void Append( T item ) {
            if ( IsEmpty() ) {
                Head = new DbNode<T>(item , null , null);
                count = 1;
            } else {
                DbNode<T> current = Head;
                while ( current.Next != null ) {
                    current = current.Next;
                }
                current.Next = new DbNode<T>(item , current , null);
            }
        }

        public void Clear( ) {
            Head = null;
            count = 0;
        }

        public T Delete( int i ) {
            if ( IsEmpty() || i < 0 ) {
                Console.WriteLine("DoubleLinkedList is empty or position is error");
                return default(T);
            }
            if ( i == 1 ) {
                T temp1 = Head.Data;
                Head = null;
                return temp1;
            }
            DbNode<T> current = Head;
            int j = 1;
            while ( current.Next != null && j < i ) {
                current = current.Next;
                j++;
            }
            if ( j != i ) {
                Console.WriteLine("Position is error");
                return default(T);
            }
            T temp = current.Data;
            DbNode<T> prev = current.Prev;
            prev.Next = current.Next;
            DbNode<T> next = current.Next;
            if ( next != null ) {
                next.Prev = prev;
            }
            return temp;
        }

        public T GetElem( int i ) {
            if ( IsEmpty() || i < 0 ) {
                Console.WriteLine("DoubleLinkedList is empty or position is error");
                return default(T);
            }
            if ( i == 1 ) {
                return Head.Data;
            }
            DbNode<T> current = Head;
            int j = 1;
            while ( current.Next != null && j < i ) {
                current = current.Next;
                j++;
            }
            if ( j != i ) {
                Console.WriteLine("Position is error");
                return default(T);
            }
            return current.Data;
        }

        public int GetLength( ) {
            return count;
        }

        public void Insert( T item , int i ) {
            if ( IsEmpty() || i < 1 ) {
                Console.WriteLine("DbLinkedList is empty or Position is error!");
                return;
            }
            //在最开头插入
            if ( i == 1 ) {
                DbNode<T> q = new DbNode<T>(item , null , null);
                q.Next = Head;//把"头"改成第二个元素
                Head.Prev = q;
                Head = q;//把自己设置为"头"
                count++;
                return;
            }
            DbNode<T> n = Head;
            DbNode<T> d = new DbNode<T>();
            int j = 1;
            //找到位置i的前一个元素d
            while ( n.Next != null && j < i ) {
                d = n;
                n = n.Next;
                j++;
            }
            if ( j == i ) {
                DbNode<T> q = new DbNode<T>(item);
                d.Next = q;
                q.Prev = d;
                q.Next = n;
                n.Prev = q;
            } else {
                Append(item);
            }
            count++;
        }

        public bool IsEmpty( ) {
            return Head == null;
        }

        public int Locate( T value ) {
            if ( IsEmpty() ) {
                Console.WriteLine("DoubleLinkedList is empty");
                return -1;
            }
            DbNode<T> current = Head;
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
