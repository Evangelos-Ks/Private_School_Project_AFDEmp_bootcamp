using System;
using System.Collections.Generic;

namespace PrivateSchool
{
    public class Trainer
    {
        //Fields==============================================================================================================
        private string firstName;
        private string lastName;
        private string subject;

        public List<Trainer> trainers = new List<Trainer>();
        public List<Course> courses = new List<Course>();

        //Constructors==================================================================================================================
        public Trainer() { }

        public Trainer(string firstName, string lastName, string subject)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.subject = subject;
        }



        //Getters & setters==============================================================================================================
        public string getFirstName () { return firstName; }
        public void setFirstName (string firstName) { this.firstName = firstName; }

        public string getLastName() { return lastName; }
        public void setLastName(string lastName) { this.lastName = lastName; }

        public string getSubject() { return subject; }
        public void setSubject(string subject) { this.subject = subject; }

        //Methods==============================================================================================================
        public void InputTrainer()
        {
            string addAnotherTrainer = "";

            do
            {
                Trainer trainer = new Trainer();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine();
                Console.WriteLine("\tNew trainer");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;

                //Input fields
                Console.WriteLine();
                Console.Write("\tFirst Name : ");
                trainer.firstName = Console.ReadLine();

                Console.Write("\tLast Name : ");
                trainer.lastName = Console.ReadLine();

                Console.Write("\tSubject : ");
                trainer.subject = Console.ReadLine();

                trainers.Add(trainer);
                MyDatabase.allTrainers.Add(trainer);

                //Ask to continue
                do
                {
                    Console.WriteLine();
                    Console.Write("\tWould you like to add another course? Y/N : ");
                    addAnotherTrainer = Console.ReadLine();
                } while (addAnotherTrainer.ToUpper() != "Y" && addAnotherTrainer.ToUpper() != "N");

            } while (addAnotherTrainer.ToUpper() != "N");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\t=================================================================================\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        //Output list of trainers---------------------------------------------------------------------------------------
        public void ListOfTrainersOutput(List<Trainer> trainers)
        {
            int counter = 1;
            int longestFirstName = 1;
            int longestLastName = 1;
            int differenceAtFirstNameLength;
            int differenceAtLastNameLength;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            Console.WriteLine("\tList of trainers");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            for (int i = 0; i < trainers.Count; i++) //Find the longest first name of list students
            {
                if (trainers[i].firstName.Length > longestFirstName)
                {
                    longestFirstName = trainers[i].firstName.Length;
                }

                if (trainers[i].lastName.Length > longestLastName) //Find the longest first last of list students
                {
                    longestLastName = trainers[i].lastName.Length;
                }
            }

            //Headings
            Console.ForegroundColor = ConsoleColor.Yellow;
            if ((longestFirstName - "First name".Length) > 0) //Output Headings
            {
                Console.Write("\t" + "      " + "First name" + new string(' ', longestFirstName - "First name".Length) + "  ");
            }
            else
            {
                Console.Write("\t" + "      " + "First name" + "  ");
            }

            if ((longestLastName - "Last name".Length) > 0) //Output Headings
            {
                Console.WriteLine("Last name" + new string(' ', longestLastName - "Last name".Length) + "  " + "Subject");
            }
            else
            {
                Console.WriteLine("Last name" + "  " + "Subject");
            }
            Console.ForegroundColor = ConsoleColor.White;

            //Output all fields alligned
            foreach (var item in trainers)
            {
                if (counter > 9) //Counter
                {
                    Console.Write("\t" + (counter) + ".   ");
                }
                else if (counter > 99)
                {
                    Console.Write("\t" + (counter) + ".  ");
                }
                else
                {
                    Console.Write("\t" + (counter) + ".    ");
                }

                differenceAtFirstNameLength = longestFirstName - item.firstName.Length;
                if (differenceAtFirstNameLength > 0 && ((longestFirstName - "First name".Length) >= 0)) //First Name
                {
                    Console.Write(item.firstName + new string(' ', differenceAtFirstNameLength) + "  ");
                }
                else if ((longestFirstName - "First name".Length) < 0)
                {
                    Console.Write(item.firstName + new string(' ', differenceAtFirstNameLength + ("First name".Length - longestFirstName)) + "  ");
                }
                else
                {
                    Console.Write(item.firstName + "  ");
                }

                differenceAtLastNameLength = longestLastName - item.lastName.Length;
                if (differenceAtLastNameLength > 0 && ((longestLastName - "Last name".Length) >= 0)) //Last Name and the other fields
                {
                    Console.WriteLine(item.lastName + new string(' ', differenceAtLastNameLength) + "  " + item.subject);
                }
                else if ((longestLastName - "Last name".Length) < 0)
                {
                    Console.WriteLine(item.lastName + new string(' ', differenceAtLastNameLength + ("Last name".Length - longestLastName)) + "  " + item.subject);
                }
                else
                {
                    Console.WriteLine(item.lastName + "  " + item.subject);
                }
                counter++;
            }
        }
    }
}
