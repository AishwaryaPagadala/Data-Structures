using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSSCustomList
{
    public class Fruits : IComparable<Fruits>, IEquatable<Fruits>
    {
        //properties
        public string Name { get; set; }
        public int Weight { get; set; }

        //overriding compareTo method of IComparable interface
        public int CompareTo(Fruits inputObj)
        {
            if (inputObj == null)
                return 1;

            else
                return this.Weight.CompareTo(inputObj.Weight);
        }

        //overriding equals method of IEquatable interface
        public override bool Equals(object inputObj)
        {
            if (inputObj == null) return false;
            Fruits objAsPart = inputObj as Fruits;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }
        public bool Equals(Fruits inputObj)
        {
            if (inputObj == null) return false;
            return (this.Weight.Equals(inputObj.Weight));
        }
        // overriding GetHashCode method of IEquitable interface
        public override int GetHashCode()
        {
            return 0;
        }
        //returns string representation of object
        public override string ToString()
        {
            return (Name.ToString() + ": " + Weight.ToString());
        }
    }
}
