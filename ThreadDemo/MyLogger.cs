using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeiCui.Unity
{
    namespace ThreadDemo
    {

        class MyLogger
        {
            private StringBuilder sb;
            public string FilePosition { set; get; }

            public MyLogger()
            {
                sb = new StringBuilder();
            }

            private void SetFilePosition()
            {
                Console.WriteLine("请输入文件全名");
                FilePosition = Console.ReadLine();
            }

            private void Logging()
            {
                Console.WriteLine("开始日志");
                sb.Append(DateTime.Now + "\n\n");
                string temp = "";
                while (true)
                {
                    temp = Console.ReadLine();
                    if (temp.ToLower() == "esc") { break; }
                    sb.Append(temp + '\n');
                }

                Console.WriteLine("用户结束日志");
            }
            private void Record()
            {
                Console.WriteLine("开始保存日志");
                StreamWriter writer = null;
                try
                {
                    writer = new StreamWriter(FilePosition, true, Encoding.UTF8);
                    writer.Write(sb);
                    Console.WriteLine("日志保存成功");
                    sb.Clear();
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    if (writer != null)
                    {
                        writer.Close();
                    }
                }
            }

            public void Start()
            {
                SetFilePosition();
                Logging();
                Record();
            }
        }
    }
}

