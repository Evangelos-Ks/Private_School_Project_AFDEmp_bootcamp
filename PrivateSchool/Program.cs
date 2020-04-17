using System;


namespace PrivateSchool
{
    class Program
    {
        static void Main(string[] args)
        {
            Course c1 = new Course();
            Assignment a1 = new Assignment();
            Trainer tr1 = new Trainer();
            Student s1 = new Student();
            StudentsPerCourse sPC = new StudentsPerCourse();
            TrainersPerCourse tPC = new TrainersPerCourse();
            AssignmentsPerCourse aPC = new AssignmentsPerCourse();
            AssignmetsPerStudent aPS = new AssignmetsPerStudent();

            string userInput1, userInput2 = "", userInput3 = "", userInput5 = "";
            int userInput4, selectCourse, selectStudent;

            do
            {
                //Select mode----------------------------------------------------------------------------------------------------------------------------------
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();
                Console.WriteLine("\tWellcome to Private School!");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\tWhat would you like to do?");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("\t0. Exit.");
                Console.WriteLine("\t1. Use the application at normal mode.");
                Console.WriteLine("\t2. Use the application with synthetic data.");

                Console.Write("\n\tPlease enter the appropriate number to select the field you are interested in : ");
                userInput1 = Console.ReadLine();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n\t=================================================================================\n");
                Console.ForegroundColor = ConsoleColor.White;


                //UserInput = 1, normal mode--------------------------------------------------------------------------------------------------------------------
                if (userInput1 == "1")
                {
                    MyDatabase.allAssignments.Clear();
                    MyDatabase.allCourses.Clear();
                    MyDatabase.allStudents.Clear();
                    MyDatabase.allTrainers.Clear();

                    do
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine();
                        Console.WriteLine("\tYou are in the normal mode! What would you like to do?");
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.WriteLine("\t0. Exit.");
                        Console.WriteLine("\t1. Course.");
                        Console.WriteLine("\t2. Assignment.");
                        Console.WriteLine("\t3. Trainer.");
                        Console.WriteLine("\t4. Student.");
                        Console.WriteLine("\t9. Go back.");

                        Console.Write("\n\tPlease enter the appropriate number to select the field you are interested in : ");
                        userInput2 = Console.ReadLine();

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n\t=================================================================================\n");
                        Console.ForegroundColor = ConsoleColor.White;

                        //UserInput2 = 1, normal mode, Course--------------------------------------------------------------------------------------------------------------------
                        if (userInput2 == "1")
                        {
                            do
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine();
                                Console.WriteLine("\tYou are in the course mode! What would you like to do?");
                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.White;

                                Console.WriteLine("\t0. Exit.");
                                Console.WriteLine("\t1. New course.");
                                Console.WriteLine("\t2. Output list with all courses.");
                                Console.WriteLine("\t3. Add students at courses.");
                                Console.WriteLine("\t4. Output students per course.");
                                Console.WriteLine("\t5. Add trainers at courses.");
                                Console.WriteLine("\t6. Output trainers per course.");
                                Console.WriteLine("\t7. Add assignments at courses.");
                                Console.WriteLine("\t8. Output assignments per course.");
                                Console.WriteLine("\t9. Go back.");

                                Console.Write("\n\tPlease enter the appropriate number to select the field you are interested in : ");
                                userInput3 = Console.ReadLine();

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\n\t=================================================================================\n");
                                Console.ForegroundColor = ConsoleColor.White;

                                //UserInput3 = 1, normal mode, New course-------------------------------------------------------------------------------------------------------
                                if (userInput3 == "1")
                                {
                                    c1.InputCourse();
                                }
                                //UserInput3 = 2, normal mode, List of courses-------------------------------------------------------------------------------------------------------
                                else if (userInput3 == "2")
                                {
                                    c1.ListOfCoursecOutput(MyDatabase.allCourses);
                                    MyStaticClass.PressKeyToContinue();
                                }
                                //UserInput3 = 3, normal mode, Add students at courses-------------------------------------------------------------------------------------------------------
                                else if (userInput3 == "3")
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine();
                                    Console.WriteLine("\tSelect the number of course that you want to add students.");
                                    Console.WriteLine();
                                    Console.ForegroundColor = ConsoleColor.White;


                                    c1.ListOfCoursecOutput(MyDatabase.allCourses);
                                    Console.WriteLine();

                                    do
                                    {
                                        Console.Write("\tEnter the apropriate number : ");
                                        selectCourse = MyStaticClass.InputTryToConvertToInt();
                                    } while (selectCourse <= 0 || selectCourse > MyDatabase.allCourses.Count);

                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("\n\t=================================================================================\n");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    do
                                    {
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.WriteLine("\tSelect how you want to add a student.");
                                        Console.ForegroundColor = ConsoleColor.White;

                                        Console.WriteLine();
                                        Console.WriteLine("\t1. Add a new student.");
                                        Console.WriteLine("\t2. Add an excisting student.");
                                        Console.WriteLine("\t9. Go back.");

                                        Console.Write("\n\tPlease enter the appropriate number to select the field you are interested in : ");
                                        userInput5 = Console.ReadLine();

                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("\n\t=================================================================================\n");
                                        Console.ForegroundColor = ConsoleColor.White;

                                    } while (((userInput5 != "1" && userInput5 != "2") && userInput5 != "9"));

                                    sPC.InputStudentsPerCourse(MyDatabase.allCourses[selectCourse - 1], userInput5);
                                }
                                //UserInput3 = 4, normal mode, Output students per course-------------------------------------------------------------------------------------------------------
                                else if (userInput3 == "4")
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine();
                                    Console.WriteLine("\tSelect the number of course that you want to output students.");
                                    Console.WriteLine();

                                    c1.ListOfCoursecOutput(MyDatabase.allCourses);
                                    Console.WriteLine();

                                    do
                                    {
                                        Console.Write("\tEnter the apropriate number : ");
                                        userInput4 = MyStaticClass.InputTryToConvertToInt();
                                    } while (userInput4 <= 0 || userInput4 > MyDatabase.allCourses.Count);

                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("\n\t=================================================================================\n");
                                    Console.ForegroundColor = ConsoleColor.White;

                                    sPC.OutputStudentsPerCourse((userInput4 - 1));
                                    MyStaticClass.PressKeyToContinue();
                                }
                                //UserInput3 = 5, normal mode, Add trainers at courses-------------------------------------------------------------------------------------------------------
                                else if (userInput3 == "5")
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine();
                                    Console.WriteLine("\tSelect the number of course that you want to add trainers.");
                                    Console.WriteLine();
                                    Console.ForegroundColor = ConsoleColor.White;


                                    c1.ListOfCoursecOutput(MyDatabase.allCourses);
                                    Console.WriteLine();

                                    do
                                    {
                                        Console.Write("\tEnter the apropriate number : ");
                                        selectCourse = MyStaticClass.InputTryToConvertToInt();
                                    } while (selectCourse <= 0 || selectCourse > MyDatabase.allCourses.Count);


                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("\n\t=================================================================================\n");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    do
                                    {
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.WriteLine("\tSelect how you want to add a trainer.");
                                        Console.ForegroundColor = ConsoleColor.White;

                                        Console.WriteLine();
                                        Console.WriteLine("\t1. Add a new trainer.");
                                        Console.WriteLine("\t2. Add an excisting trainer.");
                                        Console.WriteLine("\t9. Go back.");

                                        Console.Write("\n\tPlease enter the appropriate number to select the field you are interested in : ");
                                        userInput5 = Console.ReadLine();

                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("\n\t=================================================================================\n");
                                        Console.ForegroundColor = ConsoleColor.White;

                                    } while ((userInput5 != "1" && userInput5 != "2") && userInput5 != "9");

                                    tPC.InputTrainersPerCourse(MyDatabase.allCourses[selectCourse - 1], userInput5);
                                }
                                //UserInput3 = 6, normal mode, Output trainers per course-------------------------------------------------------------------------------------------------------
                                else if (userInput3 == "6")
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine();
                                    Console.WriteLine("\tSelect the number of course that you want to output trainers.");
                                    Console.WriteLine();

                                    c1.ListOfCoursecOutput(MyDatabase.allCourses);
                                    Console.WriteLine();

                                    do
                                    {
                                        Console.Write("\tEnter the apropriate number : ");
                                        userInput4 = MyStaticClass.InputTryToConvertToInt();
                                    } while (userInput4 <= 0 || userInput4 > MyDatabase.allCourses.Count);

                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("\n\t=================================================================================\n");
                                    Console.ForegroundColor = ConsoleColor.White;

                                    tPC.OutputTrainersPerCourse((userInput4 - 1));
                                    MyStaticClass.PressKeyToContinue();
                                }
                                //UserInput3 = 7, normal mode, Add assignments at courses-------------------------------------------------------------------------------------------------------
                                else if (userInput3 == "7")
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine();
                                    Console.WriteLine("\tSelect the number of course that you want to add assignments.");
                                    Console.WriteLine();
                                    Console.ForegroundColor = ConsoleColor.White;


