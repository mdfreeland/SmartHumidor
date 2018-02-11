using System.Collections.Generic;
using System.Threading.Tasks;
using aspnetCoreReactTemplate.Models;

namespace aspnetCoreReactTemplate.Services
{
    public interface ITelemetryDataService
    {
        Task<IList<TelemetryEvent>> GetTelemetryEvents(string deviceId, int days);
    }
}