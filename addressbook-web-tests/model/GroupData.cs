using System;
using System.Diagnostics.CodeAnalysis;

namespace WebAddressbookTests
{
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
    {
        private string name;
        private string heder= "";
        private string footer = "";

        public GroupData(string name)
        {
            this.name = name;
        }


        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public string Heder
        {
            get
            {
                return heder;
            }
            set
            {
                heder = value;
            }
        }

        public string Footer
        {
            get
            {
                return footer;
            }
            set
            {
                footer = value;
            }
        }

        public bool Equals([AllowNull] GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;

            }
            return Name == other.Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override string ToString()
        {
            return "name=" +Name;
        }

        public int CompareTo( GroupData other)
        {
            if (Object.ReferenceEquals(other,null))
            {
                return 1;
            }
            return Name.CompareTo(other.Name);
        }
    }
}
