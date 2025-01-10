using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class QuestionChooseAll:Question
    {
        public QuestionChooseAll(int _id, string? _header, string? _body, string[] _options, double _marks, LDifficulty _difficulty, TypeQuestion _type) : base(_id, _header, _body,_options, _marks, _difficulty, _type)
        {
            
        }

        public override string GetOptions()
        {
            string options = "";
            foreach (var item in Options)
            {
                options += item + "\n";

            }
            return options;
        }
        public override string ToString()
        {
            return $"ID: {Id}\nHeader: {Header}\nBody: {Body}\nOptions: {GetOptions()}\nMarks: {Marks}\nDifficulty: {Difficulty}\nType: {TypeQuestion}\nUser Answer: {UserAnswer}";

        }
        bool isCorrect = false;

        //need for editing
        public override void ViewQuestion()
        {
            Console.WriteLine($"Q: {Id} | Difficulty: {Difficulty} | Marks: {Marks} | Type: {TypeQuestion}");
            Console.WriteLine($"{Header}");
            Console.WriteLine($"{Body}");
            Console.WriteLine($"{GetOptions()}");
            Console.WriteLine("Please enter a valid answer (A, B, C, or D):");
            Console.Write($"Your Answer:");
            string userAnswer = Console.ReadLine();
            bool check= CheckOnValidAnswer(userAnswer);
            while (!check)
            {
                Console.WriteLine("Please enter a valid answer (A, B, C, or D):");
                userAnswer = Console.ReadLine();
                check = CheckOnValidAnswer(userAnswer);
            }
            userAnswer = new string(userAnswer.ToUpper()
                                          .Replace(" ", "")
                                          .Replace(",", "")
                                          .OrderBy(c => c)
                                          .ToArray());
            UserAnswer = userAnswer;
            Console.WriteLine(new string('-', 50)); // Divider for clarity
        }
        public override void Display()
        {
            Console.WriteLine($"Q: {Id} | Difficulty: {Difficulty} | Marks: {Marks} | Type: {TypeQuestion}");
            Console.WriteLine($"{Header}");
            Console.WriteLine($"{Body}");
            Console.WriteLine($"{GetOptions()}");
            Console.WriteLine($"Your Answer:{UserAnswer}");
            Console.WriteLine(new string('-', 50)); // Divider for clarity        }
        }
        public bool CheckOnValidAnswer(string userAnswer)
        {
            // Normalize user input
            userAnswer = new string(userAnswer.ToUpper()
                                           .Replace(" ", "")
                                           .Replace(",", "")
                                           .OrderBy(c => c)
                                           .ToArray());

            // Define possible options
            string[] possibleOptions = new string[]
            {
            "A", "B", "C", "D",
            "AB", "AC", "AD", "BC", "BD", "CD",
            "ABC", "ABD", "ACD", "BCD",
            "ABCD"
            };

            // Check if normalized user input matches any possible option
            if (possibleOptions.Contains(userAnswer))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override QuestionChooseAll Clone()
        {
            return new QuestionChooseAll(this.Id, this.Header, this.Body, this.Options, this.Marks, this.Difficulty, this.TypeQuestion);
        }
    }
}
