using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventageGame {
    class Experience {

        private int MaxExperience { get { return Level * 10; } set { value = Level * 10; } }
        private int CurrentExperience { get; set; }
        private int Level { get; set; }
        private Player player;

        public Experience( Player p ) {
            player = p;
            Level = 1;
            CurrentExperience = 0;
        }

        public void GainExperience( int e ) {
            CurrentExperience += e;
            if ( CurrentExperience >= MaxExperience ) {
                Level++;
                player.character.LevelUp();
            }
        }

        public void ShowInfo( ) {
            Console.WriteLine("等级:{0}  经验值:{1} / {2}\n\n" , Level , CurrentExperience , MaxExperience);
        }
    }
}
