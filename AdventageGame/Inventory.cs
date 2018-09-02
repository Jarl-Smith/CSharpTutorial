using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventageGame {
    class Inventory {

        private List<Item> inventory;//列表用于存储物品
        private Player player;//指向player的引用
        public int Money { get; set; }

        public Inventory( Player p ) {
            player = p;
            inventory = new List<Item>() {
                Drink.RespawnDrink(),
                Weapon.RespawnWeapon()
            };
            Money = 100;
        }
        /// <summary>
        /// 背包添加物品方法
        /// </summary>
        /// <param name="e">要添加的物品</param>
        public void AddItem( Item e ) {
            IEnumerator<Item> it = inventory.GetEnumerator();
            while ( it.MoveNext() ) {
                if ( e.Equals(it.Current) ) {
                    it.Current.Count++;
                    return;
                }
            }
            inventory.Add(e);
        }
        /// <summary>
        /// 使用物品的方法
        /// </summary>
        /// <param name="number">物品显示的序号</param>
        public void UseItem( string number ) {
            if ( int.TryParse(number , out int i) ) {
                if ( i <= inventory.Count ) {
                    inventory[i - 1].Use(player);
                    if ( inventory[i - 1].Count - 1 < 1 ) {
                        inventory.Remove(inventory[i - 1]);
                    } else {
                        inventory[i - 1].Count--;
                    }
                }
            }
        }
        /// <summary>
        /// 整理背包，按照ID升序进行整理
        /// </summary>
        public void ZhengLiBeiBao( ) {
            Item[] temp = inventory.ToArray();
            Util.Sort(temp , ( Item i ) => { return i.ID; } , SortMethod.Insertion);
            inventory = temp.ToList();
        }
        /// <summary>
        /// 显示背包详情
        /// </summary>
        public void ShowInfo( ) {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("背包详情\n");
            int index = 1;
            foreach ( Item i in inventory ) {
                Console.Write("{0}. {1}:{2}\t" , index , i.Name , i.Count);
                if ( index % 5 == 0 ) {
                    Console.Write("\n");
                }
                index++;
            }
            Console.WriteLine("金币 : {0}\n\n" , Money);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
