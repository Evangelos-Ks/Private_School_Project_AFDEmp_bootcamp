using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateSchool
{
    public class Course
    {
        //Fields==============================================================================================================
        private string title;
        private string stream;
        private string type;
        private DateTime startDate;
        private DateTime endDate;

        public List<Course> courses = new List<Course>();
        public List<Student> students = new List<Student>();
        public List<Trainer> trainers = new List<Trainer>();
        public List<Assignment> assignments = new List<Assignment>();

        //Constuctors====================================================================================================================
        public Course() { }

        public Course(string title, string stream, string type, DateTime startDate, DateTime endDate)
        {
            this.title = title;
            this.stream = stream;
            this.type = type;
            this.startDate = startDate;
            this.endDate = endDate;
        }



        //getters & setters==============================================================================================================
        public string getTitle() { return title; }
        public void setTitle(string title) { this.title = title; }
        public string getStream() { return stream; }
        public void setStream(string stream) { this.stream = stream; }
        public string getType() { return type; }
        public void setType(string type) { this.type = type; }
        public DateTime getStartDate() { return startDate; }
        public void setStartDate(DateTime startDate) { this.startDate = startDate; }
        public DateTime getEndDate() { return endDate; }
        public void setEndDate(DateTime end_date) { this.endDate = end_date; }

        //Methods==============================================================================================================
        public void InputCourse()
        {
            string addAnotherCourse = "";
            DateTime FalseDate = new DateTime(0001, 1, 1); //Compere for wrong input date 

            do
            {
                Course course = new Course();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine();
                Console.WriteLine("\tNew course");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;

                //Input fields
                Console.WriteLine();
                Console.Write("\tTitle : ");
                course.title = Console.ReadLine();

                Console.Write("\tStream : ");
                course.stream = Console.ReadLine();

                Console.Write("\tType : ");
                course.type = Console.ReadLine();

                do
                {
                    Console.Write("\tStart date YYYY/MM/DD : ");
                    course.startDate = MyStaticClass.InputDate();
                } while (course.startDate == FalseDate);

                do
                {
                    Console.Write("\tEnd date YYYY/MM/DD : ");
                    course.endDate = MyStaticClass.InputDate();

                    if (course.startDate > course.endDate && course.endDate != FalseDate)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\tEnd date can't be before than start date.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                } while (course.endDate == FalseDate || course.startDate > course.endDate);

                courses.Add(course);
                MyDatabase.allCourses.Add(course);

                //Ask to continue
                do
                {
                    Console.WriteLine();
                    Console.Write("\tWould you like to add another course? Y/N : ");
                    addAnotherCourse = Console.ReadLine();
                } while (addAnotherCourse.ToUpper() != "Y" && addAnotherCourse.ToUpper() != "N");

            } while (addAnotherCourse.ToUpper() != "N");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\t=================================================================================\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        //Output a List of courses-------------------------------------------------------------------------------------
        public void ListOfCoursecOutput(List<Course> courses)
        {
            int counter = 1;
            int longestTitle = 1;
            int longestStream = 1;
            int longestType = 1;
            int differenceAtTitleLength;
            int differenceAtStreamLength;
            int differenceAtTypeLength;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            Console.WriteLine("\tList of courses");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            for (int i = 0; i < courses.Count; i++) //Find the longest title of list courses
            {
                if (courses[i].title.Length > longestTitle)
                {
                    longestTitle = courses[i].title.Length;
                }

                if (courses[i].stream.Length > longestStream) //Find the longest stream of list courses
                {
                    longestStream = courses[i].stream.Length;
                }

                if (courses[i].type.Length > longestType) //Find the longest type of list courses
                {
                    longestType = courses[i].type.Length;
                }
            }

            //Headings
            Console.ForegroundColor = ConsoleColor.Yellow;
            if ((longestTitle - "Title".Length) > 0) //Output Heading of Title
            {
                Console.Write("\t" + "      " + "Title" + new string(' ', longestTitle - "Title".Length) + "  ");
            }
            else
            {
                Console.Write("\t" + "      " + "Title" + "  ");
            }

            if ((longestStream - "stream".Length) > 0) //Output Heading of stream
            {
                Console.Write("stream" + new string(' ', longestStream - "stream".Length) + "  ");
            }
            else
            {
                Console.Write("stream" + "  ");
            }

            if ((longestType - "type".Length) > 0) //Output Heading of type and others hedings
            {
                Console.WriteLine("Type" + new string(' ', longestType - "type".Length) + "  " + "Start date" + "   " + "End date");
            }
            else
            {
                Console.WriteLine("Type" + "  " + "Start date" + "   " + "End date");
            }
            Console.ForegroundColor = ConsoleColor.White;

            //Output all fields alligned
            foreach (var item in courses)
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

                differenceAtTitleLength = longestTitle - item.title.Length;
                if (differenceAtTitleLength > 0 && ((longestTitle - "Title".Length) >= 0)) //Title
                {
                    Console.Write(item.title + new string(' ', differenceAtTitleLength) + "  ");
                }
                else if ((longestTitle - "Title".Length) < 0)
                {
                    Console.Write(item.title + new string(' ', (differenceAtTitleLength + ("Title".Length - longestTitle))) + "  ");
                }
                else
                {
                    Console.Write(item.title + "  ");
                }

                differenceAtStreamLength = longestStream - item.stream.Length;
                if (differenceAtStreamLength > 0 && ((longestStream - "Stream".Length) >= 0)) //Stream
                {
                    Console.Write(item.stream + new string(' ', differenceAtStreamLength) + "  ");
                }
                else if ((longestStream - "Stream".Length) < 0)
                {
                    Console.Write(item.stream + new string(' ', (differenceAtStreamLength + ("Stream".Length - longestStream))) + "  ");
                }
                else
                {
                    Console.Write(item.stream + "  ");
                }

                differenceAtTypeLength = longestType - item.type.Length;
                if (differenceAtTypeLength > 0 && ((longestType - "Type".Length) >= 0)) //type and the other fields
                {
                    Console.WriteLine(item.type + new string(' ', differenceAtTypeLength) + "  " + item.startDate.ToString("dd/MM/yyyy") + "   " + item.endDate.ToString("dd/MM/yyyy"));
                }
                else if ((longestType - "Type".Length) < 0)
                {
                    Console.WriteLine(item.type + new string(' ', (differenceAtTypeLength + ("Type".Length - longestType))) + "  " + item.startDate.ToString("dd/MM/yyyy") + "   " + item.endDate.ToString("dd/MM/yyyy"));
                }
                else
                {
                    Console.WriteLine(item.type + "  " + item.startDate.ToString("dd/MM/yyyy") + "   " + item.endDate.ToString("dd/MM/yyyy"));
                }
                counter++;
            }
        }
    }
}