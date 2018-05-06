using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FeiCui.Unity
{
    namespace ThreadDemo
    {
        /*线程简单使用
        class Program
        {
            static void Main(String[] args)
            {
                Thread t = new Thread(WriteY);
                t.Start();
                t.Join();//只有当t线程完成任务后，主线程才会变为执行状态以完成后边的操作
                for (int i = 0; i < 10; i++)
                {
                    Console.Write("x");
                }

            }
            static void WriteY()
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.Write("y");
                }
            }
        }
        */

        /*使用线程锁演示
        public class Program1
        {
            static void Main(string[] args)
            {
                BookShop bs = new BookShop();
                do
                {
                    new Thread(bs.Sale).Start();
                    bs.Sale();
                } while (bs.num > 0);
            }
        }

        class BookShop
        {
            public int num = 3;
            public void Sale()
            {
                lock (this)
                {
                    Console.WriteLine("{0}进入锁", Thread.CurrentThread.ManagedThreadId);
                    if (num > 0)
                    {
                        Thread.Sleep(1000);
                        num -= 1;
                        Console.WriteLine("售出一本图书，还剩余{0}本", num);
                    }
                    else
                    {
                        Console.WriteLine("没有书了");
                    }
                    Console.WriteLine("{0}退出锁", Thread.CurrentThread.ManagedThreadId);
                }
            }
        }
        */

        /*前台线程与后台线程演示
        class Program2
        {
            static void Main(String[] args)
            {
                Thread frontThread = new Thread(ThreadMain);//创建一个前台线程，即使主线程先完成，只要有一个前台线程未完成，程序就不会关闭,所有前台线程完成后无论后台线程是否完成，后台线程都会结束
                Thread backThread = new Thread(ThreadMain);
                backThread.IsBackground = true;
                frontThread.Start(3000);
                backThread.Start(5000);
                Console.WriteLine("Main Thread complete");
            }

            static void ThreadMain(object ms)
            {
                Console.WriteLine("Thread {0} started", Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep((int)ms);
                Console.WriteLine("Thread {0} complete", Thread.CurrentThread.ManagedThreadId);
            }
        }
        */

        /*线程池使用演示
        class Program3
        {
            static void Main(string[] args)
            {
                int workerThreads, completionPortThreads;
                ThreadPool.GetMaxThreads(out workerThreads, out completionPortThreads);
                Console.WriteLine("Max Worker Thread {0},I/O Completion Thread{1}", workerThreads, completionPortThreads);
                for (int i = 0; i < 5; i++)
                {
                    ThreadPool.QueueUserWorkItem(JobForAThread);
                }
                Thread.Sleep(3000);
            }
            static void JobForAThread(object obj)
            {
                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine("loop:{0},running inside pooled thread:{1}", i, Thread.CurrentThread.ManagedThreadId);
                    Thread.Sleep(50);
                }
            }
        }
        */

        class Program4
        {
            static void Main(string[] args)
            {
                MyLogger ml = new MyLogger();
                Thread t = new Thread(ml.Start);
                t.Start();
            }
        }
    }
}