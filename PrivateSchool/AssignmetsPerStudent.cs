using System;
using System.Collections.Generic;

namespace PrivateSchool
{
    public class AssignmetsPerStudent
    {

        Student student;
        public List<Assignment> assignmentsPerStudent { get; set; } = new List<Assignment>();
        int userSelectAssignment;
        string addAnotherAssignmentfromList;



        public void InputAssignmentsPerStudent(Student student, string userInput)
        {
            bool notSuccededAdd = true;
            Assignment assignment = new Assignment();

            this.student = student;

            if (userInput == "1") // new assignment
            {
                assignment.InputAssignment();
                student.assignments.AddRange(assignment.assignments);

                foreach (var item in assignment.assignments)
                {
                    item.students.Add(student);
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
                                assignmentsPerStudent.Add(MyDatabase.allAssignments[userSelectAssignment - 1]);
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

                    //Ask to add another assignment from the list in student
                    do
                    {
                        Console.WriteLine();
                        Console.Write("\tWould you like to add another assignment from the list to the student? Y/N : ");
                        addAnotherAssignmentfromList = Console.ReadLine();
                        Console.WriteLine();
                    } while (addAnotherAssignmentfromList.ToUpper() != "Y" && addAnotherAssignmentfromList.ToUpper() != "N");

                } while (addAnotherAssignmentfromList.ToUpper() != "N");

                student.assignments.AddRange(assignmentsPerStudent);

                foreach (var item in assignmentsPerStudent)
                {
                    item.students.Add(student);
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n\t=================================================================================\n");
                Console.ForegroundColor = ConsoleColor.White;

                assignmentsPerStudent.Clear();
            }
        }

        public void OutputAssignmetsPerStudent( int numberOfStudent)
        {
            Assignment assignment = new Assignment();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\tStudent : " + MyDatabase.allStudents[numberOfStudent].getFirstName() + " " + MyDatabase.allStudents[numberOfStudent].getLastName());

            assignment.ListOfAssignmentsOutput(MyDatabase.allStudents[numberOfStudent].assignments);
        }
    }
}
