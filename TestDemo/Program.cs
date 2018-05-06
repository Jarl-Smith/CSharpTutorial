using System;
using System.Collections.Generic;


namespace FeiCui.Unity
{
    namespace SortDemo
    {
        class Program
        {
            static void Main(string[] args)
            {
                CustomClassQuery();
            }


            static void CustomClassQuery()
            {
                Person[] array = new Person[]
                {
                    new Person(){Id=1,Age=10,Name="张三",Weight=100 },
                    new Person(){Id=3,Age=11,Name="lisi",Weight=111 },
                    new Person(){Id=2,Age=9,Name="wangwu",Weight=90 }
                };
                Person min, max;
                MaxAndMin<Person, int>(array, (Person p) => { return p.Age; }, out min, out max);
                Bubble<Person, int>(array, (Person p) => { return p.Id; });
                List<Person> result = Query<Person>(array, (Person p) => { return p.Age > 9 && p.Weight < 120; });
                foreach (Person p in array)
                {
                    Console.WriteLine("{0} {1}", p.Id, p.Name);
                }
                Console.WriteLine("min :{0} age :{1}", min.Name, min.Age);
                Console.WriteLine("max :{0} age:{1}", max.Name, max.Age);
                foreach (Person p in result)
                {
                    Console.WriteLine("Query result: {0}", p.Name);
                }
            }
            //万能冒泡算法
            static void Bubble<T, TValue>(T[] array, Func<T, TValue> handler, bool desc = false) where TValue : IComparable<TValue>
            {
                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = 0; j < array.Length - 1 - i; j++)
                    {

                        if (handler(array[j]).CompareTo(handler(array[j + 1])) > 0)
                        {
                            T temp = array[j];
                            array[j] = array[j + 1];
                            array[j + 1] = temp;
                        }
                    }
                }
                if (desc)
                {
                    Array.Reverse(array);
                }
            }
            //万能选择排序算法
            static void MaxAndMin<T, TValue>(T[] array, Func<T, TValue> handler, out T min, out T max) where TValue : IComparable<TValue>
            {
                max = min = array[0];
                for (int i = 1; i < array.Length; i++)
                {
                    if (handler(array[i]).CompareTo(handler(max)) > 0)
                    {
                        max = array[i];
                    }
                    else
                    {
                        min = array[i];
                    }
                }
            }

            static List<T> Query<T>(T[] array, Func<T, bool> findMethod)
            {
                List<T> result = new List<T>();
                foreach (T temp in array)
                {
                    if (findMethod(temp))
                    {
                        result.Add(temp);
                    }
                }
                return result;
            }
        }
    }
}
