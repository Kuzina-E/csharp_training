using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
    [Table(Name = "addressbook")]
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmails;

        public ContactData()
        {

        }

        public ContactData(string firstname, string lastname)
        {
            FirstName = firstname;
            LastName = lastname;
        }


        [Column(Name = "id"), PrimaryKey]
        public object Id { get; set; }
        [Column(Name = "firstname")]
        public string FirstName { get; set; }
        [Column(Name = "lastname")]
        public string LastName { get; set; }
        [Column(Name = "address")]
        public string Address { get; set; }
        [Column(Name = "home")]
        public string HomePhone { get; set; }
        [Column(Name = "mobile")]
        public string MobilePhone { get; set; }
        [Column(Name = "work")]
        public string WorkPhone { get; set; }
        [Column(Name = "email")]
        public string Email_1 { get; set; }
        [Column(Name = "email2")]
        public string Email_2 { get; set; }
        [Column(Name = "email3")]
        public string Email_3 { get; set; }
        [Column(Name = "deprecated")]
        public string Deprecated { get; set; }


        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
                }

            }
            set
            {
                allPhones = value;
            }
        }

        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (ClenupEmail(Email_1) + ClenupEmail(Email_2) + ClenupEmail(Email_3)).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }
    


    private string CleanUp(string phone)
    {
        if (phone == null || phone == "")
        {
            return "";
        }

        return Regex.Replace(phone, "[-() ]", "") + "\n";
        // phone.Replace(" ","").Replace("-","").Replace("(","").Replace(")","") + "\r\n";
    }

    private string ClenupEmail(string email)
    {
        if (email == null || email == "")
        {
            return "";
        }
        return Regex.Replace(email, "[ -()]", "") + "\n";
    }

    public bool Equals(ContactData other)
    {
        if (Object.ReferenceEquals(other, null))
        {
            return false;
        }
        if (Object.ReferenceEquals(this, other))
        {
            return true;

        }
        return FirstName == other.FirstName && LastName == other.LastName;
    }

    public override int GetHashCode()
    {
        return (FirstName + LastName).GetHashCode();

    }
    public override string ToString()
    {
        return "firstname=" + FirstName + "\nlastname=" + LastName;
    }

    public int CompareTo(ContactData other)
    {
        if (Object.ReferenceEquals(other, null))
        {
            return 1;
        }
        if (LastName.CompareTo(other.LastName) != 0)
        {
            return LastName.CompareTo(other.LastName);
        }
        return FirstName.CompareTo(other.FirstName);
    }

    public List<ContactData> GetAll()
    {
        using (AddressbookDB db = new AddressbookDB())
        {
            return (from c in db.Contacts.Where(x => x.Deprecated == "0000-00-00 00:00:00") select c).ToList();
        }
    }

    public List<GroupData> GetGroups()
    {
        using (AddressbookDB db = new AddressbookDB())
        {
            return (from g in db.Groups
                    from gcr in db.GCR.Where(p => p.ContactId == Id && p.GroupId == g.Id)
                    select g).Distinct().ToList();
        }
    }
}

    
}
