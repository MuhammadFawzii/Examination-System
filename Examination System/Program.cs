using System.Net;

namespace Examination_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                bool check = true;
                do
                {
                    Console.WriteLine("Welcome to the Examination System!");
                    Console.WriteLine("==================================");
                    Console.WriteLine("Select User Type:");
                    Console.WriteLine("1. Student");
                    Console.WriteLine("2. Instructor");
                    Console.WriteLine("3. Exit ");
                    int userType = Convert.ToInt32(Console.ReadLine());
                    switch (userType)
                    {
                        case 1:

                            Console.WriteLine("\nEnter Student Info:");
                            Console.WriteLine("----------------------");
                            Student std1 = Student.TakeStudentDetails();
                            Console.WriteLine("1. Take a Practice Exam");
                            Console.WriteLine("2. Take a Final Exam");
                            Console.WriteLine("3. Exit");
                            int studentChoice = Convert.ToInt32(Console.ReadLine());
                            switch (studentChoice)
                            {
                                case 1:
                                    Console.WriteLine($"{std1.Name},You have selected to take a Practice Exam in {std1.Subject.Subject_name}.");
                                    std1.DisplayStudentExams(ExamType.ExamPractical);
                                    break;
                                case 2:
                                    Console.WriteLine($"{std1.Name},You have selected to take a Final Exam in {std1.Subject.Subject_name}.");
                                    std1.DisplayStudentExams(ExamType.ExamFinal);
                                    break;
                                case 3:
                                    Console.WriteLine("Exiting...");
                                    break;
                                default:
                                    Console.WriteLine("Invalid choice. Exiting...");
                                    break;
                            }
                            break;
                        case 2:
                            Console.WriteLine("\nEnter Instructor Info:");
                            Console.WriteLine("----------------------");

                            Instructor ins1 = Instructor.TakeInstructorDetails();
                            Console.WriteLine("1. Create a Practice Exam");
                            Console.WriteLine("2. Create a Final Exam");
                            Console.WriteLine("3. Exit");
                            int instructorChoice = Convert.ToInt32(Console.ReadLine());
                            switch (instructorChoice)
                            {
                                case 1:
                                    Console.WriteLine($"Dr {ins1.Name},You have selected to create a Practice Exam in {ins1.Subject.Subject_name}.\n");
                                    Examine(ins1, ExamType.ExamPractical);

                                    break;
                                case 2:
                                    Console.WriteLine($"Dr {ins1.Name},You have selected to create a Final Exam in {ins1.Subject.Subject_name}.\n");
                                    Examine(ins1, ExamType.ExamFinal);
                                    break;
                                case 3:
                                    Console.WriteLine("Exiting...");
                                    Console.Clear();
                                    break;
                                default:
                                    Console.WriteLine("Invalid choice. Exiting...");
                                    break;
                            }
                            break;
                        case 3:
                            Console.WriteLine("Exiting...");
                            Console.Clear();
                            check = false; // Exit the loop
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Try again.");
                            break;
                    }


                } while (check);

            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }

            

        }


        public static void Examine(Instructor ins, ExamType examType)
        {
            // Define questions
            List<Question> ChooseOneQuestionList = new List<Question>
            {
                new QuestionChooseOne(
                    1,
                    "What is the capital of Pakistan?",
                    "Choose the correct answer.",
                    new[] { "A. Islamabad", "B. Karachi", "C. Lahore", "D. Quetta" },
                    3,
                    LDifficulty.Easy,
                    TypeQuestion.ChooseOne),

                new QuestionChooseOne(
                    2,
                    "What is the capital of USA?",
                    "Choose the correct answer.",
                    new[] { "A. Washington DC", "B. New York", "C. Los Angeles", "D. Chicago" },
                    3,
                    LDifficulty.Easy,
                    TypeQuestion.ChooseOne),

                new QuestionChooseOne(
                    3,
                    "What is the capital of UK?",
                    "Choose the correct answer.",
                    new[] { "A. London", "B. Manchester", "C. Birmingham", "D. Liverpool" },
                    5,
                    LDifficulty.Medium,
                    TypeQuestion.ChooseOne),

                new QuestionChooseOne(
                    4,
                    "What is the capital of China?",
                    "Choose the correct answer.",
                    new[] { "A. Islamabad", "B. Washington DC", "C. London", "D. Beijing" },
                    2,
                    LDifficulty.Easy,
                    TypeQuestion.ChooseOne),

                new QuestionChooseOne(
                    5,
                    "What is the capital of India?",
                    "Choose the correct answer.",
                    new[] { "A. Islamabad", "B. Washington DC", "C. London", "D. Beijing" },
                    4,
                    LDifficulty.Hard,
                    TypeQuestion.ChooseOne)
            };
            // Define answers
            List<Answer> ChooseOneAnswerList = new List<Answer>
            {
                new Answer(1, "A"),
                new Answer(2, "A"),
                new Answer(3, "A"),
                new Answer(4, "D"),
                new Answer(5, "D")
            };
            // Define questions
            List<Question> TFQuestionList = new List<Question>
            {
                new QuestionTrueFalse(6, "Is the sky blue?", "Choose the correct answer.",new string[]{"True","False"}, 3, LDifficulty.Easy, TypeQuestion.TF),
                new QuestionTrueFalse(7, "Is water wet?", "Choose the correct answer.",new string[]{"True","False"}, 3, LDifficulty.Easy, TypeQuestion.TF),
                new QuestionTrueFalse(8, "Does the sun rise in the west?", "Choose the correct answer.",new string[]{"True","False"}, 5, LDifficulty.Medium, TypeQuestion.TF),
                new QuestionTrueFalse(9, "Is 2+2 equal to 4?", "Choose the correct answer.",new string[]{"True","False"}, 2, LDifficulty.Easy, TypeQuestion.TF),
                new QuestionTrueFalse(10, "Is Earth flat?", "Choose the correct answer.",new string[]{"True","False"}, 4, LDifficulty.Hard, TypeQuestion.TF)
            };
            // Define answers
            List<Answer> TFAnswerList = new List<Answer>
            {
                new Answer(6, "True"),
                new Answer(7, "True"),
                new Answer(8, "False"),
                new Answer(9, "True"),
                new Answer(10, "False")
            };
            // Create 5 `QooseAll_Question` objects
            List<Question> ChooseAllQuestionList = new List<Question>
            {
                new QuestionChooseAll(11, "Which cities are in Pakistan?", "Choose all correct answers.",
                    new[] { "A. Islamabad", "B. Karachi", "C. London", "D. Quetta" },
                    5.0, LDifficulty.Easy, TypeQuestion.ChooseAll),

                new QuestionChooseAll(12, "Which are programming languages?", "Choose all correct answers.",
                    new[] { "A. Python", "B. Java", "C. HTML", "D. JavaScript" },
                    5.0, LDifficulty.Medium, TypeQuestion.ChooseAll),

                new QuestionChooseAll(13, "Which are fruits?", "Choose all correct answers.",
                    new[] { "A. Apple", "B. Carrot", "C. Banana", "D. Potato" },
                    5.0, LDifficulty.Easy, TypeQuestion.ChooseAll),

                new QuestionChooseAll(14, "Which are continents?", "Choose all correct answers.",
                    new[] { "A. Asia", "B. Europe", "C. Antarctica", "D. Pacific Ocean" },
                    5.0, LDifficulty.Hard, TypeQuestion.ChooseAll),

                new QuestionChooseAll(15, "Which are prime numbers?", "Choose all correct answers.",
                    new[] { "A. 2", "B. 3", "C. 4", "D. 5" },
                    5.0, LDifficulty.Hard, TypeQuestion.ChooseAll)
            };
            // Create corresponding Answer objects
            List<Answer> ChooseAllAnswerList = new List<Answer>
            {
                new Answer(11, "A,B,D"), // Correct answers for Question 1
                new Answer(12, "A,B,D"), // Correct answers for Question 2
                new Answer(13, "A,C"),   // Correct answers for Question 3
                new Answer(14, "A,B,C"), // Correct answers for Question 4
                new Answer(15, "A,B,D")  // Correct answers for Question 5
            };
            // Create exams
            WriteQuestionsAndAnswers("trueFalse.txt", TFQuestionList, TFAnswerList);
            WriteQuestionsAndAnswers("chooseOne.txt", ChooseOneQuestionList, ChooseOneAnswerList);
            WriteQuestionsAndAnswers("chooseAll.txt", ChooseAllQuestionList, ChooseAllAnswerList);


            bool check = true;
            List<Question> AllQuestions = new List<Question>();
            List<Answer> AllAnswers = new List<Answer>();
            List<Question> QuestionList = new List<Question>();
            List<Answer> AnswerList = new List<Answer>();
            do
            {

                Console.WriteLine("Select type Of Questions:");
                Console.WriteLine("1. True False");
                Console.WriteLine("2. Choose One");
                Console.WriteLine("3. Choose All");
                Console.WriteLine("4. Exit");
                int questionType = Convert.ToInt32(Console.ReadLine());
                switch (questionType)
                {
                    case 1:
                        HandleQuestionType(TypeQuestion.TF, "trueFalse.txt", AllQuestions, AllAnswers, examType, ins, out QuestionList, out AnswerList);
                        break;
                    case 2:
                        HandleQuestionType(TypeQuestion.ChooseOne, "chooseOne.txt", AllQuestions, AllAnswers, examType, ins, out QuestionList, out AnswerList);

                        break;
                    case 3:
                        HandleQuestionType(TypeQuestion.ChooseAll, "chooseAll.txt", AllQuestions, AllAnswers, examType, ins, out QuestionList, out AnswerList);

                        break;
                    case 4:
                        Console.WriteLine("Exiting...");
                        Console.Clear();
                        check = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            } while (check);

            ins.CreateNewExam(QuestionList, AnswerList, examType);
            Console.WriteLine("Exam Created Successfully!");




        }

        private static void HandleQuestionType(TypeQuestion questionType, string fileName, List<Question> allQuestions, List<Answer> allAnswers,ExamType examType,Instructor ins,out List<Question> outQuestions,out List<Answer>outAnswers)
        {
            bool addMore = true;
            do
            {
                Console.WriteLine("1. Add new Question and Answer to files");
                Console.WriteLine("2. Load Questions and Answers from Files");
                Console.WriteLine("3. Exit");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Question qes;
                        Answer ans;
                        Instructor.TakeQuestionAndAnswerDetails(questionType, out qes, out ans);
                        
                        allQuestions.Add(qes);
                        allAnswers.Add(ans);
                        break;

                    case 2:
                        var (loadedQuestions, loadedAnswers) = ReadQuestionsAndAnswers(fileName, questionType);
                        allQuestions.AddRange(loadedQuestions);
                        allAnswers.AddRange(loadedAnswers);

                        break;

                    case 3:
                        Console.WriteLine("Exiting...");
                        Console.Clear();
                        addMore = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            } while (addMore);

            outAnswers = allAnswers;
            outQuestions = allQuestions;
        }

        int SafeConvertToInt(string input, int defaultValue)
        {
            return int.TryParse(input, out int result) ? result : defaultValue;
        }

        public static void WriteQuestionsAndAnswers(string filePath, List<Question> questions, List<Answer> answers)
        {
            using (TextWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine("Questions:");
                foreach (var question in questions)
                {
                    writer.WriteLine($"{question.Id}|{question.Header}|{question.Body}|{string.Join(",", question.Options)}|{question.Marks}|{question.Difficulty}|{question.TypeQuestion}");
                }

                writer.WriteLine("Answers:");
                foreach (var answer in answers)
                {
                    writer.WriteLine($"{answer.Id}|{answer.CorrectAnswer}");
                }
            }


        }

        public static (List<Question>, List<Answer>) ReadQuestionsAndAnswers(string filePath,TypeQuestion qtype)
        {
            List<Question> questions = new List<Question>();
            List<Answer> answers = new List<Answer>();

            if (File.Exists(filePath))
            {
                using (TextReader reader = new StreamReader(filePath))
                {
                    string? line;
                    bool isReadingQuestions = false;
                    bool isReadingAnswers = false;

                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line == "Questions:")
                        {
                            isReadingQuestions = true;
                            isReadingAnswers = false;
                            continue;
                        }
                        if (line == "Answers:")
                        {
                            isReadingQuestions = false;
                            isReadingAnswers = true;
                            continue;
                        }

                        if (isReadingQuestions)
                        {
                            if(qtype == TypeQuestion.ChooseOne)
                            {
                                var parts = line.Split('|');
                                questions.Add(new QuestionChooseOne(
                                    int.Parse(parts[0]),
                                    parts[1],
                                    parts[2],
                                    parts[3].Split(','),
                                    double.Parse(parts[4]),
                                    Enum.Parse<LDifficulty>(parts[5]),
                                    Enum.Parse<TypeQuestion>(parts[6])
                                ));
                            }
                            else if (qtype == TypeQuestion.TF)
                            {
                                var parts = line.Split('|');
                                questions.Add(new QuestionTrueFalse(
                                    int.Parse(parts[0]),
                                    parts[1],
                                    parts[2],
                                    parts[3].Split(','),
                                    double.Parse(parts[4]),
                                    Enum.Parse<LDifficulty>(parts[5]),
                                    Enum.Parse<TypeQuestion>(parts[6])
                                ));
                            }
                            else if (qtype == TypeQuestion.ChooseAll)
                            {
                                var parts = line.Split('|');
                                questions.Add(new QuestionChooseAll(
                                    int.Parse(parts[0]),
                                    parts[1],
                                    parts[2],
                                    parts[3].Split(','),
                                    double.Parse(parts[4]),
                                    Enum.Parse<LDifficulty>(parts[5]),
                                    Enum.Parse<TypeQuestion>(parts[6])
                                ));
                            }


                        }
                        else if (isReadingAnswers)
                        {
                            var parts = line.Split('|');
                            answers.Add(new Answer(int.Parse(parts[0]), parts[1]));
                        }
                    }
                }

                Console.WriteLine("Questions and answers have been read from the file.");
            }
            else
            {
                Console.WriteLine("File not found.");
            }

            return (questions, answers);
        }
    }


}

