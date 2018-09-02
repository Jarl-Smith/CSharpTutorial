using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventageGame {
    class Weapon : Item {
        /// <summary>
        /// 武器物品池
        /// </summary>
        static readonly Dictionary<int , Weapon> data =
            new Dictionary<int , Weapon>() {{1,new Weapon("铁剑", 1)},
                                                                 {2,new Weapon("铜剑", 2)},
                                                                 {3,new Weapon("银剑", 3)},
                                                                 {4,new Weapon("金剑", 4)} };
        private int value;//攻击力
        public Weapon( string name , int value ) : base(name) {
            this.value = value;
        }

        public override void Use( Player p ) {
            if ( p.equipmentSlot["武器"] == null ) {
                p.character.Strength += value;
                p.equipmentSlot["武器"] = this;
            } else {
                Weapon temp = p.equipmentSlot["武器"] as Weapon;
                temp.Drop(p);
                p.inventory.AddItem(temp);
                p.character.Strength += value;
                p.equipmentSlot["武器"] = this;
            }
        }

        public override void Drop( Player p ) {
            p.character.Strength -= value;
            p.equipmentSlot["武器"] = null;
        }
        /// <summary>
        /// 从武器物品池随机抽出一个作为掉落物品
        /// </summary>
        /// <returns>武器对象</returns>
        public static Weapon RespawnWeapon( ) {
            int key = Util.random.Next(data.Count) + 1;
            return data[key];
        }
    }
}
