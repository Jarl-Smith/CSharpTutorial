using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventageGame {
    class CharacterFactory {

        public static Character CreateCharacter(string type,Player p ) {
            Character c;
            switch ( type ) {
                case "2": c = new WarriorCharacter(p);break;
                case "3": c = new WizardCharacter(p);break;
                case "4": c = new TheifCharater(p);break;
                default: c = new WarriorCharacter(p);break;
            }
            return c;
        }
    }
}
