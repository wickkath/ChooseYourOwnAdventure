using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChooseYourOwnAdventure
{
    internal class Student
    {
        private int health = 100;
        private int damage = 20;
        private int defense = 10;
        private string name;
        private int totalMoney;

        public Student(string yourName)
        {
            name = yourName;
        }

        public string NAME 
        {
            get { return name; }
        }

        public int HEALTH
        {
            get { return health; }
            set { health = value; }
        }

        public int DAMAGE
        {
            get { return damage; }
        }

        public int DEFENSE
        {
            get { return defense; }
        }

        public int MONEY
        {
            get { return totalMoney; }
            set { totalMoney = value; }
        }
    }
}
