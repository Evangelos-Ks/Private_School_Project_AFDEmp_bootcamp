using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateSchool
{
    public class Student
    {
        //Fields==============================================================================================================
        private string firstName;
        private string lastName;
        private DateTime dateOfBirth;
        private decimal tuitionFees;

        public List<Student> students = new List<Student>();
        public List<Course> courses = new List<Course>();
        public List<Assignment> assignments = new List<Assignment>();

        //Constructors===================================================================================================================
        public Student() { }

        public Student(string firstName, string lastName, DateTime dateOfBirth, decimal tuitionFees)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.dateOfBirth = dateOfBirth;
            this.tuitionFees = tuitionFees;
        }



        //Getters & setters==============================================================================================================
        public string getFirstName() { return firstName; }
        public void setFirstName(string firstName) { this.firstName = firstName; }

        public string getLastName() { return lastName; }
        public void setLastName(string lastName) { this.lastName = lastName; }

        public DateTime getDateOfBirth() { return dateOfBirth; }
        public void setDateOfBirth(DateTime dateOfBirth) { this.dateOfBirth = dateOfBirth; }

        public decimal getFees() { return tuitionFees; }
        public void setFees(decimal tuitionFees) { this.tuitionFees = tuitionFees; }

        //Methods==============================================================================================================
        public void InputStudent()
        {
            string addAnotherStudent = "";
            bool notSucceededTheConvert = true; //Convert from string to double
            DateTime FalseDate = new DateTime(0001, 1, 1); //Compere for wrong input date 


            do
            {
                Student student = new Student();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine();
                Console.WriteLine("\tNew student");
                Console.ForegroundColor = ConsoleColor.White;


                //Input fields-------------------------------------------------------------------------------------
                Console.WriteLine();
                Console.Write("\tFirst name : ");
                student.firstName = Console.ReadLine();

                Console.Write("\tLast name : ");
                student.lastName = Console.ReadLine();

                do
                {
                    Console.Write("\tDate of birth YYYY/MM/DD : ");
                    student.dateOfBirth = MyStaticClass.InputDate();
                } while (student.dateOfBirth == FalseDate);

                do
                {
                    Console.Write("\tTuition fees : ");

                    try
                    {
                        student.tuitionFees = Convert.ToDecimal(Console.ReadLine().Replace(".", ","));
                        notSucceededTheConvert = false;
                    }
                    catch (Exception)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\tPlease give a right form of fees.");
                        Console.ForegroundColor = ConsoleColor.White;
                        notSucceededTheConvert = true;
                    }

                } while (notSucceededTheConvert);



                students.Add(student);
                MyDatabase.allStudents.Add(student);

                //Ask to continue--------------------------------------------------------------------------------------
                do
                {
                    Console.WriteLine();
                    Console.Write("\tWould you like to add another student? Y/N : ");
                    addAnotherStudent = Console.ReadLine();
                } while (addAnotherStudent.ToUpper() != "Y" && addAnotherStudent.ToUpper() != "N");

            } while (addAnotherStudent.ToUpper() != "N");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\t=================================================================================\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        //Output a List of students-------------------------------------------------------------------------------------
        public void ListOfStudentsOutput(List<Student> students)
        {
            int counter = 1;
            int longestFirstName = 1;
            int longestLastName = 1;
            int differenceAtFirstNameLength;
            int differenceAtLastNameLength;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            Console.WriteLine("\tList of students");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            for (int i = 0; i < students.Count; i++) //Find the longest first name of list students
            {
                if (students[i].firstName.Length > longestFirstName)
                {
                    longestFirstName = students[i].firstName.Length;
                }

                if (students[i].lastName.Length > longestLastName) //Find the longest first last of list students
                {
                    longestLastName = students[i].lastName.Length;
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
                Console.WriteLine("Last name" + new string(' ', longestLastName - "Last name".Length) + "  " + "Date of Birth" + "  " + "Fees");
            }
            else
            {
                Console.WriteLine("Last name" + "  " + "Date of Birth" + "  " + "Fees");
            }
            Console.ForegroundColor = ConsoleColor.White;

            //Output all fields alligned
            foreach (var item in students)
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
                    Console.WriteLine(item.lastName + new string(' ', differenceAtLastNameLength) + "  " + item.dateOfBirth.ToString("dd/MM/yyyy") + "     " + item.tuitionFees);
                }
                else if ((longestLastName - "Last name".Length) < 0)
                {
                    Console.WriteLine(item.lastName + new string(' ', differenceAtLastNameLength + ("Last name".Length - longestLastName)) + "  " + item.dateOfBirth.ToString("dd/MM/yyyy") + "     " + item.tuitionFees);
                }
                else
                {
                    Console.WriteLine(item.lastName + "  " + item.dateOfBirth.ToString("dd/MM/yyyy") + "     " + item.tuitionFees);
                }
                counter++;
            }
        }

        //Output a List of students with many courses-------------------------------------------------------------------------------------
        public void ListOfStudentsShowingTheNumberOfCoursesPerStudentOutput(List<Student> students)
        {
            int counter = 1;
            int longestFirstName = 1;
            int longestLastName = 1;
            int differenceAtFirstNameLength;
            int differenceAtLastNameLength;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            Console.WriteLine("\tList of students");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            for (int i = 0; i < students.Count; i++) //Find the longest first name of list students
            {
                if (students[i].firstName.Length > longestFirstName)
                {
                    longestFirstName = students[i].firstName.Length;
                }

                if (students[i].lastName.Length > longestLastName) //Find the longest first last of list students
                {
                    longestLastName = students[i].lastName.Length;
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
                Console.WriteLine("Last name" + new string(' ', longestLastName - "Last name".Length) + "  " + "Date of Birth" + "  " + "Number of courses" + "  " + "Fees");
            }
            else
            {
                Console.WriteLine("Last name" + "  " + "Date of Birth" + "  " + "Number of courses" + "  " + "Fees");
            }
            Console.ForegroundColor = ConsoleColor.White;

            //Output all fields alligned
            foreach (var item in students)
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
                if (differenceAtFirstNameLength > 0 && ((longestFirstName - "First name".Length) > 0)) //First Name
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
                if (differenceAtLastNameLength > 0 && ((longestLastName - "Last name".Length) > 0)) //Last Name and the other fields
                {
                    Console.WriteLine(item.lastName + new string(' ', differenceAtLastNameLength) + "  " + item.dateOfBirth.ToString("dd/MM/yyyy") + "     " + item.courses.Count + new string(' ', "Number of courses".Length - 1) + "  " + item.tuitionFees);
                }
                else if ((longestLastName - "Last name".Length) < 0)
                {
                    Console.WriteLine(item.lastName + new string(' ', differenceAtLastNameLength + ("Last name".Length - longestLastName)) + "  " + item.dateOfBirth.ToString("dd/MM/yyyy") + "     " + item.courses.Count + new string(' ', "Number of courses".Length - 1) + "  " + item.tuitionFees);
                }
                else
                {
                    Console.WriteLine(item.lastName + "  " + item.dateOfBirth.ToString("dd/MM/yyyy") + "     " + item.courses.Count + new string(' ', "Number of courses".Length - 1) + "  " + item.tuitionFees);
                }
                counter++;
            }
        }

        //Return List of sudents with many courses ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public List<Student> ReturnListOfStudentsWithMoreThanOneCourse()
        {
            Student student = new Student();
            List<Student> studentsWithMoreThanOneCorse = new List<Student>();

            foreach (Student item in MyDatabase.allStudents)
            {
                if (item.courses.Count > 1)
                {
                    studentsWithMoreThanOneCorse.Add(item);
                }
            }

            return studentsWithMoreThanOneCorse;
        }
    }
}
