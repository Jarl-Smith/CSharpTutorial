using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventageGame {
    class Armor : Item {
        //静态字典存储所有可能出现的物品(盔甲池) 
        static readonly Dictionary<int , Armor> data =
            new Dictionary<int , Armor>() {{ 1,new Armor("铁甲", 1)},
                                                                { 2,new Armor("铜甲", 2)},
                                                                { 3,new Armor("银甲", 3)},
                                                                { 4,new Armor("金甲", 4)}};
        //该物品的防御值
        private int value;
        public Armor( string name , int value ) : base(name) {
            this.value = value;
        }

        public override void Use( Player p ) {
            if ( p.equipmentSlot["服饰"] == null ) {
                p.character.Defence += value;
                p.equipmentSlot["服饰"] = this;
            } else {
                Armor temp = p.equipmentSlot["服饰"] as Armor;
                temp.Drop(p);
                p.inventory.AddItem(temp);
                p.character.Defence += value;
                p.equipmentSlot["服饰"] = this;
            }
        }

        public override void Drop( Player p ) {
            p.character.Defence -= value;
            p.equipmentSlot["服饰"] = null;
        }
        /// <summary>
        /// 从盔甲池随机抽出一件作为掉落物品
        /// </summary>
        /// <returns>盔甲对象</returns>
        public static Armor RespawnArmor( ) {
            int key = Util.random.Next(data.Count) + 1;
            return data[key];
        }
    }
}
