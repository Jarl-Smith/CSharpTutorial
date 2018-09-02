using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDemo {
    //订阅者，包含注册方法
    public class Display {
        //被注册的方法，订阅者收到事件后需要执行的方法
        public void ShowMsg( Heater obj , BoiledEventArgs e ) {
            Console.WriteLine("Display recived event,temperature: {0} ,made by {1}" , e.Tempareture , obj.Producer);
        }
    }
}
