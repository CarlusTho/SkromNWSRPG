using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkromNWSRPG
{
    /*
     * Cette classe représente un équipement dans notre RPG
     * Il possède un emplacement d'équipement var Slot de type GearSlot
     * C'est une classe Abstraite
     * Elle hérite de la classe Item
     */
    public abstract class Gear : Item
    {
        public GearSlot Slot;
    }
}
