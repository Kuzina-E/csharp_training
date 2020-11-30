using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using LinqToDB.Mapping;

namespace WebAddressbookTests
{
    [Table(Name = "group_list")]
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
    {
        private string name;
        private string heder= "";
        private string footer = "";

        public GroupData(string name)
        {
           Name = name;
        }
        public GroupData()
        {
          
        }

        [Column(Name ="group_name")]
        public string Name { get; set; }

        [Column(Name = "group_header")]
        public string Heder { get; set; }

        [Column(Name = "group_id"), PrimaryKey, Identity]
        public string Id { get; set; }

        [Column(Name = "group_footer")]
        public string Footer { get; set;}

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
            return "name=" + Name + "\nheader=" + Heder + "\nfooter=" + Footer;
        }

        public int CompareTo( GroupData other)
        {
            if (Object.ReferenceEquals(other,null))
            {
                return 1;
            }
            return Name.CompareTo(other.Name);
        }

        public List<GroupData> GetAll()
        {
            using (AddressbookDB db = new AddressbookDB())
            {
               return(from g in db.Groups select g).ToList();
            }


        }
        public List<ContactData> GetContacts()
        {
            using (AddressbookDB db = new AddressbookDB())
            {
                return (from c in db.Contacts
                        from gcr in db.GCR.Where(p => p.GroupId == Id && p.ContactId == c.Id
                        && c.Deprecated == "0000-00-00 00:00:00")
                        select c
                        ).Distinct().ToList();
            }
        }




    }
}
