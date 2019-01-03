using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure {
    interface IQueue<T> {
        /// <summary>
        /// 求队列的长度
        /// </summary>
        /// <returns></returns>
        int GetLength( );
        /// <summary>
        /// 判断对列是否为空
        /// </summary>
        /// <returns></returns>
        bool IsEmpty( );
        /// <summary>
        /// 清空队列
        /// </summary>
        void Clear( );
        /// <summary>
        /// 入队
        /// </summary>
        /// <param name="item"></param>
        void In(T item);
        /// <summary>
        /// 出队
        /// </summary>
        /// <returns></returns>
        T Out( );
        /// <summary>
        /// 取对头元素
        /// </summary>
        /// <returns></returns>
        T GetFront( );
    }
}
