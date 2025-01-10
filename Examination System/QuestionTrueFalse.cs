using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class QuestionTrueFalse:Question
    {
        public QuestionTrueFalse(int _id ,string _header, string _body,string[] _options, double _marks, LDifficulty _difficulty,TypeQuestion _type, string _userAnswer)
            : base( _id ,_header, _body, _options, _marks, _difficulty,_type,_userAnswer)
        {
            Options = new string[] { "True", "False" };

        }
        public QuestionTrueFalse(int _id, string _header, string _body,string[]_options, double _marks, LDifficulty _difficulty, TypeQuestion _type)
           : base(_id, _header, _body,_options, _marks, _difficulty, _type)
        {
            Options = new string[] { "True", "False" };

        }
        public override string GetOptions()
        {
            string options = "";
            foreach (string option in Options)
            {
                options += option + "\t";
            }
            return options;
        }
        public override void ViewQuestion()
        {
            Console.WriteLine($"Q: {Id} | Difficulty: {Difficulty} | Marks: {Marks} | Type: {TypeQuestion}");
            Console.WriteLine($"{Header}");
            Console.WriteLine($"{Body}");
            Console.WriteLine($"{GetOptions()}");
            Console.Write($"Your Answer:");
            string userAnswer = Console.ReadLine().ToUpper();
            while (!(userAnswer == "TRUE" || userAnswer == "FALSE" ))
            {
                Console.WriteLine("Please enter a valid answer (True or False):");
                userAnswer = Console.ReadLine().ToUpper();
            }
            UserAnswer = userAnswer.ToUpper();
            Console.WriteLine(new string('-', 50)); // Divider for clarity
        }
       

        public override string ToString()
        {
            return $"ID: {Id}\nHeader: {Header}\nBody: {Body}\nOptions: {GetOptions()}\nMarks: {Marks}\nDifficulty: {Difficulty}\nType: {TypeQuestion}\nUser Answer: {UserAnswer}";

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
            return new QuestionTrueFalse(Id, Header, Body, Options, Marks, Difficulty, TypeQuestion, UserAnswer);
        }
    }
}
