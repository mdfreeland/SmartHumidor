using System.Collections.Generic;
using System.Threading.Tasks;
using aspnetCoreReactTemplate.Models;

namespace aspnetCoreReactTemplate.Services
{
    public interface IHumidorDataService
    {
        Task<IList<Humidor>> GetHumidors(string userId);

        Task<Humidor> GetHumidor(long humidorId);

        Task<long> SaveHumidor(Humidor humidor);

        Task DeleteHumidor(long humidorId);

        Task<IList<Hygrometer>> GetHygrometers(long humidorId);

        Task<Hygrometer> GetHygrometer(long hygrometerId);

        Task<long> SaveHygrometer(Hygrometer hygrometer);

        Task DeleteHygrometer(long hygrometerId);
    }
}