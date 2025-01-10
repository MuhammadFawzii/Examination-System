using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class Student : Person
    {
        List<Exam>studentExams = new List<Exam>();
        // Email with validation
        private string? _email;
        private string _password;
        private Subject _subject;
        public string Email
        {
            get => _email;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || !value.Contains('@'))
                {
                    Console.WriteLine("Invalid email format.");
                    return;
                }
                _email = value;
            }
        }

        // Password with validation
        public string Password
        {
            get => _password;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 6)
                {
                    Console.WriteLine("Password must be at least 6 characters long.");
                    return;
                }
                _password = value;
            }
        }

        // Subject with validation
        public Subject Subject
        {
            get => _subject;
            set
            {
                if (value == null)
                {
                    Console.WriteLine("Subject cannot be null.");
                    return;
                }
                _subject = value;
            }
        }
        public Student(int _id, string _name, Subject subject, string _email, string _password) : base(_id, _name)
        {
            Email = _email;
            Password = _password;
            Subject = subject;
        }
        public static Student TakeStudentDetails()
        {
            Console.WriteLine("Enter ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Subject Code: ");
            string code = Console.ReadLine();
            Console.WriteLine("Enter Subject Name: ");
            string subject_name = Console.ReadLine();
            Subject subject = new Subject(code, subject_name);
            Console.WriteLine("Enter Email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Enter Password: ");
            string password = Console.ReadLine();
            Console.WriteLine("Student Added Successfully! \n");
            return new Student(id, name,subject, email, password);

        }
        
        private void GetExams(ExamType examtype)
        {
            foreach (var exam in Instructor.CreatedExams)
            {
                
                if (exam.GetType().Name.Equals(examtype.ToString()))
                {
                    studentExams.Add(exam);
                }
            }
        }
        // Method to view exams available for the student
        public void DisplayStudentExams(ExamType examtype)
        {
            GetExams(examtype);
            if (studentExams.Count == 0)
            {
                Console.WriteLine("No exams available for this student");
                return;
            }
            else
            {
                if (examtype == ExamType.ExamPractical)
                {
                    Console.WriteLine($"Practical Exams Available for {Name}:");
                    bool flag = true;
                    do
                    {
                        Console.WriteLine("Select Operation: ");
                        Console.WriteLine("- - - - - - - - -");
                        Console.WriteLine("1. View Exams Questions Details");
                        Console.WriteLine("2. View Exams Answers Details");
                        Console.WriteLine("3. Exit");
                        int choice = Convert.ToInt32(Console.ReadLine());
                        switch (choice)
                        {
                            case 1:

                                Console.WriteLine($"Number Of Exams :{studentExams.Count}");
                                Console.WriteLine("----------------------------------------");
                                for (int i = 0; i < studentExams.Count; i++)
                                {
                                    // Change mode to Starting
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    studentExams[i].Mode = ExamMode.Starting;
                                    Console.WriteLine("=========================================");
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    studentExams[i].Display();
                                    foreach (var item in studentExams[i].GetQuestions())
                                    {
                                        item.ViewQuestion();
                                    }
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    studentExams[i].Mode = ExamMode.Finished;
                                    Console.WriteLine("=========================================");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    //studentExams[i].DisplayExamQuestions();
                                }
                                break;
                            case 2:
                                for (int i = 0; i < studentExams.Count; i++)
                                {
                                    studentExams[i].Display();
                                    studentExams[i].ValidateAllAnswersToAllQuestion();
                                    studentExams[i].DisplayExamAnswers();
                                    studentExams[i].CalculateTotalMarksStudent();
                                    studentExams[i].DisplayTotalMarksStudent();
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.WriteLine("=========================================");
                                    Console.WriteLine("Good Luck Have fun!");
                                    Console.WriteLine("=========================================");
                                    Console.ResetColor();
                                }
                                break;
                            case 3:
                                flag = false;
                                Console.WriteLine("Exiting...");
                                break;
                            default:
                                Console.WriteLine("Invalid choice. Exiting...");
                                break;
                        }

                    } while (flag);
                }
                else
                {
                    Console.WriteLine($"Final Exams Available for {Name}:");
                    bool flag = true;
                    do
                    {
                        Console.WriteLine("Select Operation: ");
                        Console.WriteLine("- - - - - - - - -");
                        Console.WriteLine("1. View Exams Questions Details");
                        Console.WriteLine("2. Exit");
                        int choice = Convert.ToInt32(Console.ReadLine());
                        switch (choice)
                        {
                            case 1:
                                Console.WriteLine($"Number Of Exams :{studentExams.Count}");
                                Console.WriteLine("----------------------------------------");
                                for (int i = 0; i < studentExams.Count; i++)
                                {
                                    studentExams[i].Display();
                                    foreach (var item in studentExams[i].GetQuestions())
                                    {
                                        item.ViewQuestion();
                                    }

                                    studentExams[i].DisplayExamQuestions();
                                }
                                break;
                          
                            case 2:
                                flag = false;
                                Console.WriteLine("Exiting...");
                                break;
                            default:
                                Console.WriteLine("Invalid choice. Exiting...");
                                break;
                        }

                    } while (flag);
                }
                

                
            }

        }
      
        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Email: {Email}";
        }

        public override object Clone()
        {
            return new Student(Id, Name,Subject, Email, Password);  
        }
    }
}
