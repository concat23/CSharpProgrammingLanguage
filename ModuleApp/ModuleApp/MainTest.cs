
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
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

        public Student(String name, string gender, int age, double pointmath, double pointphysics, double pointchemistry)
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
            if (sv != null)
            {
                Console.Write("Enter your name: ");
                sv.Name = Convert.ToString(Console.ReadLine());

                sv.Name = string_handling(sv.Name);
                
                if(IsNumberInName(sv.Name) == true || IsLowerCase(sv.Name) == true || IsEmptyString(sv.Name) == true)
                {
                    do
                    {
                        if (IsNumberInName(sv.Name) == true || IsLowerCase(sv.Name) == true || IsEmptyString(sv.Name) == true)
                        {
                            Console.WriteLine("Not right syntax !!!");
                        }

                        Console.Write("Enter your name: ");
                        sv.Name = Convert.ToString(Console.ReadLine());

                        sv.Name = string_handling(sv.Name);

                    } while (IsNumberInName(sv.Name) == true || IsLowerCase(sv.Name) == true || IsEmptyString(sv.Name) == true);
                }
                



                Console.Write("Enter your gender: ");
                sv.Gender = Console.ReadLine();

                Console.Write("Enter your age: ");
                string TemptAge = Convert.ToString(Console.ReadLine());
                sv.Age = AgeHandling(TemptAge);
                


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

        public int AgeHandling(string value)
        {
            int tempt;
            do 
            {
                if(IsAge(value) == true)
                {
                    Console.WriteLine("Error: must not contain characters inside age !!!");
                }
                Console.Write("Enter your age: ");
                value = Convert.ToString(Console.ReadLine());
            } while (IsAge(value) == true);
             
            tempt = Convert.ToInt32(value);
            return tempt;
        }


        public bool IsAge(string value)
        {
            char[] T = value.ToCharArray();
            for(int i = 0; i < T.Length; i++)
            {
                if ((T[i] >= 65 && T[i] <= 90) || (T[i] >= 97 && T[i] <= 122))
                {
                    return true;
                }
            }
            return false;
        }

        

        public bool IsEmptyString(string name)
        {
            if (name == null || name.Length == 0)
            {
                return true;
            }
            else
            {
                return false;
            }      
        }

        public bool IsLowerCase(string name)
        {
            char[] t = name.ToCharArray();
            int lents = t.Length;
            for (int i = 0; i < lents; i++)
            {
                if ((t[i] >=97 && t[i] <= 122) || (t[i] >= 33 && t[i] <= 63))
                {
                    return true;
                }
            }
            return false;
        }


        public string string_handling(string name)
        {
            if(IsEmptyString(name) == true)
            {
                return name;
            }
            string tempt = delete_space_head_tail(name);
            name = tempt;

            char[] t;
            t = delete_space_middle(name);
            name = new string(t);
            return name;
        }

        public char[] delete_space_middle(string name)
        {
            
            char[] tempt = name.ToCharArray();

            int lents = tempt.Length;

            for(int i = 0; i < lents; i++)
            {
                if (tempt[i] == 32 && tempt[i + 1] == 32)
                {
                    for(int j = i + 1; j < lents - 1; j++)
                    {
                        tempt[j] = tempt[j + 1];
                    }
                    i--;
                    lents--;
                    tempt[lents - 1] = '\0';
                }
            }
            return tempt;
        }




        public string delete_space_head_tail(string name)
        {
            string tempt = name.TrimStart();
            tempt = tempt.TrimEnd();
            return tempt;
        }
       
        public bool IsNumberInName(String name)
        {
            for(int i = 0; i < name.Length; i++)
            {
                if (char.IsDigit(name[i]) == true)
                {
                    return true;
                }
            }
            return false;
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
            if (listStudent != null && listStudent.Count > 0)
            {
                for (int i = 0; i < listStudent.Count; i++)
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
                            int subChoice = Convert.ToInt32(Console.ReadLine());
                            //char subChoice = Console.ReadKey().KeyChar;

                            Student student = new Student();
                            switch (subChoice)
                            {
                                case 1:
                                    Console.Clear();
                                    sm.StudentList();
                                    Console.WriteLine("Press any key to continue.");
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;

                                case 2:
                                    Console.Clear();
                                    Console.Write("Enter the number of students to add: ");
                                        int numberOfStudents = Convert.ToInt32(Console.ReadLine());
                                    for (int i = 0; i < numberOfStudents; i++)
                                    {
                                        Console.WriteLine("Student [" + (i + 1) + "]:"); student = new Student();
                                        student.InputStudent(student);
                                        sm.AddStudent(student);

                                    }

                                    Console.WriteLine("Students added successfully.");
                                    Console.WriteLine("Press any key to continue.");
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;

                                case 0:
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

