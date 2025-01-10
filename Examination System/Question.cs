using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    public enum LDifficulty
    {
        Easy,
        Medium,
        Hard
    }
    public enum TypeQuestion
    {
        none,
        TF,
        ChooseOne,
        ChooseAll
    }

    internal abstract class Question:ICloneable, IComparable<Question>
    {
        private TypeQuestion type;
        private int id;
        private string? header;
        private string? body;
        private double marks;
        private LDifficulty difficulty;
        private string userAnswer="";
        private string[] options;


        public string? Header
        {
            get { return header; }
            set { header = value; }
        }
        public string? Body
        {
            get { return body; }
            set { body = value; }
        }
        public double Marks
        {
            get
            {
                return marks;
            }
            set { marks = value; }
        }
        public string[] Options { get => options; set => options = value; }

        public LDifficulty Difficulty { get => difficulty; set => difficulty = value; }
        public int Id { get => id; set => id = value; }
        public TypeQuestion TypeQuestion { get => type; set => type = value; }
        public string? UserAnswer { get => userAnswer; set => userAnswer = value; }

        public Question()
        {
            id = 0;
            header = "No Question";
            body = "No Question";
            options= new string[] { };
            marks = 0;
            difficulty = LDifficulty.Easy;
            type = TypeQuestion.none;
            userAnswer = "No User Answer";

        }
        public Question(int _id, string? _header, string? _body, string[] _options, double _marks, LDifficulty _difficulty, TypeQuestion _type)
        {
            Id = _id;
            Header = _header ?? "Default Header";
            Body = _body ?? "Default Body";
            Options = _options;
            Marks = _marks;
            Difficulty = _difficulty;
            TypeQuestion = _type;
        }
        public Question(int _id, string? _header, string? _body,string [] _options, double _marks, LDifficulty _difficulty, TypeQuestion _type,string _userAnswer)
        {
            Id = _id;
            Header = _header ?? "Default Header";
            Body = _body ?? "Default Body";
            Options = _options;
            Marks = _marks;
            Difficulty = _difficulty;
            TypeQuestion = _type;
            UserAnswer = _userAnswer;
        }
        public override string ToString()
        {
            return
                    $"Q{Id}:\n" +
                    $"{Header ?? ""}\n\n" + // If header is null, provide a default message
                    $"{Body ?? "No Body Provided"}\n\n" +    // If body is null, provide a default message
                    $"Marks: {Marks} marks\n" +
                    $"Difficulty: {Difficulty}\n" +
                    $"Question Type: {TypeQuestion}\n"+
                    $"User Answer: {UserAnswer}\n";
        }
        public abstract void ViewQuestion();
        
        public abstract string GetOptions();
        public virtual void Display()
        {
            Console.WriteLine(this.ToString());
            Console.WriteLine("-----------------------------------------");

        }
        public override bool Equals(object? obj)
        {
            if (obj is null || !(obj is Question))
            {
                return false;
            }
            Question question = (Question)obj;
            return id.Equals(question.Id) && header == question.Header && body == question.Body &&
                   marks == question.Marks && difficulty.Equals(question.Difficulty) && type.Equals(question.TypeQuestion);
        }

        public override int GetHashCode()
        {
            int hash = 31;
            int result = 1;
            result = hash * result + id.GetHashCode();
            result = hash * result + header?.GetHashCode() ?? 0;  // Null-safe handling
            result = hash * result + body?.GetHashCode() ?? 0; // Null-safe handling
            result = hash * result + marks.GetHashCode();
            result = hash * result + difficulty.GetHashCode();
            result = hash * result + type.GetHashCode();
            result = hash * result + userAnswer.GetHashCode();
            return result;

        }

        public abstract object Clone();

        public int CompareTo(Question? other)
        {
            if (other == null) return 1;
            return this.Id.CompareTo(other.Id);
        }
    }
}
