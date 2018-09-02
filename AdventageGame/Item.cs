using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventageGame {
    abstract class Item {

        public string Name { get; set; }
        public int Count { get; set; }
        public int ID { get; set; }
        private static int index = 1;

        public Item( string name ) {
            Name = name;
            Count = 1;
            ID = index++;
        }

        public abstract void Use( Player p );
        public abstract void Drop( Player p );

        /// <summary>
        /// 重写判断是否相等的方法，判断依据为物品id是否相等
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals( object obj ) {
            int id = ((Item)obj).ID;
            return ID == id;
        }
    }
}
