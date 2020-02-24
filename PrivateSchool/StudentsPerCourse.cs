using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateSchool
{
    public class StudentsPerCourse //add students in course.
    {
        Course course;
        public List<Student> studentsPerCourse { get; set; } = new List<Student>();
        int userSelectStudent;
        string addAnotherStudentfromList;



        public void InputStudentsPerCourse(Course course, string userInput)
        {
            bool notSuccededAdd = true;
            Student s = new Student();

            this.course = course;

            if (userInput == "1") //New student
            {
                s.InputStudent();
                course.students.AddRange(s.students);

                foreach (var item in s.students)
                {
                    item.courses.Add(course);
                }
            }
            else if (userInput == "2") //Existing student 
            {
                do
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine();
                    Console.WriteLine("\tSelect the number of student.");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.White;

                    s.ListOfStudentsOutput(MyDatabase.allStudents);;

                    do
                    {
                        try
                        {
                            Console.WriteLine();
                            Console.Write("\tEnter a propriate number : ");

                            userSelectStudent = Convert.ToInt32(Console.ReadLine());                         
                            if (userSelectStudent <= MyDatabase.allStudents.Count && userSelectStudent > 0)
                            {
                                studentsPerCourse.Add(MyDatabase.allStudents[userSelectStudent - 1]);
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

                    //Ask to add another student from the list in course
                    do
                    {
                        Console.WriteLine();
                        Console.Write("\tWould you like to add another student from the list in course? Y/N : ");
                        addAnotherStudentfromList = Console.ReadLine();
                        Console.WriteLine();
                    } while (addAnotherStudentfromList.ToUpper() != "Y" && addAnotherStudentfromList.ToUpper() != "N");
                  
                } while (addAnotherStudentfromList.ToUpper() != "N");

                course.students.AddRange(studentsPerCourse);

                foreach (var item in studentsPerCourse)
                {
                    item.courses.Add(course);
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n\t=================================================================================\n");
                Console.ForegroundColor = ConsoleColor.White;

                studentsPerCourse.Clear();
            }
        }

        public void OutputStudentsPerCourse( int numberOfCourse)
        {
            Student student = new Student();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\tCourse : " + MyDatabase.allCourses[numberOfCourse].getTitle());

            student.ListOfStudentsOutput(MyDatabase.allCourses[numberOfCourse].students);
        }

    }
}
