using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDemo {

    //因为有自定义的EventAgs类，所以此处需要定义发布类中的委托
    //如果没有自定义的EventArgs类，就不需要定义委托
    public delegate void BoiledEventHandler<TSender, TEventArgs>( TSender obj , TEventArgs e );

    //事件发布者，包含一个委托以及回调方法，委托保存被注册的方法
    public class Heater {
        public string Producer { private set; get; }
        private int temperature;

        //将发布类中的委托作为类型，声明发布类中的委托
        private event BoiledEventHandler<Heater , BoiledEventArgs> handler;

        public Heater( ) : this("default") { }

        public Heater( string producer ) { Producer = producer; }

        //包装事件回调方法，访问修饰使之可以被派生类重写回调方法
        protected virtual void OnBoiled( BoiledEventArgs e ) {
            //判断订阅是否为空，不为空则执行回调方法
            handler?.Invoke(this , e);
        }

        public void BoilWater( ) {
            for ( int i = 0 ; i < 100 ; i++ ) {
                temperature = i;
                if ( temperature > 95 ) {
                    //生成一个自定义的参数事件对象，在处理发布方法之前可以做一些其它事情
                    BoiledEventArgs e = new BoiledEventArgs(temperature);
                    //将事件发布
                    OnBoiled(e);
                }
            }
        }

        public void RegisterMethod( BoiledEventHandler<Heater , BoiledEventArgs> method ) {
            if ( method == null ) { return; }
            handler += method;
        }

        public void RemoveMethod( BoiledEventHandler<Heater , BoiledEventArgs> method ) {
            if ( method == null ) { return; }
            handler -= method;
        }
    }
}
