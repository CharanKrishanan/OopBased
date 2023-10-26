using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopBased
{
    class Student
    {
        public string Name { get; set; }
        public string ClassAndSection { get; set; }
    }

    class Teacher
    {
        public string Name { get; set; }
        public string ClassAndSection { get; set; }
    }

    class Subject
    {
        public string Name { get; set; }
        public string SubjectCode { get; set; }
        public Teacher Teacher { get; set; }
    }

    class Program
    {
        static List<Student> students = new List<Student>();
        static List<Teacher> teachers = new List<Teacher>();
        static List<Subject> subjects = new List<Subject>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Add Teacher");
                Console.WriteLine("3. Add Subject");
                Console.WriteLine("4. Display Students in a Class");
                Console.WriteLine("5. Display Subjects Taught by Teacher");
                Console.WriteLine("6. Exit");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddStudent();
                        break;
                    case 2:
                        AddTeacher();
                        break;
                    case 3:
                        AddSubject();
                        break;
                    case 4:
                        DisplayStudentsInClass();
                        break;
                    case 5:
                        DisplaySubjectsTaughtByTeacher();
                        break;
                    case 6:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void AddStudent()
        {
            Console.Write("Enter student name: ");
            string name = Console.ReadLine();
            Console.Write("Enter class and section: ");
            string classAndSection = Console.ReadLine();

            students.Add(new Student { Name = name, ClassAndSection = classAndSection });
            Console.WriteLine("Student added successfully.");
        }

        static void AddTeacher()
        {
            Console.Write("Enter teacher name: ");
            string name = Console.ReadLine();
            Console.Write("Enter class and section: ");
            string classAndSection = Console.ReadLine();

            teachers.Add(new Teacher { Name = name, ClassAndSection = classAndSection });
            Console.WriteLine("Teacher added successfully.");
        }

        static void AddSubject()
        {
            Console.Write("Enter subject name: ");
            string name = Console.ReadLine();
            Console.Write("Enter subject code: ");
            string subjectCode = Console.ReadLine();
            Console.Write("Enter teacher name: ");
            string teacherName = Console.ReadLine();

            Teacher teacher = teachers.Find(t => t.Name == teacherName);
            if (teacher == null)
            {
                Console.WriteLine("Teacher not found. Please add the teacher first.");
                return;
            }

            subjects.Add(new Subject { Name = name, SubjectCode = subjectCode, Teacher = teacher });
            Console.WriteLine("Subject added successfully.");
        }

        static void DisplayStudentsInClass()
        {
            Console.Write("Enter class and section: ");
            string className = Console.ReadLine();

            Console.WriteLine($"Students in {className}:");
            foreach (var student in students)
            {
                if (student.ClassAndSection == className)
                {
                    Console.WriteLine(student.Name);
                }
            }
        }

        static void DisplaySubjectsTaughtByTeacher()
        {
            Console.Write("Enter teacher name: ");
            string teacherName = Console.ReadLine();

            Console.WriteLine($"Subjects taught by {teacherName}:");
            foreach (var subject in subjects)
            {
                if (subject.Teacher.Name == teacherName)
                {
                    Console.WriteLine($"{subject.Name} ({subject.SubjectCode})");
                }
            }
        }
    }
}