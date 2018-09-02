using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventageGame {
    class WarriorCharacter : Character {

        public WarriorCharacter( Player p ) : base(p) {
            Strength = 3;
            Aglity = 1;
            Intelligence = 1;
            Defence = 1;

            Health = maxHealth;
            Magic = maxMagic;
        }

        public override void LevelUp( ) {
            Strength += 3;
            Aglity += 1;
            Intelligence += 1;
            Defence += 1;

            Health = maxHealth;
            Magic = maxMagic;
        }

        public override void ShowInfo( ) {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("玩家 : {0} 职业 : {1}" , player.UserName , "战士");
            Console.WriteLine("{0} : {1}    {2} : {3}" , "力量" , Strength , "敏捷" , Aglity);
            Console.WriteLine("{0} : {1}    {2} : {3}" , "智力" , Intelligence , "防御" , Defence);
            Console.WriteLine("-------------------");
            Console.WriteLine("{0} : {1}/{2}   {3} : {4}/{5}\n\n" , "HP" , Health , maxHealth , "MP" , Magic , maxMagic);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
