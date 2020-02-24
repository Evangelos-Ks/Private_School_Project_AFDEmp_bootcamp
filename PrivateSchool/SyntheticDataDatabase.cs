using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateSchool
{
    public static class SyntheticDataDatabase
    {
        public static List<Course> syntheticCorses { get; set; } = new List<Course>();
        public static List<Student> syntheticStudents { get; set; } = new List<Student>();
        public static List<Assignment> syntheticAssignmets { get; set; } = new List<Assignment>();
        public static List<Trainer> syntheticTrainers { get; set; } = new List<Trainer>();


        public static void SyntheticDataDatabaseBild()
        {

            //Bild Data---------------------------------------------------------------------------------------------------------------------------
            Student s1 = new Student(firstName: "Maria", lastName: "Fafouti", dateOfBirth: DateTime.Parse("1990/7/1"), tuitionFees: 500);
            Student s2 = new Student(firstName: "Evangelos", lastName: "Koutsogiorgos", dateOfBirth: DateTime.Parse("1989/11/9"), tuitionFees: 1000);
            Student s3 = new Student(firstName: "Panagiotis", lastName: "Koutsogiorgos", dateOfBirth: DateTime.Parse("1991/3/26"), tuitionFees: 600);
            Student s4 = new Student(firstName: "Ioannis", lastName: "Angelopoulos", dateOfBirth: DateTime.Parse("1985/6/19"), tuitionFees: 500);
            Student s5 = new Student(firstName: "Sophia", lastName: "Georgiou", dateOfBirth: DateTime.Parse("1992/6/13"), tuitionFees: 700);
            Student s6 = new Student(firstName: "Eleni", lastName: "Parisi", dateOfBirth: DateTime.Parse("1989/12/3"), tuitionFees: 1200);
            Student s7 = new Student(firstName: "Eleutherios", lastName: "Danopoulos", dateOfBirth: DateTime.Parse("1992/1/14"), tuitionFees: 500);
            Student s8 = new Student(firstName: "Dimitra", lastName: "Alexiou", dateOfBirth: DateTime.Parse("1991/10/29"), tuitionFees: 900);
            Student s9 = new Student(firstName: "George", lastName: "Leras", dateOfBirth: DateTime.Parse("1990/8/13"), tuitionFees: 1100);
            Student s10 = new Student(firstName: "Thanasis", lastName: "Sdralias", dateOfBirth: DateTime.Parse("1985/5/13"), tuitionFees: 800);

            Course c1 = new Course(title: "Chem", stream: "Full time" , type: "Chemistry", startDate: DateTime.Parse("2019/10/1"), endDate: DateTime.Parse("2020/6/16"));
            Course c2 = new Course(title: "Phys", stream: "Full time" , type: "Physics", startDate: DateTime.Parse("2019/10/1"), endDate: DateTime.Parse("2020/6/23"));

            Trainer t1 = new Trainer(firstName: "Marie", lastName: "Curie", subject: "Chemistry");
            Trainer t2 = new Trainer(firstName: "Luis", lastName: "Pasteur", subject: "Chemistry");
            Trainer t3 = new Trainer(firstName: "Albert", lastName: "Einstain", subject: "Physics");
            Trainer t4 = new Trainer(firstName: "Richard", lastName: "Faynman", subject: "Physics");

            Assignment a1 = new Assignment( title: "OrgChem",  description: "Organic Chemistry",  subDateTime: DateTime.Parse("2020/1/10"),  oralMark: 77,  totalMark: 88);
            Assignment a2 = new Assignment( title: "InorgChem",  description: "Inorganic Chemistry",  subDateTime: DateTime.Parse("2020/1/9"),  oralMark: 65,  totalMark: 92);
            Assignment a3 = new Assignment( title: "MecPhys",  description: "Mecanics",  subDateTime: DateTime.Parse("2020/1/23"),  oralMark: 69,  totalMark: 72);
            Assignment a4 = new Assignment( title: "OptPhys",  description: "Optics",  subDateTime: DateTime.Parse("2020/1/20"),  oralMark: 83,  totalMark: 75);

            syntheticStudents.Add(s1);
            syntheticStudents.Add(s2);
            syntheticStudents.Add(s3);
            syntheticStudents.Add(s4);
            syntheticStudents.Add(s5);
            syntheticStudents.Add(s6);
            syntheticStudents.Add(s7);
            syntheticStudents.Add(s8);
            syntheticStudents.Add(s9);
            syntheticStudents.Add(s10);

            syntheticCorses.Add(c1);
            syntheticCorses.Add(c2);

            syntheticTrainers.Add(t1);
            syntheticTrainers.Add(t2);
            syntheticTrainers.Add(t3);
            syntheticTrainers.Add(t4);

            syntheticAssignmets.Add(a1);
            syntheticAssignmets.Add(a2);
            syntheticAssignmets.Add(a3);
            syntheticAssignmets.Add(a4);

            //Give structure at private school-------------------------------------------------------------------------------------------------------------------
            //Put students at courses
            c1.students.Add(s1);
            c1.students.Add(s2);
            c1.students.Add(s3);
            c1.students.Add(s4);
            c1.students.Add(s5);
            c2.students.Add(s1);
            c2.students.Add(s2);
            c2.students.Add(s6);
            c2.students.Add(s7);
            c2.students.Add(s8);
            c2.students.Add(s9);
            c2.students.Add(s10);

            //Put corses at students
            s1.courses.Add(c1);
            s2.courses.Add(c1);
            s1.courses.Add(c2);
            s2.courses.Add(c2);
            s3.courses.Add(c1);
            s4.courses.Add(c1);
            s5.courses.Add(c1);
            s6.courses.Add(c2);
            s7.courses.Add(c2);
            s8.courses.Add(c2);
            s9.courses.Add(c2);
            s10.courses.Add(c2);

            //Put trainers at courses
            c1.trainers.Add(t1);
            c1.trainers.Add(t2);
            c2.trainers.Add(t3);
            c2.trainers.Add(t4);

            //put courses at trainers
            t1.courses.Add(c1);
            t2.courses.Add(c1);
            t3.courses.Add(c2);
            t4.courses.Add(c2);

            //put assignments at courses
            c1.assignments.Add(a1);
            c1.assignments.Add(a2);
            c2.assignments.Add(a3);
            c2.assignments.Add(a4);

            //put courses at assignments
            a1.courses.Add(c1);
            a2.courses.Add(c1);
            a3.courses.Add(c2);
            a4.courses.Add(c2);

            //Put students at assignments
            a1.students.Add(s1);
            a1.students.Add(s2);
            a1.students.Add(s3);
            a1.students.Add(s4);
            a1.students.Add(s5);
            a2.students.Add(s1);
            a2.students.Add(s2);
            a2.students.Add(s3);
            a2.students.Add(s4);
            a2.students.Add(s5);

            a3.students.Add(s6);
            a3.students.Add(s7);
            a3.students.Add(s8);
            a3.students.Add(s9);
            a3.students.Add(s10);
            a4.students.Add(s6);
            a4.students.Add(s7);
            a4.students.Add(s8);
            a4.students.Add(s9);
            a4.students.Add(s10);

            //Put assignmets at students
            s1.assignments.Add(a1);
            s2.assignments.Add(a1);
            s3.assignments.Add(a1);
            s4.assignments.Add(a1);
            s5.assignments.Add(a1);
            s1.assignments.Add(a2);
            s2.assignments.Add(a2);
            s3.assignments.Add(a2);
            s4.assignments.Add(a2);
            s5.assignments.Add(a2);

            s6.assignments.Add(a3);
            s7.assignments.Add(a3);
            s8.assignments.Add(a3);
            s9.assignments.Add(a3);
            s10.assignments.Add(a3);
            s6.assignments.Add(a4);
            s7.assignments.Add(a4);
            s8.assignments.Add(a4);
            s9.assignments.Add(a4);
            s10.assignments.Add(a4);

        }     

        
    }
}
