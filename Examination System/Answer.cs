using System;

namespace Examination_System
{
    internal class Answer:IComparable<Answer>
    {
        private int id;
        private TypeQuestion questionType;
        private string? correctAnswer;
        private double marks;
        private bool isCorrect;
        private LDifficulty difficulty;

        public LDifficulty Difficulty { get => difficulty; set => difficulty = value; }
        public int Id { get => id; set => id = value; }
        public TypeQuestion QuestionType { get => questionType; set => questionType = value; }
        public string? CorrectAnswer { get => correctAnswer; set => correctAnswer = value; }
        public double Marks { get => marks; set => marks = value; }
        public bool IsCorrect { get => isCorrect; set => isCorrect = value; }

        // Default constructor
        public Answer()
        {
            Id = 0;
            QuestionType = TypeQuestion.none;
            CorrectAnswer = "No Answer";  // Default value
            Marks = 0;
            IsCorrect = false;
        }

        // Parameterized constructor
        public Answer(int _id, string _correctAnswer)
        {
            Id = _id;
            CorrectAnswer = _correctAnswer ?? "No Answer";  // Default if null
            
        }
        public Answer(int _id, TypeQuestion _questionType, LDifficulty _difficulty, string _answerText, string _userAnswer, double _marks, bool _isCorrect)
        {
            Id = _id;
            QuestionType = _questionType;
            Difficulty = _difficulty;
            CorrectAnswer = _answerText ?? "No Answer";  // Default if null
            Marks = _marks;
            IsCorrect = _isCorrect;
        }

        // Improved ToString() with null checks and formatted output
        public override string ToString()
        {
            return
                   $"Id: {Id}\n" + 
                   $"Correct Answer: {CorrectAnswer ?? "N/A"}\n" +   // If null, show "N/A"
                   $"Is Correct: {IsCorrect}\n" +
                   $"Marks: {Marks} marks\n" +
                   $"Difficulty: {Difficulty}\n"+
                   $"Question Type: {QuestionType}\n";
                   
        }

        // Display method that uses ToString() for formatted output
        public void Display()
        {
         
            if(IsCorrect)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(
                   $"Id: {Id} | Difficulty: {Difficulty} | Marks: {Marks} | Question Type: {QuestionType}\n" +
                   $"Correct Answer: {CorrectAnswer ?? "N/A"}\n" +   // If null, show "N/A"
                   $"Is Correct: {IsCorrect}\n" 
                   
                   );
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(
                   $"Id: {Id} | Difficulty: {Difficulty} | Marks: {Marks} | Question Type: {QuestionType}\n" +
                   $"Correct Answer: {CorrectAnswer ?? "N/A"}\n" +   // If null, show "N/A"
                   $"Is Correct: {IsCorrect}\n"

                   );
            }
            Console.ResetColor();
            
        }

        public int CompareTo(Answer? other)
        {
            if (other == null) return 1;
            return this.Id.CompareTo(other.Id);
        }
    }
}
