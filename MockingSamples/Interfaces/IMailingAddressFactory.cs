using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MockingSamples
{
    public interface IMailingAddressFactory
    {
        bool TryParse(string mailingAddress, out MailingAddress result);

        ICustomerAddressBuilder GetAddressBuilder(bool isForCustomer);
    }
}
