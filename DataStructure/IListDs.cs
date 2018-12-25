using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure {
    /// <summary>
    /// 线性表接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IListDS<T> {
        /// <summary>
        /// 求长度
        /// </summary>
        /// <returns></returns>
        int GetLength( );

        /// <summary>
        /// 清空操作
        /// </summary>
        void Clear( );

        /// <summary>
        /// 判断线性表是否为空
        /// </summary>
        /// <returns></returns>
        bool IsEmpty( );

        /// <summary>
        /// 附加操作
        /// </summary>
        /// <param name="item"></param>
        void Append( T item );

        /// <summary>
        /// 插入操作
        /// </summary>
        /// <param name="item"></param>
        /// <param name="i"></param>
        void Insert( T item , int i );

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        T Delete( int i );

        /// <summary>
        /// 取表元
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        T GetElem( int i );

        /// <summary>
        /// 按值查找
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        int Locate( T value );
    }
}
