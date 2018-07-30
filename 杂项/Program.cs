using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;

namespace TaskDemo {
    class Program {
        public string path = "demo.txt";

        static void Main(string[] args) {
            Program p = new Program();

            //Task.Run(() => { p.MaiPiao(); });//基于任务式异步编程
            Task.Run(()=> { p.CheckLogAsync(); });
            Console.ReadLine();//保持主线程运行，防止因主线程运行完毕而后台线程未运行完毕直接关闭
        }
        async void MaiPiao() {
            for (int i = 0; i < 10; i++) {
                await Task.Delay(new TimeSpan(0, 0, 1));
                Console.WriteLine("买票中");
            }
        }

        async void CheckLogAsync() {
            string message;
            FileInfo file = new FileInfo(path);
            Console.WriteLine("正在读取数据");
            using (StreamReader sr = new StreamReader(file.OpenRead())) {
                message = await sr.ReadToEndAsync();
            }
            Console.WriteLine(message);
        }
    }
}

