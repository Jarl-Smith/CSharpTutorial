using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventageGame {
    class Drink : Item {
        //血瓶池
        static readonly Dictionary<int , Drink> data =
            new Dictionary<int , Drink>() {{1,new Drink("药草", 1)},
                                                             {2,new Drink("小血瓶", 2)},
                                                             {3,new Drink("血瓶", 3)},
                                                             {4,new Drink("大血瓶", 4)},
                                                             {5,new Drink("超级血瓶", 5)} };
        private int value;
        public Drink( string name , int value ) : base(name) {
            this.value = value;
        }

        public override void Use( Player p ) {
            p.character.Health += value;
        }

        public override void Drop( Player p ) { }

        /// <summary>
        /// 血瓶物品池随机抽出一件作为掉落物品
        /// </summary>
        /// <returns>血瓶对象</returns>
        public static Drink RespawnDrink( ) {
            int key = Util.random.Next(data.Count) + 1;
            return data[key];
        }
    }
}
