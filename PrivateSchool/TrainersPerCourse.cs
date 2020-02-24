using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateSchool
{
    class TrainersPerCourse
    {
        Course course;
        public List<Trainer> trainersPerCourse { get; set; } = new List<Trainer>();
        int userSelectTrainer;
        string addAnotherTrainerfromList;



        public void InputTrainersPerCourse(Course course, string userInput)
        {
            bool notSuccededAdd = true;
            Trainer trainer = new Trainer();

            this.course = course;

            if (userInput == "1") //new trainer
            {
                trainer.InputTrainer();
                course.trainers.AddRange(trainer.trainers);

                foreach (var item in trainer.trainers)
                {
                    item.courses.Add(course);
                }
            }
            else if (userInput == "2")// existing trainer
            {
                do
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine();
                    Console.WriteLine("\tSelect the number of trainer.");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.White;

                    trainer.ListOfTrainersOutput(MyDatabase.allTrainers);
                    
                    do
                    {
                        try
                        {
                            Console.WriteLine();
                            Console.Write("\tEnter a propriate number : ");
                            userSelectTrainer = Convert.ToInt32(Console.ReadLine());

                            if (userSelectTrainer <= MyDatabase.allTrainers.Count && userSelectTrainer > 0)
                            {
                                trainersPerCourse.Add(MyDatabase.allTrainers[userSelectTrainer - 1]);
                                notSuccededAdd = false;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\tPlease select a propriate number.");
                                Console.ForegroundColor = ConsoleColor.White;
                                notSuccededAdd = true;
                            }
                        }
                        catch (Exception)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\tPlease select a propriate number.");
                            Console.ForegroundColor = ConsoleColor.White;
                            notSuccededAdd = true;
                        }
                    } while (notSuccededAdd);

                    //Ask to add another trainer from the list in course
                    do
                    {
                        Console.WriteLine();
                        Console.Write("\tWould you like to add another trainer from the list in course? Y/N : ");
                        addAnotherTrainerfromList = Console.ReadLine();
                        Console.WriteLine();
                    } while (addAnotherTrainerfromList.ToUpper() != "Y" && addAnotherTrainerfromList.ToUpper() != "N");

                } while (addAnotherTrainerfromList.ToUpper() != "N");

                course.trainers.AddRange(trainersPerCourse);

                foreach (var item in trainersPerCourse)
                {
                    item.courses.Add(course);
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n\t=================================================================================\n");
                Console.ForegroundColor = ConsoleColor.White;

                trainersPerCourse.Clear();
            }
        }

        public void OutputTrainersPerCourse(int numberOfCourse)
        {
            Trainer trainer = new Trainer();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\tCourse : " + MyDatabase.allCourses[numberOfCourse].getTitle());

            trainer.ListOfTrainersOutput(MyDatabase.allCourses[numberOfCourse].trainers);
        }
    }
}
