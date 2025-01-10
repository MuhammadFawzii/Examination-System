using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class Subject
    {
        private string? subject_code;
        private string? subject_name;
        public string Subject_code 
        {
            get => subject_code;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("Subject code cannot be null or whitespace.");
                    return;
                }
                subject_code = value;
            }
        }
        public string Subject_name 
        {
            get => subject_name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("Subject name cannot be null or whitespace.");
                    return;
                }
                subject_name = value;
            }
        }
        public Subject(string subject_code, string subject_name)
        {
            this.Subject_code = subject_code;
            this.Subject_name = subject_name;
        }


        public override string ToString()
        {
            return $"Subject Code: {Subject_code}, Subject Name: {Subject_name}";
        }
        public override bool Equals(object? obj)
        {
            if (obj == null||!(obj is Subject))
            {
                return false;
            }
            Subject other = (Subject)obj;
            return this.Subject_code == other.Subject_code&& this.Subject_name == other.Subject_name;
        }

        public override int GetHashCode()
        {
            int prime = 7;
            int result = 1;
            result =prime *result +((Subject_code ==null)?0 : Subject_code.GetHashCode());
            result = prime * result + ((Subject_name == null) ? 0 : Subject_name.GetHashCode());
            return result;

        }

    }
}
