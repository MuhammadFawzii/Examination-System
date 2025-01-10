using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Examination_System
{
    public enum ExamMode { Starting, Queued, Finished }

    internal abstract  class Exam :ICloneable,IComparable
    {
        private int exam_id;
        private double time_exam;
        private int number_of_questions;
        private double total_marks_exam;
        private double total_marks_student;
        private Subject subject;
        protected List<Question> questionsList=new List<Question>();
        protected List<Answer> answersList=new List<Answer>();
        protected Dictionary<Question, Answer> examDictionary=new Dictionary<Question, Answer> ();

        public int Exam_id { get => exam_id; set => exam_id = value; }
        public double TimeExam { get => time_exam; set => time_exam = value; }
        public int Number_of_questions { get => number_of_questions; set => number_of_questions = value; }
        public double Total_marks_Exam { get => total_marks_exam; set => total_marks_exam = value; }
        internal Subject Subject { get => subject; set => subject = value; }
        public double Total_marks_student { get => total_marks_student; set => total_marks_student = value; }
        private ExamMode mode;
        public ExamMode Mode
        {
            get => mode;
            set
            {
                mode = value;
                if (mode == ExamMode.Starting)
                {
                    OnExamStarting?.Invoke($"Exam has started!");
                }
                else if (mode == ExamMode.Finished)
                {
                    OnExamStarting?.Invoke($"Exam has finished!");
                }
            }
        }
        public event Action<string> OnExamStarting;
        protected Exam(int exam_id, double time_exam,Subject subject)
        {
            this.exam_id = exam_id;
            this.time_exam = time_exam;
            this.subject = subject;
            Mode = ExamMode.Queued;

        }

        //method to get the all the questions in the exam
        public List<Question> GetQuestions()
        {
            return questionsList;
        }
        //method to get all the answers in the exam
        public List<Answer> GetAnswers()
        {
            return answersList;
        }
        //method to get the exam dictionary
        public Dictionary<Question, Answer> GetExamDictionary()
        {
            return examDictionary;
        }
        
      
        //method to set the exam Questions
        public void SetQuestions(List<Question> questions)
        {
            questionsList = questions;
            
        }
        
        //method to set the exam Answers
        public void SetAnswers(List<Answer> answers)
        {
            answersList = answers;
        }
        //method to set the exam dictionary
        public void SetExamDictionary(List<Question> qlist, List<Answer> alist)
        {
            questionsList.AddRange(qlist);
            answersList.AddRange(alist);
            questionsList.Sort();
            answersList.Sort();
            LinkQuestionListToAnswerList();
        }
        public void AddQuestion(Question q)
        {
            questionsList.Add(q);
        }
        public void RemoveQuestion(Question q)
        {
            questionsList.Remove(q);
        }
        public void UpdateQuestion(Question q)
        {
            int index = questionsList.IndexOf(q);
            questionsList[index] = q;
        }
        public void UpdateQuestionFromDic(Question oldQuestion, Question newQuestion)
        {
            // Update in questionsList
            int index = questionsList.IndexOf(oldQuestion);
            if (index != -1)
            {
                questionsList[index] = newQuestion;

                // Check if the old question exists in the dictionary
                if (examDictionary.ContainsKey(oldQuestion))
                {
                    // Get the associated answer
                    Answer answer = examDictionary[oldQuestion];

                    // Remove the old entry and add the new one
                    examDictionary.Remove(oldQuestion);
                    examDictionary.Add(newQuestion, answer);
                }
            }
            else
            {
                Console.WriteLine("Old question not found in the list.");
            }
        }

        public void AddAnswer(Answer a)
        {
            answersList.Add(a);
        }
        public void RemoveAnswer(Answer a)
        {
            answersList.Remove(a);
        }
        public void UpdateAnswer(Answer a)
        {
            int index = answersList.IndexOf(a);
            answersList[index] = a;
        }
        // Method to validate a single answer for a single question in the exam
        public void ValidateAnswerToQuestion(Question qes,Answer ans)
        {
            string _userAns =new string(qes.UserAnswer.ToUpper()
                                           .Replace(",", "")
                                           .OrderBy(c => c)
                                           .ToArray());
            string _correctAns = new string(ans.CorrectAnswer.ToUpper()
                                           .Replace(" ", "")
                                           .Replace(",", "")
                                           .OrderBy(c=>c)
                                           .ToArray());
            if (_correctAns.Equals(_userAns))
                ans.IsCorrect = true;
            else
                ans.IsCorrect = false;
        }
        public void ValidateAllAnswersToAllQuestion()
        {
            foreach (var item in examDictionary)
            {
                ValidateAnswerToQuestion(item.Key, item.Value);
            }
        }
        //_correctAns=A
        //method to get the total marks of the exam 
        public void CalculateTotalMarksStudent()
        {
            double total = 0;
            foreach (var item in examDictionary)
            {
                Answer ans= item.Value;
                bool check = ans.IsCorrect;
                if (check)
                    total += ans.Marks;
            }
            Total_marks_student = total;
        }
        //method to display the total marks of the student
        public void DisplayTotalMarksStudent()
        {
            Console.WriteLine("Total Marks: " + Total_marks_student);
        }

        public double GetTotalMarksExam()
        {
            double total = 0;
            foreach (var q in questionsList)
            {
                total+=q.Marks;
            }
            Total_marks_Exam = total;   
            return Total_marks_Exam;
        }
        //method to display the total marks of the exam
        public void DisplayTotalMarksExam()
        {
            Console.WriteLine("Total Marks: " + Total_marks_Exam);
        }
        //method to link a question to an answer in the exam
        public void LinKQuestionToAnswer(Question q, Answer a)
        {
            examDictionary.Add(q, a);
        }
        //method to link a list of questions to a list of answers in the exam
        //public void LinkQuestionListToAnswerList()
        //{
        //    for (int i = 0; i < questionsList.Count; i++)
        //    {

        //        Answer ans = answersList.Find(a => a.Id == questionsList[i].Id);
        //        if (ans == null)
        //        {
        //            throw new Exception("Answer not found for question number " + questionsList[i].Id);
        //        }
        //        else
        //        {
        //            ans.Difficulty = questionsList[i].Difficulty;
        //            ans.QuestionType = questionsList[i].TypeQuestion;
        //            ans.Marks = questionsList[i].Marks;

        //            examDictionary.Add(questionsList[i],ans);
        //        }

        //    }
        //}
        public void LinkQuestionListToAnswerList()
        {
            var answerLookup = answersList.ToDictionary(a => a.Id);

            foreach (var question in questionsList)
            {
                if (!answerLookup.TryGetValue(question.Id, out Answer ans))
                {
                    throw new Exception($"Answer not found for question number {question.Id}");
                }

                ans.Difficulty = question.Difficulty;
                ans.QuestionType = question.TypeQuestion;
                ans.Marks = question.Marks;

                if (examDictionary.ContainsKey(question))
                {
                    throw new Exception($"Duplicate question in exam dictionary: {question.Id}");
                }

                examDictionary.Add(question, ans);
            }
        }
        public void LinkQuestionListToAnswerList(List<Question> qlist, List<Answer> alist)
        {
            questionsList.AddRange(qlist);
            answersList.AddRange(alist);
            for (int i = 0; i < questionsList.Count; i++)
            {

                Answer ans = answersList.Find(a => a.Id == questionsList[i].Id);
                if (ans == null)
                {
                    throw new Exception("Answer not found for question number " + questionsList[i].Id);
                }
                else
                {
                    ans.Difficulty = questionsList[i].Difficulty;
                    ans.QuestionType = questionsList[i].TypeQuestion;
                    ans.Marks = questionsList[i].Marks;

                    examDictionary.Add(questionsList[i], ans);
                }

            }
        }


        //method to display the exam Questions
        public virtual void DisplayExamQuestions()
        {
            foreach (var item in examDictionary)
            {
                item.Key.Display();
            }
        }
        //method to display the exam answers
        public virtual void DisplayExamAnswers()
        {
            foreach (var item in examDictionary)
            {
                item.Value.Display();
            }
        }
        
        //To String method to display the exam details
        public override string ToString()
        {
            return $"Exam ID: {Exam_id}\nTime: {TimeExam} minutes\nNumber of Questions: {Number_of_questions}\nTotal Marks: {Total_marks_Exam}\nSubject: {Subject.Subject_name}";
        }
        //method to display the exam details
        public void Display()
        {
            Console.WriteLine(this.ToString());
          
            Console.WriteLine(new string('-', 100)+"\n"); // Divider for readability
        }
        public void CreatingExamIns(List<Question> qlist, List<Answer> alist, ExamType examType)
        {
       
            Console.WriteLine("Instructions: Answer the following questions carefully.");
            Console.WriteLine("------------------------------------------------------------");
            SetExamDictionary(qlist, alist);
            Number_of_questions = questionsList.Count;
            Total_marks_Exam = GetTotalMarksExam();
            if (examType == ExamType.ExamPractical)
            {
                Console.WriteLine("Creating the Practice Exam is Done!");
            }
            else
            {
                Console.WriteLine("Creating the Final Exam is Done!");
            }
        }
        public void GenerateExam()
        {
            Random random = new Random();
            foreach (Question q in questionsList)
            {
                Answer a = new Answer();
                a.Id = q.Id;
                a.QuestionType = q.TypeQuestion;
                a.Difficulty = q.Difficulty;
                a.CorrectAnswer = "Answer Text";
                a.Marks = random.Next(1, 11);
                a.IsCorrect = random.Next(0, 2) == 1;
                examDictionary.Add(q, a);
            }
        }

        public void Notify(string message)
        {
            Console.WriteLine($"Student received notification: {message}");
        }
        public int CompareTo(object? other)
        {
            if (other == null||!(other is Exam)) return 1;
            Exam otherExam = (Exam)other;
            return this.total_marks_exam.CompareTo(otherExam.Total_marks_Exam);
        }

        public abstract object Clone();
        public override bool Equals(object? obj) {
            if (obj == null||!(obj is Exam)) return false;
            Exam otherExam = (Exam)obj;
            return otherExam.Exam_id==this.Exam_id&&otherExam.Subject.Equals(this.Subject);
        }
    }
}
