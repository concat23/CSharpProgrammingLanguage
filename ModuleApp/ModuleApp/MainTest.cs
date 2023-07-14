using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleApp
{
    internal class MainTest
    {
        
        class Student
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Sex { get; set; }
            public string Age { get; set; }
            public string PointMath { get; set; }
            public string PointPhysics { get; set; }
            public string PointChemistry { get; set; }

            public Student()
            {
                Random autonumber = new Random();
                Id = autonumber.Next();
            }

            public Student(string name, string sex, string age, string pointmath, string pointphysics, string pointchemistry)
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
               
                Console.WriteLine("Enter your name: ");
                
                sv.Name = Console.ReadLine();
                Console.WriteLine("Enter your sex: ");
                
                sv.Sex = Console.ReadLine();                                                   
                Console.WriteLine("Enter your age: ");
                
                sv.Age = Console.ReadLine();
                Console.WriteLine("Enter your point math: ");
                
                sv.PointMath = Console.ReadLine();
                Console.WriteLine("Enter your point physics: ");
                
                sv.PointPhysics = Console.ReadLine();               
                Console.WriteLine("Enter your point chemistry: ");
            
                sv.PointChemistry = Console.ReadLine();
                
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

            public  void ShowStudentList()
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


        public static void Main(string[] args)
        {
            
            Console.WriteLine("Welcome to my system");

            //Cach 1: de test
            //string Name = "Nguyen Van A";
            //string Sex = "Nam";
            //int Age = 19;
            //double PointMath = 7.00;
            //double PointPhysics = 8.5;
            //double PointChemistry = 8.0;
           // Student sv = new Student(Name, Sex, Age, PointMath, PointPhysics, PointChemistry);

            //Cach 2: 

           

            Student sv = new Student();
            sv.InputStudent(sv);
            sv.OutputStudent(sv);

           StudentManangement sm = new StudentManangement();
           sm.AddStudent(sv);
           sm.ShowStudentList();


           
            
            Console.ReadKey();
        } 
    }
}
