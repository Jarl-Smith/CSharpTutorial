using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventageGame {
    class Goblin {
        private int health;
        private int strength;
        private int defence;
        private int aglity;
        private int maxHealth { get { return defence + aglity / 2; } set { value = defence + aglity / 2; } }
        public bool IsDead;
        public Goblin( ) {
            strength = 1;
            defence = 1;
            aglity = 1;
            health = maxHealth;
            IsDead = false;
        }
        /// <summary>
        /// 受到伤害的方法
        /// </summary>
        /// <param name="value">伤害值</param>
        public void GetHurt( int value ) {
            value = value - (defence + aglity / 2);
            health -= value > 0 ? value : 0;
            if ( health <= 0 ) {
                IsDead = true;
            }
        }
        /// <summary>
        /// 发出攻击的方法
        /// </summary>
        /// <returns>攻击力</returns>
        public int Attack( ) {
            return strength * 2 + aglity / 2;
        }

        public void ShowInfo( ) {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("{0}  生命值:{1} / {2} 攻击力:{3}" , "哥布林" , health , maxHealth , strength);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
