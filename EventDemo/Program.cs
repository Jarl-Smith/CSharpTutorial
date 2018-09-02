using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EventDemo {

    public class Program {
        public static void Main( String[] args ) {
            Program p = new Program();
            p.test1();
            Console.ReadLine();
        }

        public void test1( ) {
            Heater heater = new Heater();
            Display display = new Display();
            Alarm alarm = new Alarm();
            //多播委托演示
            heater.RegisterMethod(display.ShowMsg);
            heater.RegisterMethod(alarm.MakeAlart);
            heater.BoilWater();
        }
    }
}