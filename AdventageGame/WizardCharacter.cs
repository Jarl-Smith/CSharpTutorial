using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventageGame {
    class WizardCharacter : Character {

        public WizardCharacter( Player p ):base(p) {
            Strength = 1;
            Aglity = 1;
            Intelligence = 3;
            Defence = 1;

            Health = maxHealth;
            Magic = maxMagic;
        }

        public override void LevelUp( ) {
            Strength += 1;
            Aglity += 1;
            Intelligence += 3;
            Defence += 1;

            Health = maxHealth;
            Magic = maxMagic;
        }

        public override void ShowInfo( ) {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("玩家 : {0} 职业 : {1}" , player.UserName , "法师");
            Console.WriteLine("{0} : {1}    {2} : {3}" , "力量" , Strength , "敏捷" , Aglity);
            Console.WriteLine("{0} : {1}    {2} : {3}" , "智力" , Intelligence , "防御" , Defence);
            Console.WriteLine("-------------------");
            Console.WriteLine("{0} : {1}/{2}   {3} : {4}/{5}\n\n" , "HP" , Health , maxHealth , "MP" , Magic , maxMagic);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
