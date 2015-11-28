using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MockingSamples
{
    public interface ICustomerRepository
    {
        void Save(Customer customer);

        void SaveSpecial(Customer customer);

        string TimeZone { get; set; }

        event EventHandler NotifySalesTeam;
    }
}
