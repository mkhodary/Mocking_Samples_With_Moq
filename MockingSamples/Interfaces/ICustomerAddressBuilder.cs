using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MockingSamples
{
    public interface ICustomerAddressBuilder
    {
        string From(CustomerCreateCommand customercommand);
    }
}
