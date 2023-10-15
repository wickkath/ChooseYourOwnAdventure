using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChooseYourOwnAdventure
{
    internal class EnglishTeacher : Teacher
    {
        private int cooldown;

        public EnglishTeacher() : base()
        {
            health = 110;
            damage = 15;
            cooldown = 2;
            teachersEncountered++;
        }

        public override int DMG
        {
            get { return damage; }
        }

        public override int fight(Student fighter)
        {
            int returnValue = 1;
            while (health > 0 && fighter.HEALTH > 0)
            {
                Console.Write("Will you attack or defend? (Please input A for attack or D for defend) ");
                string input = Console.ReadLine();
                if (input == "A")
                {
                    health -= fighter.DAMAGE;
                    if (cooldown == 0)
                    {
                        fighter.HEALTH -= damage;
                    }
                }
                else if (input == "D")
                {
                    if (cooldown == 0)
                    {
                        fighter.HEALTH -= (damage - fighter.DEFENSE);
                    }
                }
                Console.WriteLine("You have " + fighter.HEALTH + " health!");
                Console.WriteLine("Your enemy has " + health + " health remaining!");
                if (cooldown == 0)
                {
                    cooldown = 2;
                }
                else
                {
                    cooldown--;
                }
            }
            if (fighter.HEALTH <= 0) { returnValue = 2; }
            return returnValue;
        }
    }
}
