using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MockingSamples
{
    public class Customer
    {

        public Customer(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string MailingAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName { get; set; }

        public MailingAddress DetailedMailingAddress { get; set; }

        public int Id { get; set; }

        public CustomerStatusEnum Status { get; set; }

        public int WorkStationId { get; set; }
    }
}
