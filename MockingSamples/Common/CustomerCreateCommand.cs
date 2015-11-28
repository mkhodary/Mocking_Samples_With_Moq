using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MockingSamples
{
    public class CustomerCreateCommand
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MailingAddress { get; set; }
    }
}
