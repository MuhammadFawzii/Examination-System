using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class QuestionChooseOne : Question
    {
        public QuestionChooseOne(int _id, string? _header, string? _body, string[] _options, double _marks, LDifficulty _difficulty, TypeQuestion _type) : base(_id, _header, _body,_options, _marks, _difficulty, _type)
        {
            Options = new string[] { "A", "B", "C", "D" };
            Options = _options;
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
        public override void ViewQuestion()
        {
            Console.WriteLine($"Q: {Id} | Difficulty: {Difficulty} | Marks: {Marks} | Type: {TypeQuestion}");
            Console.WriteLine($"{Header}");
            Console.WriteLine($"{Body}");
            Console.WriteLine($"{GetOptions()}");
            Console.WriteLine("Enter your answer (A, B, C, or D):");
            Console.Write($"Your Answer:");
            string userAnswer = Console.ReadLine().ToUpper();
            while (!(userAnswer == "A" || userAnswer == "B" || userAnswer == "C" || userAnswer == "D"))
            {
                Console.WriteLine("Please enter a valid answer (A, B, C, or D):");
                userAnswer = Console.ReadLine().ToUpper();
            }
            UserAnswer =userAnswer ;
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

        public override object Clone()
        {
            return new QuestionChooseOne(Id, Header, Body, Options, Marks, Difficulty, TypeQuestion);
        }
    }
}
