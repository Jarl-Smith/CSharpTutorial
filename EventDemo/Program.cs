using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeiCui.Unity
{
    namespace EventDemo
    {
        public class Program
        {
            public static void Main(String[] args)
            {
                Program p = new Program();
                p.test1();
                Console.ReadLine();
            }

            public void test1()
            {
                Heater heater = new Heater();
                Display display = new Display();
                Alarm alarm = new Alarm();
                //多播委托演示
                heater.Boiled += display.ShowMsg;
                heater.Boiled += alarm.MakeAlart;
                heater.BoilWater();
            }
        }

        //因为有自定义的EventAgs类，所以此处需要定义发布类中的委托
        //如果没有自定义的EventArgs类，就不需要定义委托
        public delegate void BoiledEventHandler<TSender, TEventArgs>(TSender obj, TEventArgs e);

        //自定义参数事件类，继承EventArgs类，派生类事件可以保存数据
        public class BoiledEventArgs : EventArgs
        {
            public int Tempareture { private set; get; }
            public BoiledEventArgs(int temp)
            {
                Tempareture = temp;
            }
        }

        //事件发布者，包含一个委托以及回调方法，委托保存被注册的方法
        public class Heater
        {
            public string Producer { private set; get; }
            private int temperature;
            
            //将发布类中的委托作为类型，声明发布类中的委托
            public event BoiledEventHandler<Heater,BoiledEventArgs> Boiled;

            public Heater() : this("default") { }

            public Heater(string producer) { Producer = producer; }

            //包装事件回调方法，访问修饰使之可以被派生类重写回调方法
            protected virtual void OnBoiled(BoiledEventArgs e)
            {
                //判断订阅是否为空，不为空则执行回调方法
                Boiled?.Invoke(this, e);
            }

            public void BoilWater()
            {
                for (int i = 0; i < 100; i++)
                {
                    this.temperature = i;
                    if (this.temperature > 95)
                    {
                        //生成一个自定义的参数事件对象，在处理发布方法之前可以做一些其它事情
                        BoiledEventArgs e = new BoiledEventArgs(this.temperature);
                        //将事件发布
                        OnBoiled(e);
                    }
                }
            }
        }

        //订阅者，包含注册方法
        public class Alarm
        {
            //被注册的方法，订阅者收到事件后需要执行的方法
            //按照.NET Framework准则，注册方法需要接收两个参数，第一个参数是事件源，第二个是自定义事件
            public void MakeAlart(Heater obj, BoiledEventArgs e)
            {
                Console.WriteLine("Alarm recived event,temperature: {0} ,made by {1}", e.Tempareture, obj.Producer);
            }
        }

        //订阅者，包含注册方法
        public class Display
        {
            //被注册的方法，订阅者收到事件后需要执行的方法
            public void ShowMsg(Heater obj, BoiledEventArgs e)
            {
                Console.WriteLine("Display recived event,temperature: {0} ,made by {1}", e.Tempareture, obj.Producer);
            }
        }
    }
}