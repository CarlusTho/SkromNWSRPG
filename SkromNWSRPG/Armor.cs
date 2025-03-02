﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkromNWSRPG
{
    /*
     * Cette classe représente une armure dans notre RPG
     * Elle possède une valeur de Defence
     * Elle hérite de la classe Gear
     *
     * Son constructeur prend 3 arguments:
     * - Un Name
     * - Un GearSlot
     * - Une valeur de Defence
     *
     * Une armure ne peut pas être:
     * - Weapon
     * - TwoHand
     * - OffHand
     *
     * Elle lance une exception si c'est le cas
     */
    public class Armor : Gear
    {
        public int Defence;
        public Armor(string name, GearSlot GearSlot, int defence)
        {
            Name = name;
            Slot = GearSlot;
            Defence = defence;



            if (GearSlot == GearSlot.Weapon || GearSlot == GearSlot.TwoHand || GearSlot == GearSlot.OffHand)
            {
                throw new Exception("Votre armure ne peux pas être une arme");
            }
        }

        
    }
}