                                    c1.ListOfCoursecOutput(MyDatabase.allCourses);
                                    Console.WriteLine();

                                    do
                                    {
                                        Console.Write("\tEnter the apropriate number : ");
                                        selectCourse = MyStaticClass.InputTryToConvertToInt();
                                    } while (selectCourse <= 0 || selectCourse > MyDatabase.allCourses.Count);


                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("\n\t=================================================================================\n");
                                    Console.ForegroundColor = ConsoleColor.White;

                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("\tSelect how you want to add an assignment.");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    do
                                    {

                                        Console.WriteLine();
                                        Console.WriteLine("\t1. Add a new assignment.");
                                        Console.WriteLine("\t2. Add an excisting assignment.");
                                        Console.WriteLine("\t9. Go back.");

                                        Console.Write("\n\tPlease enter the appropriate number to select the field you are interested in : ");
                                        userInput5 = Console.ReadLine();

                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("\n\t=================================================================================\n");
                                        Console.ForegroundColor = ConsoleColor.White;

                                    } while ((userInput5 != "1" && userInput5 != "2") && userInput5 != "9");

                                    aPC.InputAssignmentsPerCourse(MyDatabase.allCourses[selectCourse - 1], userInput5);
                                }
                                //UserInput3 = 8, normal mode, Output assignments per course-------------------------------------------------------------------------------------------------------
                                else if (userInput3 == "8")
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine();
                                    Console.WriteLine("\tSelect the number of course that you want to output assignments.");
                                    Console.WriteLine();

