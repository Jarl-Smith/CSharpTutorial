using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventageGame {

    abstract class Character {

        public int Strength { get; set; }//力量
        public int Aglity { get; set; }//敏捷
        public int Intelligence { get; set; }//智力
        public int Defence { get; set; }//防御
        public int Health { get; set; }//生命值
        public int Magic { get; set; }//魔法值

        protected int maxHealth { get { return Defence + Aglity / 2 + Strength / 2; } set { value = Defence + Aglity / 2 + Strength / 2; } }
        protected int maxMagic { get { return Intelligence * 2; } set { value = Intelligence * 2; } }
        protected Player player;

        public Character( Player p ) {
            player = p;
        }

        public abstract void LevelUp( );

        /// <summary>
        /// 显示角色信息
        /// </summary>
        public abstract void ShowInfo( );
    }
}
