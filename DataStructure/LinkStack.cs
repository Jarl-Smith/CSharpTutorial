using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure {
    public class LinkStack<T> : IStack<T> {
        private Node<T> top; //栈顶指示器
        private int num; //栈中结点的个数

        public LinkStack( ) {
            top = null;
            num = 0;
        }

        public void Clear( ) {
            top.Next = null;
            num = 0;
        }

        public int GetLength( ) {
            return num;
        }

        public bool IsEmpty( ) {
            return num == 0;
        }

        public T Peek( ) {
            if ( IsEmpty() ) {
                Console.WriteLine("Stack is empty");
                return default(T);
            }
            return top.Data;
        }

        public T Pop( ) {
            if ( IsEmpty() ) {
                Console.WriteLine("Stack is empty");
                return default(T);
            }
            T temp = top.Data;
            top = top.Next;
            num--;
            return temp;
        }

        public void Push( T item ) {
            Node<T> p = new Node<T>(item);
            if ( top != null ) {
                p.Next = top;
            }
            top = p;
            num++;
        }
    }
}
