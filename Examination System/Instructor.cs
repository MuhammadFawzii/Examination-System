using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class Instructor : Person
    {
        private static List<Exam> createdExams = new List<Exam>();
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
        public static List<Exam> CreatedExams { get => createdExams; set => createdExams = value; }

        public Instructor(int id, string name,Subject subject, string email, string password)
            : base(id, name)
        {
            Email = email;
            Password = password;
            Subject = subject;

        }
        public static Instructor TakeInstructorDetails()
        {
            Console.WriteLine("Enter ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter  Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Enter Password: ");
            string password = Console.ReadLine();
            Console.WriteLine("Enter Subject Code: ");
            string code = Console.ReadLine();
            Console.WriteLine("Enter Subject Name: ");
            string subject_name = Console.ReadLine();
            Subject subject = new Subject(code, subject_name);
            Console.WriteLine("Instructor Created Successfully! \n");
            return new Instructor(id, name, subject, email, password);

        }
        public static void TakeQuestionAndAnswerDetails(TypeQuestion typeQuestion,out Question question,out Answer answer)
        {
            Console.WriteLine("Enter Question Details:");
            Console.WriteLine("----------------------");
            Console.WriteLine("Enter Question Id:");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Question Header:");
            string header = Console.ReadLine();
            Console.WriteLine("Enter Question Body:");
            string body = Console.ReadLine();
            Console.WriteLine("Enter Question Options:");
            string[] options = Console.ReadLine().Split(',');
            Console.WriteLine("Enter Question Marks:");
            double marks = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter Question Difficulty:");
            LDifficulty difficulty = (LDifficulty)Enum.Parse(typeof(LDifficulty), Console.ReadLine());
            Console.WriteLine("Enter Correct Answer:");
            string correctAnswer = Console.ReadLine();
            answer=new Answer(id,correctAnswer);
            if (typeQuestion == TypeQuestion.TF)
            {
                 question = new QuestionTrueFalse(id, header, body, options, marks, difficulty, typeQuestion);
            }
            else if (typeQuestion == TypeQuestion.ChooseOne)
            {
                question = new QuestionChooseOne(id, header, body, options, marks, difficulty, typeQuestion);
            }
            else
            {
                question = new QuestionChooseAll(id, header, body, options, marks, difficulty, typeQuestion);
            }
            


        }
     
        // Method to create exams
        private Exam AddExamToExamsList(ExamType examType, Subject subject, int examId, double timeExam)
        {
            Exam exam = ExamFactory.CreateExam(examType, subject, examId, timeExam);
            CreatedExams.Add(exam);
            return exam;
        }

        public void CreateNewExam(List<Question> QList, List<Answer> AList,ExamType examType)
        {
            QList.Sort();
            AList.Sort();
            Exam PracticeExam;
            Exam FinalExam;
            int examId=CreatedExams.Count+1;
            if (examType == ExamType.ExamPractical)
            {
                // Call the loading animation function
                ShowLoadingDots("Creating Practice Exam", 10, 300);
                Console.WriteLine("\n" + new string('!', 50)); // Divider for clarity
                PracticeExam = this.AddExamToExamsList(ExamType.ExamPractical,this.Subject, examId, 60);
                PracticeExam.CreatingExamIns(QList, AList, ExamType.ExamPractical);
                PracticeExam.OnExamStarting += PracticeExam.Notify;
            }
            else
            {
                ShowLoadingDots("Creating Final Exam", 10, 500);
                Console.WriteLine("\n" + new string('!', 50)); // Divider for clarity
                FinalExam = this.AddExamToExamsList(ExamType.ExamFinal, this.Subject, examId, 60);
                FinalExam.CreatingExamIns(QList, AList, ExamType.ExamFinal);
                FinalExam.OnExamStarting += FinalExam.Notify;
            }
            Console.WriteLine(new string('*', 50)); // Divider for clarity
            bool flag = true;
            do
            {
                Console.WriteLine("Select Operation: ");
                Console.WriteLine("- - - - - - - - -");
                Console.WriteLine("1. View Exams Details");
                Console.WriteLine("2. View Exams Questions");
                Console.WriteLine("3. View Exams Answers");
                Console.WriteLine("4. Exit");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine($"Number Of Exams :{CreatedExams.Count}");
                        for (int i = 0; i < CreatedExams.Count; i++)
                        {
                            Console.WriteLine($"Exam {i + 1} :{CreatedExams[0].GetType().Name}");
                            CreatedExams[i].Display();
                        }
                        break;
                    case 2:
                        Console.WriteLine("Enter Exam Number For Getting Questions: ");
                        int examNumber = Convert.ToInt32(Console.ReadLine());
                        CreatedExams[examNumber - 1].DisplayExamQuestions();
                        break;
                    case 3:
                        Console.WriteLine("Enter Exam Number For Getting Answers: ");
                        int examNumber1 = Convert.ToInt32(Console.ReadLine());
                        CreatedExams[examNumber1 - 1].DisplayExamAnswers();
                        break;
                    case 4:
                        flag = false;
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Exiting...");
                        break;
                }

            } while (flag);

            
        }


        public void ShowLoadingDots(string message, int dotCount, int delay)
        {
            // Display the initial message
            Console.Write(message);

            for (int i = 0; i < dotCount; i++)
            {
                // Add a dot
                Console.Write(".");
                // Wait for the specified delay
                Thread.Sleep(delay);
            }
        }

        public override object Clone()
        {
            return new Instructor(Id, Name, Subject,Email, Password);
        }
    }


}
