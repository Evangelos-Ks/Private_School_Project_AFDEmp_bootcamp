using System.Collections.Generic;

namespace PrivateSchool
{
    static class MyDatabase
    {
        public static List<Student> allStudents { get; set; } = new List<Student>();//Collect all students that inputed
        public static List<Trainer> allTrainers { get; set; } = new List<Trainer>();//Collect all trainers that inputed
        public static List<Assignment> allAssignments { get; set; } = new List<Assignment>();//Collect all assignments that inputed
        public static List<Course> allCourses { get; set; } = new List<Course>();//Collect all courses that inputed
    }
}
