
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleApp
{
     
        class Student
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Gender { get; set; }
            public int Age { get; set; }
            public double PointMath { get; set; }
            public double PointPhysics { get; set; }
            public double PointChemistry { get; set; }

            public Student()
            {
                Random autonumber = new Random();
                Id = autonumber.Next();
            }

            public Student(string name, string gender, int age, double pointmath, double pointphysics, double pointchemistry)
            {
                Name = name; 
                Gender = gender;
                Age = age;
                PointMath = pointmath;
                PointPhysics = pointphysics;
                PointChemistry = pointchemistry;
            }

            public void InputStudent(Student sv)
            {
                if(sv != null)
                {
                    Console.Write("Enter your name: ");
                    sv.Name = Console.ReadLine();
                    
                    Console.Write("Enter your gender: ");
                    sv.Gender = Console.ReadLine();

                    Console.Write("Enter your age: ");
                    sv.Age = Convert.ToInt32(Console.ReadLine());


                    Console.Write("Enter your point math: ");
                    sv.PointMath = Convert.ToDouble(Console.ReadLine());

                    Console.Write("Enter your point physics: ");
                    sv.PointPhysics = Convert.ToDouble(Console.ReadLine());

                    Console.Write("Enter your point chemistry: ");
                    sv.PointChemistry = Convert.ToDouble(Console.ReadLine());
                }
                else
                {
                    return;
                }
             

            }

            public void OutputStudent(Student sv)
            {
                int resultAge;
                double resultMath;
                double resultPhysics;
                double resultChemistry;
                bool IsCheckInputAge = int.TryParse(sv.Age.ToString(), out resultAge);
                bool IsCheckIputMath = double.TryParse(sv.PointMath.ToString(), out resultMath);
                bool IsCheckIputPhysics = double.TryParse(sv.PointPhysics.ToString(), out resultPhysics);
                bool IsCheckIputChemistry = double.TryParse(sv.PointChemistry.ToString(), out resultChemistry);
                if (IsCheckInputAge || IsCheckIputMath || IsCheckIputPhysics || IsCheckIputChemistry)
                {
                string formatString = $"Id: {sv.Id}, Name: {sv.Name}, Gender: {sv.Gender}, Age: {resultAge}, " +
                            $"Point math: {resultMath}, Point physics: {resultPhysics}, Point chemistry: {resultChemistry}";
                Console.WriteLine(formatString);
            }

            }

        }

        class StudentManagement
        {
            private List<Student> listStudent;

            public StudentManagement()
            {
                listStudent = new List<Student>();
            }

            public void StudentList()
            {
               if(listStudent != null && listStudent.Count > 0)
                {
                    for(int i = 0; i < listStudent.Count; i++)
                    {
                        listStudent[i].OutputStudent(listStudent[i]);
                    }
                }
            }

            public void AddStudent(Student sv)
            {
                listStudent.Add(sv);
            }
        }



    internal static class TestHelpers
    {
        public static void MainMenu()
        {
            Console.WriteLine("========== WELCOME TO MY SYSTEM =========");
            Console.WriteLine("I. STUDENT MANAGEMENT");
            Console.WriteLine("O. EXIT");
        }

        public static void SubMenu()
        {
            Console.WriteLine("1. List");
            Console.WriteLine("2. Add");
            Console.WriteLine("0. Back");
        }

        static void Main(string[] args)
        {
            StudentManagement sm = new StudentManagement();
            bool exit = false;

            do
            {
                MainMenu();
                Console.Write("Enter your option: ");
                char mainChoice = Console.ReadKey().KeyChar;

                switch (mainChoice)
                {
                    case 'I':
                        Console.Clear();
                        bool backToMainMenu = false;

                        do
                        {
                            SubMenu();
                            Console.Write("Enter your feature: ");
                            char subChoice = Console.ReadKey().KeyChar;

                            Student student = new Student();
                            switch (subChoice)
                            {
                                case '1':
                                    Console.Clear();
                                    sm.StudentList();
                                    Console.WriteLine("Press any key to continue.");
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;

                                case '2':
                                    Console.Clear();
                                    Console.Write("Enter the number of students to add: ");
                                    int numberOfStudents = Convert.ToInt32(Console.ReadLine());
                                    for (int i = 0; i < numberOfStudents; i++)
                                    {
                                        Console.WriteLine("Student ["+ (i+1) +"]:");                                        student = new Student();                                    
                                        student.InputStudent(student);
                                        sm.AddStudent(student);
                                      
                                    }

                                    Console.WriteLine("Students added successfully.");
                                    Console.WriteLine("Press any key to continue.");
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;

                                case '0':
                                    backToMainMenu = true;
                                    Console.Clear();
                                    break;

                                default:
                                    Console.WriteLine("Invalid choice. Please try again.");
                                    break;
                            }
                        } while (!backToMainMenu);

                        break;

                    case 'O':
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.Clear();
            } while (!exit);

            Console.WriteLine("Thank you for using the system. Goodbye!");
            Console.ReadKey();
        }
    }

}


