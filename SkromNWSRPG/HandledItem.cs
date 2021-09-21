using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkromNWSRPG
{
    /*
     * Cette classe représente une arme / objet à tenir dans la main dans notre RPG
     * Elle possède une valeur de Damage
     * Elle possède une valeur de Defence
     * Elle hérite de la classe Gear
     *
     * Son constructeur prend 4 arguments:
     * - Un Name
     * - Un GearSlot
     * - Une valeur de Damage
     * - Une valeur de Defence
     *
     * Un tel objet doit forcement être:
     * - Weapon
     * - TwoHand
     * - OffHand
     *
     * Elle lance une exception si ce n'est pas le cas
     */
    public class HandledItem : Gear
    {
        public int Defence;
        public int Damage;
        public HandledItem(string name, GearSlot GearSlot, int damage, int defence)
        {
            Name = name;
            Slot = GearSlot;
            Damage = damage;
            Defence = defence;

            if (GearSlot != GearSlot.Weapon && GearSlot != GearSlot.TwoHand && GearSlot != GearSlot.OffHand)
            {
                throw new Exception("Votre objet n'est pas une arme");
            }
        }

        
    }
}
