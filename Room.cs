using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChooseYourOwnAdventure
{
    internal class Room
    {
        private Room left;
        private Room right;
        private int courseNumber;

        public Room(int newCourse)
        {
            courseNumber = newCourse;
            left = null;
            right = null;
        }

        public Room LEFT { get { return left; } }
        public Room RIGHT { get { return right; } }

        public void addRoom(int identification)
        {
            if (courseNumber > identification)
            {
                if (left != null)
                {
                    left.addRoom(identification);
                }
                else
                {
                    left = new Room(identification);
                }
            }
            else if (courseNumber < identification)
            {
                if (right != null)
                {
                    right.addRoom(identification);
                }
                else 
                { 
                    right = new Room(identification);
                }
            }
        }

        public int generateThing(Student fighter)
        {
            var rand = new Random();
            int randomSelect = rand.Next(0, 4);                     // generates 4 options for random selection of obstacle
            Teacher newTeacher;
            int returnValue = 0;
            if (randomSelect == 0)
            {
                fighter.MONEY += 5 + rand.Next(6);
                Console.WriteLine("Congrats! There were no enemies around! You now have " + fighter.MONEY + " dollars!");
            }
            else if (randomSelect == 1)
            {
                newTeacher = new Teacher();
                Console.WriteLine("Oh no! You have to battle a teacher!");
                returnValue = newTeacher.fight(fighter);
            }
            else if (randomSelect == 2)
            {
                newTeacher = new MathTeacher();
                Console.WriteLine("Oh no! You have to battle a math teacher!");
                returnValue = newTeacher.fight(fighter);
            }
            else if (randomSelect == 3)
            {
                newTeacher = new EnglishTeacher();
                Console.WriteLine("Oh no! You have to battle an english teacher!");
                returnValue = newTeacher.fight(fighter);
            }
            return returnValue;                                     // returns 1 upon a successful fight, 2 upon failure, and 0 upon not fighting at all
        }

        public int checkRooms()
        {
            int returnCondition = 0;
            if (left != null)
            {
                returnCondition = 1;
            }
            else if (right != null)
            {
                returnCondition = 2;
            }
            else if ((left != null) && (right != null))
            {
                returnCondition = 3;
            }
            return returnCondition;                                 //returns 0 if no movement options are available, otherwise returns based on which options are available
        }
    }
}
