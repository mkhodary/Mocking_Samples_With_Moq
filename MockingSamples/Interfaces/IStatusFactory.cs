using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MockingSamples
{
    public interface IStatusFactory
    {
        CustomerStatusEnum From(CustomerCreateCommand createCommand);
    }

    public enum CustomerStatusEnum
    {
        Normal,
        Platinum
    }
}
