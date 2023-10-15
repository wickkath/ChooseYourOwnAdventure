using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChooseYourOwnAdventure
{
    internal class Teacher
    {
        protected int health;
        protected int damage;
        protected static int teachersEncountered;

        public Teacher()
        {
            health = 100;
            damage = 10;
            teachersEncountered++;
        }

        public virtual int DMG
        {
            get { return damage; }
        }

        public int NUMTEACHERS
        {
            get { return teachersEncountered; }
        }

        public virtual int fight(Student fighter)
        {
            int returnValue = 1;
            while (health > 0 && fighter.HEALTH > 0)
            {
                Console.Write("Will you attack or defend? (Please input A for attack or D for defend) ");
                string input = Console.ReadLine();
                if (input == "A")
                {
                    health -= fighter.DAMAGE;
                    fighter.HEALTH -= damage;
                }
                else if (input == "D")
                {
                    fighter.HEALTH -= (damage - fighter.DEFENSE);
                }
                Console.WriteLine("You have " + fighter.HEALTH + " health!");
                Console.WriteLine("Your enemy has " + health + " health remaining!");
            }
            if (fighter.HEALTH <= 0) { returnValue = 2; }                       // returns 1 upon a succcessful fight, and 2 upon a failure
            return returnValue;
        }
    }
}