                                    c1.ListOfCoursecOutput(MyDatabase.allCourses);
                                    Console.WriteLine();

                                    do
                                    {
                                        Console.Write("\tEnter the apropriate number : ");
                                        userInput4 = MyStaticClass.InputTryToConvertToInt();
                                    } while (userInput4 <= 0 || userInput4 > MyDatabase.allCourses.Count);

                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("\n\t=================================================================================\n");
                                    Console.ForegroundColor = ConsoleColor.White;

                                    aPC.OutputAssignmetsPerCourse((userInput4 - 1));
                                    MyStaticClass.PressKeyToContinue();
                                }
                            } while (userInput3 != "0" && userInput3 != "9");
                        }
                        //UserInput2 = 2, normal mode, Assignment--------------------------------------------------------------------------------------------------------------------
                        else if (userInput2 == "2")
                        {
                            do
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine();
                                Console.WriteLine("\tYou are in the assignment mode! What would you like to do?");
                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("\t0. Exit.");
                                Console.WriteLine("\t1. New assignment.");
                                Console.WriteLine("\t2. Output list with all assignments.");
                                Console.WriteLine("\t9. Go back.");

                                Console.Write("\n\tPlease enter the appropriate number to select the field you are interested in : ");
                                userInput3 = Console.ReadLine();

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\n\t=================================================================================\n");
                                Console.ForegroundColor = ConsoleColor.White;

                                //UserInput3 = 1, normal mode, New Assignment-------------------------------------------------------------------------------------------------------
                                if (userInput3 == "1")
                                {
                                    a1.InputAssignment();
                                }
                                //UserInput3 = 2, normal mode, List of assignments-------------------------------------------------------------------------------------------------------
                                else if (userInput3 == "2")
                                {
                                    a1.ListOfAssignmentsOutput(MyDatabase.allAssignments);
                                    MyStaticClass.PressKeyToContinue();
                                }

                            } while ((userInput3 != "0" && userInput3 != "9") && (userInput3 != "1" && userInput3 != "2"));
                        }
                        //UserInput2 = 3, normal mode, Trainer--------------------------------------------------------------------------------------------------------------------
                        else if (userInput2 == "3")
                        {
                            do
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine();
                                Console.WriteLine("\tYou are in the trainer mode! What would you like to do?");
                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("\t0. Exit.");
                                Console.WriteLine("\t1. New trainer.");
                                Console.WriteLine("\t2. Output list with all trainers.");
                                Console.WriteLine("\t9. Go back.");

                                Console.Write("\n\tPlease enter the appropriate number to select the field you are interested in : ");
                                userInput3 = Console.ReadLine();

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\n\t=================================================================================\n");
                                Console.ForegroundColor = ConsoleColor.White;

                                //UserInput3 = 1, normal mode, New trainer-------------------------------------------------------------------------------------------------------
                                if (userInput3 == "1")
                                {
                                    tr1.InputTrainer();
                                }
                                //UserInput3 = 2, normal mode, List of trainers-------------------------------------------------------------------------------------------------------
                                else if (userInput3 == "2")
                                {
                                    tr1.ListOfTrainersOutput(MyDatabase.allTrainers);
                                    MyStaticClass.PressKeyToContinue();
                                }

                            } while ((userInput3 != "0" && userInput3 != "9") && (userInput3 != "1" && userInput3 != "2"));
                        }
                        //UserInput2 = 4, normal mode, Student--------------------------------------------------------------------------------------------------------------------
                        else if (userInput2 == "4")
                        {
                            do
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine();
                                Console.WriteLine("\tYou are in the student mode! What would you like to do?");
                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("\t0. Exit.");
                                Console.WriteLine("\t1. New student.");
                                Console.WriteLine("\t2. Output list with all students.");
                                Console.WriteLine("\t3. Add assignments at student.");
                                Console.WriteLine("\t4. Output assignments per student.");
                                Console.WriteLine("\t5. Output list witn students who belongs to more than one course.");
                                Console.WriteLine("\t6. Output list witn students who need to submit an assignment in a week.");
                                Console.WriteLine("\t9. Go back.");

                                Console.Write("\n\tPlease enter the appropriate number to select the field you are interested in : ");
                                userInput3 = Console.ReadLine();

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\n\t=================================================================================\n");
                                Console.ForegroundColor = ConsoleColor.White;

                                //UserInput3 = 1, normal mode, New Student-------------------------------------------------------------------------------------------------------
                                if (userInput3 == "1")
                                {
                                    s1.InputStudent();
                                }
                                //UserInput3 = 2, normal mode, List of students-------------------------------------------------------------------------------------------------------
                                else if (userInput3 == "2")
                                {
                                    s1.ListOfStudentsOutput(MyDatabase.allStudents);
                                    MyStaticClass.PressKeyToContinue();
                                }
                                //UserInput3 = 3, normal mode, Add assignments at students-------------------------------------------------------------------------------------------------------
                                else if (userInput3 == "3")
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine();
                                    Console.WriteLine("\tSelect the number of student that you want to add assignments.");
                                    Console.WriteLine();
                                    Console.ForegroundColor = ConsoleColor.White;


                                    s1.ListOfStudentsOutput(MyDatabase.allStudents);
                                    Console.WriteLine();

                                    do
                                    {
                                        Console.Write("\tEnter the apropriate number : ");
                                        selectStudent = MyStaticClass.InputTryToConvertToInt();
                                    } while (selectStudent <= 0 || selectStudent > MyDatabase.allStudents.Count);


                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("\n\t=================================================================================\n");
                                    Console.ForegroundColor = ConsoleColor.White;

                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("\tSelect how you want to add an assignment.");
                                    Console.ForegroundColor = ConsoleColor.White;

                                    do
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine("\t1. Add a new assignment.");
                                        Console.WriteLine("\t2. Add an excisting assignment.");
                                        Console.WriteLine("\t9. Go back.");

                                        Console.Write("\n\tPlease enter the appropriate number to select the field you are interested in : ");
                                        userInput5 = Console.ReadLine();

                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("\n\t=================================================================================\n");
                                        Console.ForegroundColor = ConsoleColor.White;

                                    } while ((userInput5 != "1" && userInput5 != "2") && userInput5 != "9");

                                    aPS.InputAssignmentsPerStudent(MyDatabase.allStudents[selectStudent - 1], userInput5);
                                }
                                //UserInput3 = 4, normal mode, Output assignments per student-------------------------------------------------------------------------------------------------------
                                else if (userInput3 == "4")
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine();
                                    Console.WriteLine("\tSelect the number of student that you want to output assignments.");
                                    Console.WriteLine();

                                    s1.ListOfStudentsOutput(MyDatabase.allStudents);
                                    Console.WriteLine();

                                    do
                                    {
                                        Console.Write("\tEnter the apropriate number : ");
                                        userInput4 = MyStaticClass.InputTryToConvertToInt();
                                    } while (userInput4 <= 0 || userInput4 > MyDatabase.allStudents.Count);

                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("\n\t=================================================================================\n");
                                    Console.ForegroundColor = ConsoleColor.White;

                                    aPS.OutputAssignmetsPerStudent(userInput4 - 1);
                                    MyStaticClass.PressKeyToContinue();
                                }
                                //UserInput3 = 5, normal mode, List of students who belongs to more than one course-------------------------------------------------------------------------------------------------------
                                else if (userInput3 == "5")
                                {
                                    s1.ListOfStudentsShowingTheNumberOfCoursesPerStudentOutput(s1.ReturnListOfStudentsWithMoreThanOneCourse());
                                    MyStaticClass.PressKeyToContinue();
                                }
                                //UserInput3 = 6, normal mode, List of students who need to submit an assignment in a week-------------------------------------------------------------------------------------------------------
                                else if (userInput3 == "6")
                                {
                                    Console.WriteLine();
                                    Console.Write("\tPlease enter a date DD/MM/YYYY: ");
                                    a1.StudentsSubmitAssignments(a1.assignmentsPerWeek(MyStaticClass.InputDate()));
                                    MyStaticClass.PressKeyToContinue();
                                }

                            } while ((userInput3 != "0" && userInput3 != "9") && (userInput3 != "1" && userInput3 != "2") && (userInput3 != "3" && userInput3 != "4") && (userInput3 != "5" && userInput3 != "6"));
                        }
                    } while ((userInput2 != "0" && userInput2 != "9") && userInput3 != "0");
                }
                //UserInput1 = 2 , Synthetic data---------------------------------------------------------------------------------------------------------------- 
                else if (userInput1 == "2")
                {
                    MyDatabase.allAssignments.Clear();
                    MyDatabase.allCourses.Clear();
                    MyDatabase.allStudents.Clear();
                    MyDatabase.allTrainers.Clear();

                    SyntheticDataDatabase.SyntheticDataDatabaseBild();

                    MyDatabase.allCourses.AddRange(SyntheticDataDatabase.syntheticCorses);
                    MyDatabase.allStudents.AddRange(SyntheticDataDatabase.syntheticStudents);
                    MyDatabase.allTrainers.AddRange(SyntheticDataDatabase.syntheticTrainers);
                    MyDatabase.allAssignments.AddRange(SyntheticDataDatabase.syntheticAssignmets);

                    do
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine();
                        Console.WriteLine("\tYou are in the synthetic data mode! What would you like to do?");
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.WriteLine("\t0. Exit.");
                        Console.WriteLine("\t1. Course.");
                        Console.WriteLine("\t2. Assignment.");
                        Console.WriteLine("\t3. Trainer.");
                        Console.WriteLine("\t4. Student.");
                        Console.WriteLine("\t9. Go back.");

                        Console.Write("\n\tPlease enter the appropriate number to select the field you are interested in : ");
                        userInput2 = Console.ReadLine();

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n\t=================================================================================\n");
                        Console.ForegroundColor = ConsoleColor.White;

                        //UserInput2 = 1, normal mode, Course--------------------------------------------------------------------------------------------------------------------
                        if (userInput2 == "1")
                        {
                            do
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine();
                                Console.WriteLine("\tYou are in the course mode! What would you like to do?");
                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.White;

                                Console.WriteLine("\t0. Exit.");
                                Console.WriteLine("\t1. New course.");
                                Console.WriteLine("\t2. Output list with all courses.");
                                Console.WriteLine("\t3. Add students at courses.");
                                Console.WriteLine("\t4. Output students per course.");
                                Console.WriteLine("\t5. Add trainers at courses.");
                                Console.WriteLine("\t6. Output trainers per course.");
                                Console.WriteLine("\t7. Add assignments at courses.");
                                Console.WriteLine("\t8. Output assignments per course.");
                                Console.WriteLine("\t9. Go back.");

                                Console.Write("\n\tPlease enter the appropriate number to select the field you are interested in : ");
                                userInput3 = Console.ReadLine();

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\n\t=================================================================================\n");
                                Console.ForegroundColor = ConsoleColor.White;

                                //UserInput3 = 1, normal mode, New course-------------------------------------------------------------------------------------------------------
                                if (userInput3 == "1")
                                {
                                    c1.InputCourse();
                                }
                                //UserInput3 = 2, normal mode, List of courses-------------------------------------------------------------------------------------------------------
                                else if (userInput3 == "2")
                                {
                                    c1.ListOfCoursecOutput(MyDatabase.allCourses);
                                    MyStaticClass.PressKeyToContinue();
                                }
                                //UserInput3 = 3, normal mode, Add students at courses-------------------------------------------------------------------------------------------------------
                                else if (userInput3 == "3")
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine();
                                    Console.WriteLine("\tSelect the number of course that you want to add students.");
                                    Console.WriteLine();
                                    Console.ForegroundColor = ConsoleColor.White;


                                    c1.ListOfCoursecOutput(MyDatabase.allCourses);
                                    Console.WriteLine();

                                    do
                                    {
                                        Console.Write("\tEnter the apropriate number : ");
                                        selectCourse = MyStaticClass.InputTryToConvertToInt();
                                    } while (selectCourse <= 0 || selectCourse > MyDatabase.allCourses.Count);


                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("\n\t=================================================================================\n");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    do
                                    {
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.WriteLine("\tSelect how you want to add a student.");
                                        Console.ForegroundColor = ConsoleColor.White;

                                        Console.WriteLine();
                                        Console.WriteLine("\t1. Add a new student.");
                                        Console.WriteLine("\t2. Add an excisting student.");
                                        Console.WriteLine("\t9. Go back.");

                                        Console.Write("\n\tPlease enter the appropriate number to select the field you are interested in : ");
                                        userInput5 = Console.ReadLine();

                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("\n\t=================================================================================\n");
                                        Console.ForegroundColor = ConsoleColor.White;

                                    } while ((userInput5 != "1" && userInput5 != "2") && userInput5 != "9");

                                    sPC.InputStudentsPerCourse(MyDatabase.allCourses[selectCourse - 1], userInput5);
                                }
                                //UserInput3 = 4, normal mode, Output students per course-------------------------------------------------------------------------------------------------------
                                else if (userInput3 == "4")
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine();
                                    Console.WriteLine("\tSelect the number of course that you want to output students.");
                                    Console.WriteLine();

                                    c1.ListOfCoursecOutput(MyDatabase.allCourses);
                                    Console.WriteLine();

                                    do
                                    {
                                        Console.Write("\tEnter the apropriate number : ");
                                        userInput4 = MyStaticClass.InputTryToConvertToInt();
                                    } while (userInput4 <= 0 || userInput4 > MyDatabase.allCourses.Count);

                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("\n\t=================================================================================\n");
                                    Console.ForegroundColor = ConsoleColor.White;

                                    sPC.OutputStudentsPerCourse((userInput4 - 1));
                                    MyStaticClass.PressKeyToContinue();
                                }
                                //UserInput3 = 5, normal mode, Add trainers at courses-------------------------------------------------------------------------------------------------------
                                else if (userInput3 == "5")
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine();
                                    Console.WriteLine("\tSelect the number of course that you want to add trainers.");
                                    Console.WriteLine();
                                    Console.ForegroundColor = ConsoleColor.White;


                                    c1.ListOfCoursecOutput(MyDatabase.allCourses);
                                    Console.WriteLine();

                                    do
                                    {
                                        Console.Write("\tEnter the apropriate number : ");
                                        selectCourse = MyStaticClass.InputTryToConvertToInt();
                                    } while (selectCourse <= 0 || selectCourse > MyDatabase.allCourses.Count);


                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("\n\t=================================================================================\n");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    do
                                    {
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.WriteLine("\tSelect how you want to add a trainer.");
                                        Console.ForegroundColor = ConsoleColor.White;

                                        Console.WriteLine();
                                        Console.WriteLine("\t1. Add a new trainer.");
                                        Console.WriteLine("\t2. Add an excisting trainer.");
                                        Console.WriteLine("\t9. Go back.");

                                        Console.Write("\n\tPlease enter the appropriate number to select the field you are interested in : ");
                                        userInput5 = Console.ReadLine();

                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("\n\t=================================================================================\n");
                                        Console.ForegroundColor = ConsoleColor.White;

                                    } while ((userInput5 != "1" && userInput5 != "2") && userInput5 != "9");

                                    tPC.InputTrainersPerCourse(MyDatabase.allCourses[selectCourse - 1], userInput5);
                                }
                                //UserInput3 = 6, normal mode, Output trainers per course-------------------------------------------------------------------------------------------------------
                                else if (userInput3 == "6")
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine();
                                    Console.WriteLine("\tSelect the number of course that you want to output trainers.");
                                    Console.WriteLine();

                                    c1.ListOfCoursecOutput(MyDatabase.allCourses);
                                    Console.WriteLine();

                                    do
                                    {
                                        Console.Write("\tEnter the apropriate number : ");
                                        userInput4 = MyStaticClass.InputTryToConvertToInt();
                                    } while (userInput4 <= 0 || userInput4 > MyDatabase.allCourses.Count);

                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("\n\t=================================================================================\n");
                                    Console.ForegroundColor = ConsoleColor.White;

                                    tPC.OutputTrainersPerCourse((userInput4 - 1));
                                    MyStaticClass.PressKeyToContinue();
                                }
                                //UserInput3 = 7, normal mode, Add assignments at courses-------------------------------------------------------------------------------------------------------
                                else if (userInput3 == "7")
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine();
                                    Console.WriteLine("\tSelect the number of course that you want to add assignments.");
                                    Console.WriteLine();
                                    Console.ForegroundColor = ConsoleColor.White;


                                    c1.ListOfCoursecOutput(MyDatabase.allCourses);
                                    Console.WriteLine();

                                    do
                                    {
                                        Console.Write("\tEnter the apropriate number : ");
                                        selectCourse = MyStaticClass.InputTryToConvertToInt();
                                    } while (selectCourse <= 0 || selectCourse > MyDatabase.allCourses.Count);


                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("\n\t=================================================================================\n");
                                    Console.ForegroundColor = ConsoleColor.White;

                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("\tSelect how you want to add an assignment.");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    do
                                    {

                                        Console.WriteLine();
                                        Console.WriteLine("\t1. Add a new assignment.");
                                        Console.WriteLine("\t2. Add an excisting assignment.");
                                        Console.WriteLine("\t9. Go back.");

                                        Console.Write("\n\tPlease enter the appropriate number to select the field you are interested in : ");
                                        userInput5 = Console.ReadLine();

                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("\n\t=================================================================================\n");
                                        Console.ForegroundColor = ConsoleColor.White;

                                    } while ((userInput5 != "1" && userInput5 != "2") && userInput5 != "9");

                                    aPC.InputAssignmentsPerCourse(MyDatabase.allCourses[selectCourse - 1], userInput5);
                                }
                                //UserInput3 = 8, normal mode, Output assignments per course-------------------------------------------------------------------------------------------------------
                                else if (userInput3 == "8")
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine();
                                    Console.WriteLine("\tSelect the number of course that you want to output assignments.");
                                    Console.WriteLine();

                                    c1.ListOfCoursecOutput(MyDatabase.allCourses);
                                    Console.WriteLine();

                                    do
                                    {
                                        Console.Write("\tEnter the apropriate number : ");
                                        userInput4 = MyStaticClass.InputTryToConvertToInt();
                                    } while (userInput4 <= 0 || userInput4 > MyDatabase.allCourses.Count);

                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("\n\t=================================================================================\n");
                                    Console.ForegroundColor = ConsoleColor.White;

                                    aPC.OutputAssignmetsPerCourse((userInput4 - 1));
                                    MyStaticClass.PressKeyToContinue();
                                }
                            } while (userInput3 != "0" && userInput3 != "9");
                        }
                        //UserInput2 = 2, normal mode, Assignment--------------------------------------------------------------------------------------------------------------------
                        else if (userInput2 == "2")
                        {
                            do
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine();
                                Console.WriteLine("\tYou are in the assignment mode! What would you like to do?");
                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("\t0. Exit.");
                                Console.WriteLine("\t1. New assignment.");
                                Console.WriteLine("\t2. Output list with all assignments.");
                                Console.WriteLine("\t9. Go back.");

                                Console.Write("\n\tPlease enter the appropriate number to select the field you are interested in : ");
                                userInput3 = Console.ReadLine();

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\n\t=================================================================================\n");
                                Console.ForegroundColor = ConsoleColor.White;

                                //UserInput3 = 1, normal mode, New Assignment-------------------------------------------------------------------------------------------------------
                                if (userInput3 == "1")
                                {
                                    a1.InputAssignment();
                                }
                                //UserInput3 = 2, normal mode, List of assignments-------------------------------------------------------------------------------------------------------
                                else if (userInput3 == "2")
                                {
                                    a1.ListOfAssignmentsOutput(MyDatabase.allAssignments);
                                    MyStaticClass.PressKeyToContinue();
                                }

                            } while ((userInput3 != "0" && userInput3 != "9") && (userInput3 != "1" && userInput3 != "2"));
                        }
                        //UserInput2 = 3, normal mode, Trainer--------------------------------------------------------------------------------------------------------------------
                        else if (userInput2 == "3")
                        {
                            do
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine();
                                Console.WriteLine("\tYou are in the trainer mode! What would you like to do?");
                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("\t0. Exit.");
                                Console.WriteLine("\t1. New trainer.");
                                Console.WriteLine("\t2. Output list with all trainers.");
                                Console.WriteLine("\t9. Go back.");

                                Console.Write("\n\tPlease enter the appropriate number to select the field you are interested in : ");
                                userInput3 = Console.ReadLine();

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\n\t=================================================================================\n");
                                Console.ForegroundColor = ConsoleColor.White;

                                //UserInput3 = 1, normal mode, New trainer-------------------------------------------------------------------------------------------------------
                                if (userInput3 == "1")
                                {
                                    tr1.InputTrainer();
                                }
                                //UserInput3 = 2, normal mode, List of trainers-------------------------------------------------------------------------------------------------------
                                else if (userInput3 == "2")
                                {
                                    tr1.ListOfTrainersOutput(MyDatabase.allTrainers);
                                    MyStaticClass.PressKeyToContinue();
                                }

                            } while ((userInput3 != "0" && userInput3 != "9") && (userInput3 != "1" && userInput3 != "2"));
                        }
                        //UserInput2 = 4, normal mode, Student--------------------------------------------------------------------------------------------------------------------
                        else if (userInput2 == "4")
                        {
                            do
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine();
                                Console.WriteLine("\tYou are in the student mode! What would you like to do?");
                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("\t0. Exit.");
                                Console.WriteLine("\t1. New student.");
                                Console.WriteLine("\t2. Output list with all students.");
                                Console.WriteLine("\t3. Add assignments at student.");
                                Console.WriteLine("\t4. Output assignments per student.");
                                Console.WriteLine("\t5. Output list witn students who belongs to more than one course.");
                                Console.WriteLine("\t6. Output list witn students who need to submit an assignment in a week.");
                                Console.WriteLine("\t9. Go back.");

                                Console.Write("\n\tPlease enter the appropriate number to select the field you are interested in : ");
                                userInput3 = Console.ReadLine();

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\n\t=================================================================================\n");
                                Console.ForegroundColor = ConsoleColor.White;

                                //UserInput3 = 1, normal mode, New Student-------------------------------------------------------------------------------------------------------
                                if (userInput3 == "1")
                                {
                                    s1.InputStudent();
                                }
                                //UserInput3 = 2, normal mode, List of students-------------------------------------------------------------------------------------------------------
                                else if (userInput3 == "2")
                                {
                                    s1.ListOfStudentsOutput(MyDatabase.allStudents);
                                    MyStaticClass.PressKeyToContinue();
                                }
                                //UserInput3 = 3, normal mode, Add assignments at students-------------------------------------------------------------------------------------------------------
                                else if (userInput3 == "3")
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine();
                                    Console.WriteLine("\tSelect the number of student that you want to add assignments.");
                                    Console.WriteLine();
                                    Console.ForegroundColor = ConsoleColor.White;


                                    s1.ListOfStudentsOutput(MyDatabase.allStudents);
                                    Console.WriteLine();

                                    do
                                    {
                                        Console.Write("\tEnter the apropriate number : ");
                                        selectStudent = MyStaticClass.InputTryToConvertToInt();
                                    } while (selectStudent <= 0 || selectStudent > MyDatabase.allStudents.Count);

                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("\n\t=================================================================================\n");
                                    Console.ForegroundColor = ConsoleColor.White;

                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("\tSelect how you want to add an assignment.");
                                    Console.ForegroundColor = ConsoleColor.White;

                                    do
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine("\t1. Add a new assignment.");
                                        Console.WriteLine("\t2. Add an excisting assignment.");
                                        Console.WriteLine("\t9. Go back.");

                                        Console.Write("\n\tPlease enter the appropriate number to select the field you are interested in : ");
                                        userInput5 = Console.ReadLine();

                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("\n\t=================================================================================\n");
                                        Console.ForegroundColor = ConsoleColor.White;

                                    } while ((userInput5 != "1" && userInput5 != "2") && userInput5 != "9");

                                    aPS.InputAssignmentsPerStudent(MyDatabase.allStudents[selectStudent - 1], userInput5);
                                }
                                //UserInput3 = 4, normal mode, Output assignments per student-------------------------------------------------------------------------------------------------------
                                else if (userInput3 == "4")
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine();
                                    Console.WriteLine("\tSelect the number of student that you want to output assignments.");
                                    Console.WriteLine();

                                    s1.ListOfStudentsOutput(MyDatabase.allStudents);
                                    Console.WriteLine();

                                    do
                                    {
                                        Console.Write("\tEnter the apropriate number : ");
                                        userInput4 = MyStaticClass.InputTryToConvertToInt();
                                    } while (userInput4 <= 0 || userInput4 > MyDatabase.allStudents.Count);

                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("\n\t=================================================================================\n");
                                    Console.ForegroundColor = ConsoleColor.White;

                                    aPS.OutputAssignmetsPerStudent(userInput4 - 1);
                                    MyStaticClass.PressKeyToContinue();
                                }
                                //UserInput3 = 5, normal mode, List of students who belongs to more than one course-------------------------------------------------------------------------------------------------------
                                else if (userInput3 == "5")
                                {
                                    s1.ListOfStudentsShowingTheNumberOfCoursesPerStudentOutput(s1.ReturnListOfStudentsWithMoreThanOneCourse());
                                    MyStaticClass.PressKeyToContinue();
                                }
                                //UserInput3 = 6, normal mode, List of students who need to submit an assignment in a week-------------------------------------------------------------------------------------------------------
                                else if (userInput3 == "6")
                                {
                                    Console.WriteLine();
                                    Console.Write("\tPlease enter a date DD/MM/YYYY: ");
                                    a1.StudentsSubmitAssignments(a1.assignmentsPerWeek(MyStaticClass.InputDate()));
                                    MyStaticClass.PressKeyToContinue();
                                }

                            } while ((userInput3 != "0" && userInput3 != "9") && (userInput3 != "1" && userInput3 != "2") && (userInput3 != "3" && userInput3 != "4") && (userInput3 != "5" && userInput3 != "6"));
                        }
                    } while ((userInput2 != "0" && userInput2 != "9") && userInput3 != "0");
                }
            } while ((userInput1 != "0" && userInput2 != "0") && userInput3 != "0");

            Console.WriteLine("\n\tTHANK YOU!!!");


            Console.ReadKey();
        }
    }
}
