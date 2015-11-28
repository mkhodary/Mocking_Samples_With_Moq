using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MockingSamples
{
    public interface IMailingRepository
    {
        void NewCustomerMessage(object sender);
    }
}
