using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventageGame {
    class Program {
        static void Main( string[] args ) {
            Console.WriteLine("请输入名字");
            string name = Console.ReadLine();
            Console.Write("1.战士 2.法师 3.盗贼 4.圣骑士\n请选择职业:");
            string typeInput = Console.ReadLine();
            Player p = new Player(name,typeInput);
            GameLoop(p);
        }
        static void GameLoop( Player p ) {
            bool isOver = false;
            while ( p.character.Health > 0 && !isOver ) {
                Console.Clear();
                p.ShowInfo();//显示人物的属性、背包
                Console.WriteLine("1.打开背包 2.打怪 3.退出游戏");
                switch ( Console.ReadLine() ) {
                    case "1": Loot(p); break;
                    case "2": Battle(p); break;
                    case "3": isOver = true; break;
                    default: break;
                }
                Console.ReadLine();
            }
            Console.WriteLine("游戏结束");
        }
        //背包详情
        static void Loot( Player player ) {
            Console.WriteLine("1.使用物品 2.整理背包");
            switch ( Console.ReadLine() ) {
                case "1":
                    Console.WriteLine("请输入物品序号");
                    string input = Console.ReadLine();
                    player.inventory.UseItem(input);
                    break;
                case "2":
                    player.inventory.ZhengLiBeiBao();
                    break;
                default: break;
            }
        }

        static void Battle( Player player ) {
            Goblin g = new Goblin();
            while ( !g.IsDead ) {
                Console.Clear();
                player.character.ShowInfo();
                g.ShowInfo();
                Console.WriteLine("1.普通攻击 2.技能");
                string input = Console.ReadLine();
                switch ( input ) {
                    case "1":
                        g.GetHurt(player.Attack());
                        if ( !g.IsDead ) {
                            player.GetHurt(g.Attack());
                        }
                        break;
                    case "2": break;
                    default: break;
                }
                if ( player.character.Health <= 0 ) {
                    Console.WriteLine("You Dead.");
                    return;
                }
            }
            //获得经验
            player.experience.GainExperience(5);

            //随机生成掉落物品
            switch ( Util.random.Next(5) ) {
                case 0:
                case 1: player.inventory.AddItem(Drink.RespawnDrink()); break;
                case 2: player.inventory.AddItem(Shoe.RespawnShoe()); break;
                case 3: player.inventory.AddItem(Weapon.RespawnWeapon()); break;
                case 4: player.inventory.AddItem(Armor.RespawnArmor()); break;
            }
        }
    }
}