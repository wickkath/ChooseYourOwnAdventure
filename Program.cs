namespace ChooseYourOwnAdventure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to school! Your goal is to make as much money as you can,");
            Console.WriteLine("while avoiding being defeated by your teachers!");
            Console.Write("Please enter your first name: ");
            string name = Console.ReadLine();
            Student you = new Student(name);
            Console.WriteLine("Alright, " + you.NAME + ", time for you to begin your schooling journey!");
            Console.WriteLine("");

            Room startingRoom = new Room(201);                               // root room, starting with course 201 so that there are ample choices
            for (int i = 0; i < 14; i++)                                     // 15 rooms total, including the root room
            {
                var rand = new Random();
                startingRoom.addRoom(rand.Next(102, 300));                   // adding courses with designations from 102 to 299
            }

            Room currentLocation = startingRoom;
            int successValue = 0;
            int roomsAvailable = 1;
            while (you.HEALTH > 0 && successValue != 2 && roomsAvailable != 0)
            {
                successValue = currentLocation.generateThing(you);
                if (successValue == 1)
                {
                    Console.WriteLine("For defeating the teacher, you get a reward!");
                    var rand = new Random();
                    you.MONEY += 5 + rand.Next(6);
                    Console.WriteLine("Congrats! You now have " + you.MONEY + " dollars!");
                    if (you.HEALTH <= 0)
                    {
                        break;
                    }
                }
                Console.WriteLine("Which room would you like to go to next?");
                roomsAvailable = currentLocation.checkRooms();
                if (roomsAvailable == 0)
                {
                    Console.WriteLine("Congrats! You've made it to the end!");
                }
                else if (roomsAvailable == 1)
                {
                    Console.WriteLine("The only way forwards is to the left! You enter the door on your left...");
                    currentLocation = currentLocation.LEFT;
                }
                else if (roomsAvailable == 2)
                {
                    Console.WriteLine("The only way forwards is to the right! You enter the door on your right...");
                    currentLocation = currentLocation.RIGHT;
                }
                else if (roomsAvailable == 3)
                {
                    Console.WriteLine("Two doors are before you, one on your left and one on the right");
                    Console.WriteLine("Which would you like to enter? (L for left and R for right) ");
                    string nextLocation = Console.ReadLine();
                    if (nextLocation == "R") { currentLocation = currentLocation.RIGHT; }
                    else if (nextLocation == "L") { currentLocation = currentLocation.LEFT; }
                }
                you.HEALTH += 5;
            }
            Teacher exampleTeacher = new Teacher();
            if (you.HEALTH <= 0)
            {
                Console.WriteLine("You lost, but over your journey you made " + you.MONEY + " dollars and");
                Console.WriteLine("fought " + (exampleTeacher.NUMTEACHERS - 1) + " teachers!");
            }
            else if (roomsAvailable == 0)
            {
                Console.WriteLine("You won, and over your journey you made " + you.MONEY + " dollars and");
                Console.WriteLine("fought " + (exampleTeacher.NUMTEACHERS - 1) + " teachers! Congratulations!");
            }
        }
    }
}