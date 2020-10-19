using System;
namespace WebAddressbookTests
{
    public class GroupData
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
    }
}
