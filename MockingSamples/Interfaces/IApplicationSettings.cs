using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockingSamples
{
    public interface IApplicationSettings
    {
        int WorkStationId { get; set; }

        ISystemConfiguration SystemConfiguration { get; }
    }

    public interface ISystemConfiguration
    {
        IAuditingInformation AuditingInformation { get; }
    }

    public interface IAuditingInformation
    {
        int? WorkStationId { get; }
    }
}
