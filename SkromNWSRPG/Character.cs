using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkromNWSRPG
{
    /*
     * Cette classe représente un Personnage dans le Jeu
     *
     * Elle possède un Name
     * Elle possède une valeur de Life
     *
     * Cette Classe possède une Méthode Equip
     * Elle prend en paramètre un équipement et l'applique au slot correspondant du Character
     *
     * Le Character peut porter une arme dans les deux mains, à condition que ce soit un Weapon
     * Un objet à deux mains bloque l'emplacement OffHand et Weapon
     *
     * équiper un objet à une main 2 fois de suite dans Weapon l'équipe dans Weapon & OffHand
     *
     *
     * Cette Classe possède une Methode GetItemInSlot
     * Elle prend en paramètre un GearSlot
     * Elle renvoie l'objet équipé à l'emplacement passé en paramètre
     * Elle renvoie null si il n'y a rien à cet emplacement
     *
     *             // Faire un dictionnaire avec clefs/valeurs GearSlot/Gear
     */
    public class Character
    {
        public string Name;
        public int Life;
        public Dictionary<GearSlot, Gear> dictionnaire = new Dictionary<GearSlot, Gear>();
        public bool isEquip = false;
        public Character(string name, int life)
        {
            Name = name;
            Life = life;
            setStuff();
        }

        public void setStuff()
        {
            dictionnaire[GearSlot.Head] = null;
            dictionnaire[GearSlot.Back] = null;
            dictionnaire[GearSlot.Chest] = null;
            dictionnaire[GearSlot.Legs] = null;
            dictionnaire[GearSlot.Feet] = null;
            dictionnaire[GearSlot.Weapon] = null;
            dictionnaire[GearSlot.TwoHand] = null;
            dictionnaire[GearSlot.OffHand] = null;
        }

        public void Equip(Gear equipment)
        {

            switch (equipment.Slot)
            {

                case GearSlot.TwoHand:
                    dictionnaire[GearSlot.Weapon] = equipment;
                    dictionnaire[GearSlot.OffHand] = null;
                    break;

                case GearSlot.Weapon:
                    if (this.isEquip == true)
                    {
                        dictionnaire[GearSlot.OffHand] = equipment;
                        this.isEquip = false;
                    }
                    else
                    {
                        dictionnaire[GearSlot.Weapon] = equipment;
                        this.isEquip = true;
                    }
                    dictionnaire[GearSlot.TwoHand] = null;
                    break;

                case GearSlot.OffHand:
                    dictionnaire[GearSlot.OffHand] = equipment;
                    dictionnaire[GearSlot.Weapon] = null;
                    break;

                case GearSlot.Head:
                    dictionnaire[GearSlot.Head] = equipment;
                    break;

                case GearSlot.Back:
                    dictionnaire[GearSlot.Back] = equipment;
                    break;

                case GearSlot.Chest:
                    dictionnaire[GearSlot.Chest] = equipment;
                    break;

                case GearSlot.Legs:
                    dictionnaire[GearSlot.Legs] = equipment;
                    break;

                case GearSlot.Feet:
                    dictionnaire[GearSlot.Feet] = equipment;
                    break;

                default:
                    throw new Exception("Votre objet n'est pas une arme/armure");
            }
        }
        public int GetTotalDamage()
        {
            HandledItem rightHand, leftHand;
            int dommage = 0;
            rightHand = (HandledItem)GetItemInSlot(GearSlot.Weapon);
            leftHand = (HandledItem)GetItemInSlot(GearSlot.OffHand);
            dommage += rightHand.Damage + leftHand.Damage;

            return dommage;
        }

        public int GetTotalDefence()
        {
            HandledItem rightHand, leftHand;
            Armor head, back, chest, legs, feet;
            int defense = 0;
            rightHand = (HandledItem)GetItemInSlot(GearSlot.Weapon);
            leftHand = (HandledItem)GetItemInSlot(GearSlot.OffHand);

            head = (Armor)GetItemInSlot(GearSlot.Head);
            back = (Armor)GetItemInSlot(GearSlot.Back);
            chest = (Armor)GetItemInSlot(GearSlot.Chest);
            legs = (Armor)GetItemInSlot(GearSlot.Legs);
            feet = (Armor)GetItemInSlot(GearSlot.Feet);

            if (dictionnaire[GearSlot.Head] != null)
            {
                defense += head.Defence;
            }
            if (dictionnaire[GearSlot.Back] != null)
            {
                defense += back.Defence;
            }
            if (dictionnaire[GearSlot.Chest] != null)
            {
                defense += chest.Defence;
            }
            if (dictionnaire[GearSlot.Legs] != null)
            {
                defense += legs.Defence;
            }
            if (dictionnaire[GearSlot.Feet] != null)
            {
                defense += feet.Defence;
            }

            defense += rightHand.Defence + leftHand.Defence;

            return defense;
        }

        public Gear GetItemInSlot(GearSlot slot)
        {
            if (dictionnaire[slot] != null)
            {
                return dictionnaire[slot];
            }
            else
            {
                return null;
            }
        }
    }
}
