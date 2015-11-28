using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MockingSamples
{
    public interface IFullNameFactory
    {
        string From(string firstName, string lastName);
    }
}
