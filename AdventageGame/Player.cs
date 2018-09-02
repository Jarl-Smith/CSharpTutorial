using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventageGame {
    /// <summary>
    /// Player作为一个容器，包含角色类，背包类，经验类，装备槽字段
    /// </summary>
    class Player {

        public string UserName { get; private set; }
        public Character character;
        public Inventory inventory;
        public Experience experience;
        public Dictionary<string , Item> equipmentSlot;

        public Player( string userName , string type ) {
            UserName = userName;
            character = CharacterFactory.CreateCharacter(type , this);
            inventory = new Inventory(this);
            experience = new Experience(this);
            equipmentSlot = new Dictionary<string , Item>() { { "武器" , null } , { "服饰" , null } , { "鞋子" , null } };
        }
        /// <summary>
        /// 受到伤害的方法
        /// </summary>
        /// <param name="value">伤害值</param>
        public void GetHurt( int value ) {
            value = value - (character.Defence + character.Aglity / 2);
            character.Health -= value > 0 ? value : 0;
        }
        /// <summary>
        /// 发出攻击的方法
        /// </summary>
        /// <returns>攻击力</returns>
        public int Attack( ) {
            return character.Strength * 2 + character.Aglity / 2;
        }

        public void ShowInfo( ) {
            character.ShowInfo();
            inventory.ShowInfo();
            experience.ShowInfo();
            Console.WriteLine("{0} : {1}   {2} : {3}   {4} : {5}" , "武器" , equipmentSlot["武器"]?.Name , "服饰" , equipmentSlot["服饰"]?.Name , "鞋子" , equipmentSlot["鞋子"]?.Name);
            Console.Write("\n");
        }
    }
}