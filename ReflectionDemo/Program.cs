using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ReflectionDemo {
    class Program {
        static void Main( string[] args ) {
            foreach ( Type type in Assembly.GetExecutingAssembly().GetTypes() ) {//获取当前程序集中所有类
                Console.WriteLine(type.Name);
            }
        }
    }
}
