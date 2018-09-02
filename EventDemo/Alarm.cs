using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDemo {
    //订阅者，包含注册方法
    class Alarm {
        //被注册的方法，订阅者收到事件后需要执行的方法
        //按照.NET Framework准则，注册方法需要接收两个参数，第一个参数是事件源，第二个是自定义事件
        public void MakeAlart( Heater obj , BoiledEventArgs e ) {
            Console.WriteLine("Alarm recived event,temperature: {0} ,made by {1}" , e.Tempareture , obj.Producer);
        }
    }
}
