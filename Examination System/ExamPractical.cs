using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class ExamPractical : Exam
    {
        public ExamPractical(int exam_id, double time_exam, Subject subject) : base(exam_id, time_exam, subject)
        {
            Mode = ExamMode.Queued;


        }

      
        //start the practice exam :
        public  void TakeAnsFromStudent()
        {
            foreach (Question q in questionsList)
            {
                q.ViewQuestion();
            }
           
        }
       
        public  void CreatingExamInsLL(List<Question>qlist,List<Answer>alist)
        {
            Console.WriteLine("Welcome to the Practice Exam! Good luck!");
            Console.WriteLine("Instructions: Answer the following questions carefully.");
            Console.WriteLine("------------------------------------------------------------");

            SetQuestions(qlist);
            SetAnswers(alist);
            Number_of_questions = questionsList.Count;
            Total_marks_Exam = GetTotalMarksExam();
            //Console.WriteLine("Question Number:"+ questionsList.Count);
            //Console.WriteLine("Total Mark :"+Total_marks_Exam);
            Display();//Display the exam details
            TakeAnsFromStudent();
            LinkQuestionListToAnswerList();
            ValidateAllAnswersToAllQuestion();
            DisplayExamAnswers();
            CalculateTotalMarksStudent();
            DisplayTotalMarksStudent();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("=========================================");
            Console.WriteLine("Thank you for taking the practice exam!");
            Console.WriteLine("=========================================");
            Console.ResetColor();

        }

        public override ExamPractical Clone()
        {
            return new ExamPractical(this.Exam_id, this.Total_marks_Exam,this.Subject);
        }
    }
}
