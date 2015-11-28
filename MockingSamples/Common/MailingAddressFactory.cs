using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MockingSamples
{
    public class MailingAddress
    {
        public int StreetNumber { get; set; }
        public string Street { get; set; }
    }

    public class MailingAddressFactory : IMailingAddressFactory
    {
        public bool TryParse(string mailingAddress, out MailingAddress result)
        {
            result = null;

            try
            {
                if (string.IsNullOrEmpty(mailingAddress))
                    return false;

                string[] addressArray = mailingAddress.Split(',');
                if (addressArray == null || addressArray.Length < 2)
                    return false;

                result = new MailingAddress() { StreetNumber = int.Parse(addressArray[0]), Street = addressArray[1] };
                return true;
            }
            catch
            {
                return false;
            }
        }


        public ICustomerAddressBuilder GetAddressBuilder(bool isForCustomer)
        {
            throw new NotImplementedException();
        }
    }
}
