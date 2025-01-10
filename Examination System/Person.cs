using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal abstract class Person: ICloneable, IComparable<Person>
    {
        private int _id;
        private string _name;

        public int Id
        {
            get => _id;
            set
            {
                if (value <= 0)
                {
                    Console.WriteLine("Id must be a positive number.");
                    return;
                }
                _id = value;
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("Name cannot be null, empty, or whitespace.");
                    return;
                }
                _name = value;
            }
        }

        public Person(int _id,string _name)
        {
            Id = _id;
            Name = _name;
           
        }
        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}";
        }

        public abstract object Clone();

        public int CompareTo(Person? other)
        {
            if (other == null)
            {
                return 1;
            }
            return this.Id.CompareTo(other.Id);

        }
    }
}
