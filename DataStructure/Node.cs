using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure {
    /// <summary>
    /// 节点
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Node<T> {
        public T Data { get; set; }//数据域
        public Node<T> Next { get; set; }//后置节点

        public Node( ) {
            Data = default(T);
            Next = null;
        }
        public Node( T value ) {
            Data = value;
            Next = null;
        }
        public Node( Node<T> node ) {
            Data = default(T);
            Next = node;
        }
        public Node( T value , Node<T> node ) {
            Data = value;
            Next = node;
        }

    }
}
