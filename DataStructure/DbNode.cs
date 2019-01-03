using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure {
    public class DbNode<T> {
        public T Data; //数据域
        public DbNode<T> Prev { get; set; } //前驱引用域
        public DbNode<T> Next { get; set; } //后继引用域
        //构造器
        public DbNode( ) {
            Data = default(T);
            Prev = null;
            Next = null;
        }
        //构造器
        public DbNode( T val , DbNode<T> p , DbNode<T> n ) {
            Data = val;
            Prev = p;
            Next = n;
        }
    }
}
