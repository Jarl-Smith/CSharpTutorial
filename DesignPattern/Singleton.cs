using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern {
    public class Singleton {
        #region 延迟加载式
        /*
         * 此设计为延迟加载，只有当第一次调用获取实例方法时才会生成一个对象
         * 延迟加载没有考虑多线程，无法保证多线程并发访问时对象唯一
         */
        private static Singleton Instance;
        private Singleton( ) {

        }

        public static Singleton GetInstance( ) {
            if ( Instance == null ) {
                Instance = new Singleton();
            }
            return Instance;
        }
        #endregion
        #region 饿汉式
        /*
         * 饿汉式可以保证多线程并发访问时对象唯一
         */
        /*
        private static Singleton Instance = new Singleton();

        private Singleton( ) {

        }
        public static Singleton GetSingleton( ) {
            return Instance;
        }
       */
        #endregion
    }
}
