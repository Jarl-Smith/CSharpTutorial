using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure {
    class Program {
        static void Main( string[] args ) {

        }

        /// <summary>
        /// 十进制转换其它进制
        /// </summary>
        static void DigitalConverter( ) {
            int inputNumber, baseNumber;
            Stack<int> container = new Stack<int>();
            try {
                Console.WriteLine("请输入一个十进制整数:");
                inputNumber = int.Parse(Console.ReadLine());
                Console.WriteLine("请输入目标进制(2~9):");
                baseNumber = int.Parse(Console.ReadLine());
                if ( baseNumber > 9 || baseNumber < 2 ) {
                    throw new FormatException();
                } else {
                    int temp = inputNumber;
                    //5142一直除以8直到商为0，每个余数入栈
                    while ( temp > 0 ) {
                        container.Push(temp % baseNumber);
                        temp /= baseNumber;
                    }
                    int[] result = container.ToArray();//将栈转换为数组，顺序是栈底到栈顶
                    Console.WriteLine("转换后的进制数为:");
                    foreach ( int i in result ) {
                        Console.Write("{0}   " , i);
                    }
                }
            } catch ( FormatException e ) {
                Console.WriteLine("Invalid Input");
            }
        }
    }
}
