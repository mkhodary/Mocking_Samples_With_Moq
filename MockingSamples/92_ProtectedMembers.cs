using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockingSamples
{
    public class CustomerNameFormatter
    {
        public string From(Customer customer)
        {
            string firstName = RemoveUnderScoreFrom(customer.FirstName);
            string lastName = RemoveUnderScoreFrom(customer.LastName);

            return string.Format("{0} {1}", customer.FirstName, customer.LastName);
        }

        protected virtual string RemoveUnderScoreFrom(string p)
        {
            return p.Replace("_", string.Empty);
        }
    }
}
