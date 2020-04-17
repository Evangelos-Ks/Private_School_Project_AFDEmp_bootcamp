using System;
using System.Collections.Generic;

namespace PrivateSchool
{
    public class AssignmentsPerCourse
    {
        Course course;
        public List<Assignment> assignmentsPerCourse { get; set; } = new List<Assignment>();
        int userSelectAssignment;
        string addAnotherAssignmentfromList;



        public void InputAssignmentsPerCourse(Course course, string userInput)
        {
            bool notSuccededAdd = true;
            Assignment assignment = new Assignment();

            this.course = course;

            if (userInput == "1") // new assignment
            {
                assignment.InputAssignment();
                course.assignments.AddRange(assignment.assignments);

                foreach (var item in assignment.assignments)
                {
                    item.courses.Add(course);
                }
            }
            else if (userInput == "2") // existing assignment
            {
                do
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine();
                    Console.WriteLine("\tSelect the number of assignment.");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.White;

                    assignment.ListOfAssignmentsOutput(MyDatabase.allAssignments);

                    do
                    {
                        try
                        {
                            Console.WriteLine();
                            Console.Write("\tEnter a propriate number : ");
                            userSelectAssignment = Convert.ToInt32(Console.ReadLine());

                            if (userSelectAssignment <= MyDatabase.allAssignments.Count && userSelectAssignment > 0)
                            {
                                assignmentsPerCourse.Add(MyDatabase.allAssignments[userSelectAssignment - 1]);
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

                    //Ask to add another assignment from the list in course
                    do
                    {
                        Console.WriteLine();
                        Console.Write("\tWould you like to add another assignment from the list in course? Y/N : ");
                        addAnotherAssignmentfromList = Console.ReadLine();
                        Console.WriteLine();
                    } while (addAnotherAssignmentfromList.ToUpper() != "Y" && addAnotherAssignmentfromList.ToUpper() != "N");

                } while (addAnotherAssignmentfromList.ToUpper() != "N");

                course.assignments.AddRange(assignmentsPerCourse);

                foreach (var item in assignmentsPerCourse)
                {
                    item.courses.Add(course);
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n\t=================================================================================\n");
                Console.ForegroundColor = ConsoleColor.White;

                assignmentsPerCourse.Clear();
            }
        }

        public void OutputAssignmetsPerCourse( int numberOfCourse)
        {
            Assignment assignment = new Assignment();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\tCourse : " + MyDatabase.allCourses[numberOfCourse].getTitle());

            assignment.ListOfAssignmentsOutput(MyDatabase.allCourses[numberOfCourse].assignments);
        }
    }
}
