using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChooseYourOwnAdventure
{
    internal class MathTeacher : Teacher
    {
        private int cooldown;

        public MathTeacher() : base()
        {
            health = 120;
            damage = 25;
            cooldown = 3;
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
                    cooldown = 3;
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
