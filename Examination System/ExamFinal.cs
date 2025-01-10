using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    // FinalExam class inherits from Exam
    internal class ExamFinal : Exam
    {
        // Constructor to initialize FinalExam
        public ExamFinal(int exam_id, double time_exam, Subject subject)
            : base(exam_id, time_exam, subject)
        {
            Mode = ExamMode.Queued;

        }

        // Method to print a question
        private void PrintQuestion(Question q)
        {
            Console.WriteLine($"Q: {q.Id} | Difficulty: {q.Difficulty} | Marks: {q.Marks} | Type: {q.TypeQuestion}");
            Console.WriteLine($"{q.Header}"); 
            Console.WriteLine($"{q.Body}"); 
            Console.WriteLine($"{q.GetOptions()}"); 
            Console.WriteLine($"Your Answer:{q.UserAnswer} \n"); 
        }

        // Method to print an answer
        private void PrintAnswer(Answer a)
        {
            Console.WriteLine($"Ans: {a.Id} | Difficulty: {a.Difficulty} | Marks: {a.Marks} | Type: {a.QuestionType}");
            Console.WriteLine($"Answer: {a.CorrectAnswer}\n"); 
        }

        // Display all exam questions
        public override void DisplayExamQuestions()
        {
            foreach (var item in examDictionary) // Iterate through all questions
            {
                PrintQuestion(item.Key); // Print each question
            }
            Console.WriteLine(new string('-', 50)); // Divider for readability
        }

        // Display all exam answers
        public override void DisplayExamAnswers()
        {
            foreach (var item in examDictionary) // Iterate through all answers
            {
                PrintAnswer(item.Value); // Print each answer
            }
            Console.WriteLine(new string('-', 50)); // Divider for readability
        }
     
        // Run the final exam process
        public  void RunExam1(List<Question>qlist,List<Answer>alist)
        {
            Console.WriteLine("Welcome to the Final Exam! Good luck!");
            Console.WriteLine("Instructions: Answer the following questions carefully.");
            Console.WriteLine("------------------------------------------------------------");
            SetQuestions(qlist);
            SetAnswers(alist);
            Number_of_questions = questionsList.Count;
            Total_marks_Exam = GetTotalMarksExam();
            Display(); // Display the exam details
            LinkQuestionListToAnswerList(); 
            DisplayExamQuestions(); 
            DisplayExamAnswers();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("=========================================");
            Console.WriteLine("Thank you for taking the final exam!");
            Console.WriteLine("=========================================");
            Console.ResetColor();
        }

        public override ExamFinal Clone()
        {
            return new ExamFinal(this.Exam_id, this.Total_marks_Exam, this.Subject);
        }
    }
}
