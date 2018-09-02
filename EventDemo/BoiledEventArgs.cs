using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDemo {
    //自定义参数事件类，继承EventArgs类，派生类事件可以保存数据
    public class BoiledEventArgs : EventArgs {

        public int Tempareture { private set; get; }

        public BoiledEventArgs( int temp ) {
            Tempareture = temp;
        }
    }
}
