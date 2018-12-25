using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure {
    class Program {
        static void Main( string[] args ) {
            string exp = "{()}[{}]";
            Console.WriteLine(IsCorrect(exp));
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
        /// <summary>
        /// 检查括号字符串是否嵌套正确,即只能嵌套成对儿，不能单个
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        static bool IsCorrect( string exp ) {
            char[] array = exp.ToArray();
            Stack<char> s = new Stack<char>();
            s.Push(array[0]);
            for ( int i = 1 ; i < array.Length ; i++ ) {
                if ( s.Count == 0 ) {
                    s.Push(array[i]);
                    continue;
                }
                switch ( s.Peek() ) {
                    case '(':
                        if ( array[i] == ')' ) {
                            s.Pop();
                        } else {
                            s.Push(array[i]);
                        }
                        break;
                    case '{':
                        if ( array[i] == '}' ) {
                            s.Pop();
                        } else {
                            s.Push(array[i]);
                        }
                        break;
                    case '[':
                        if ( array[i] == ']' ) {
                            s.Pop();
                        } else {
                            s.Push(array[i]);
                        }
                        break;
                    default:
                        s.Push(array[i]);
                        break;
                }
            }
            return s.Count == 0;
        }
    }
}
