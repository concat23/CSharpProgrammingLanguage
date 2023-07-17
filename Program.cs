using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management
{
    internal class Program
    {
        class Student
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Sex { get; set; }
            public int Age { get; set; }
            public double PointMath { get; set; }
            public double PointPhysics { get; set; }
            public double PointChemistry { get; set; }

            public Student()
            {
                Random autonumber = new Random();
                Id = autonumber.Next();
            }

            public Student(string name, string sex, int age, double pointmath, double pointphysics, double pointchemistry)
            {
                Name = name;
                Sex = sex;
                Age = age;
                PointMath = pointmath;
                PointPhysics = pointphysics;
                PointChemistry = pointchemistry;
            }

            public void InputStudent(Student sv)
            {

                Console.Write("Enter your name: " + Console.ReadLine());
                sv.Name = Convert.ToString(Console.ReadLine());

                Console.Write("Enter your sex: ");
                sv.Sex = Convert.ToString(Console.ReadLine());

                Console.Write("Enter your age: ");
                sv.Age = Convert.ToInt32(Console.ReadLine());


                Console.Write("Enter your point math: ");
                sv.PointMath = Convert.ToDouble(Console.ReadLine());

                Console.Write("Enter your point physics: ");
                sv.PointPhysics = Convert.ToDouble(Console.ReadLine());

                Console.Write("Enter your point chemistry: ");
                sv.PointChemistry = Convert.ToDouble(Console.ReadLine());
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
                    string formatString = "Id: {0}, Name: {1}, Sex: {2}, Age: {3}, Point math: {4}, Point physics: {5}, Point chemistry: {6}";
                    Console.WriteLine(formatString, sv.Id, sv.Name, sv.Sex, resultAge, resultMath, resultPhysics, resultChemistry);
                }

            }

        }

        class StudentManangement
        {
            private List<Student> listStudent;

            public StudentManangement()
            {
                listStudent = new List<Student>();
            }

            public void ShowStudentList()
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


        public static void Main(string[] args)
        {
            //Cach 1: de test
            //string Name = "Nguyen Van A";
            //string Sex = "Nam";
            //int Age = 19;
            //double PointMath = 7.00;
            //double PointPhysics = 8.5;
            //double PointChemistry = 8.0;
            // Student sv = new Student(Name, Sex, Age, PointMath, PointPhysics, PointChemistry);

            //Cach 2: 

            StudentManangement sm = new StudentManangement();


            int select = 0;
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("1. Input student into list.");
                Console.WriteLine("2. Output student information.");
                Console.WriteLine("0. Break");

                Console.Write("\nEnter your choice: ");
                select = Convert.ToInt32(Console.ReadLine());

                if (select < 0 || select > 2)
                {
                    Console.WriteLine("\nError: Your choice not right !!!\n");
                }
                else if (select == 1)
                {
                    int number;
                    Console.Write("Enter the number of student: ");
                    number = Convert.ToInt32(Console.ReadLine());
                    for (int i = 0; i < number; i++)
                    {
                        Student sv = new Student();
                        Console.WriteLine("\n----Enter the " + (i + 1) + "st student information:");
                        sv.InputStudent(sv);
                        sm.AddStudent(sv);
                    }
                }
                else if (select == 2)
                {
                    sm.ShowStudentList();
                    Console.ReadKey();
                }
                else
                {
                    break;
                }

            }













        }
    }
}
