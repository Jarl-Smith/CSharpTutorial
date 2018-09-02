using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventageGame {
    class Shoe : Item {
        //鞋子物品池
        static readonly Dictionary<int , Shoe> data =
            new Dictionary<int , Shoe>() {{1,new Shoe("铁鞋", 1)},
                                                             {2,new Shoe("铜鞋", 2)},
                                                             {3,new Shoe("银鞋", 3)},
                                                             {4,new Shoe("金鞋", 4)} };

        private int value;//敏捷
        public Shoe( string name , int value ) : base(name) {
            this.value = value;
        }

        public override void Use( Player p ) {
            if ( p.equipmentSlot["鞋子"] == null ) {
                p.character.Aglity += value;
                p.equipmentSlot["鞋子"] = this;
            } else {
                Shoe temp = p.equipmentSlot["鞋子"] as Shoe;
                temp.Drop(p);
                p.inventory.AddItem(temp);
                p.character.Aglity += value;
                p.equipmentSlot["鞋子"] = this;
            }
        }

        public override void Drop( Player p ) {
            p.character.Aglity -= value;
            p.equipmentSlot["鞋子"] = null;
        }
        /// <summary>
        /// 从鞋子物品池随机抽出一个作为掉落物品
        /// </summary>
        /// <returns>鞋子对象</returns>
        public static Shoe RespawnShoe( ) {
            int key = Util.random.Next(data.Count) + 1;
            return data[key];
        }
    }
}
