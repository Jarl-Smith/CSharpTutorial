using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace 杂项 {
    class Student {
        public String Name { get; set; }
        public int Age { get; set; }
    }
    class Program {

        static void Main( string[] args ) {
            //构造字典
            Dictionary<string , Student> dic = new Dictionary<string , Student>();
            //添加键值对
            dic.Add("123456" , new Student() { Name = "Jack" , Age = 12 });
            //访问某个键对应的值
            Student temp = dic["123456"];
            //重新关联键所对应的值
            dic["123456"] = new Student { Name = "Mike" , Age = 14 };
            //如果没有键，则添加这个键并关联给定的值
            dic["321"] = new Student { Name = "Alice" , Age = 13 };
            if ( dic.ContainsKey("4321") ) {
                Student temp2 = dic["4321"];
            } else {

            }
        }
    }
}
