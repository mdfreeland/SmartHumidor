using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspnetCoreReactTemplate.Models;
using Microsoft.EntityFrameworkCore;

namespace aspnetCoreReactTemplate.Services
{
    public class HumidorEntityFrameworkDataService : IHumidorDataService
    {
        private readonly DefaultDbContext _dbContext;

        public HumidorEntityFrameworkDataService(DefaultDbContext dbContext) {
            _dbContext = dbContext;
        }

        public async Task<Humidor> GetHumidor(long humidorId)
        {
            return await _dbContext.Humidors
                                   .Include(humidor => humidor.Hygrometers)
                                   .SingleOrDefaultAsync(humidor => humidor.HumidorId == humidorId) ;
        }

        public async Task<IList<Humidor>> GetHumidors(string userId)
        {
            return await _dbContext.Humidors.Where(humidor => humidor.ApplicationUserId == userId).ToListAsync();
        }

        public async Task<Hygrometer> GetHygrometer(long hygrometerId)
        {
            return await _dbContext.Hygrometers.FindAsync(hygrometerId);
        }

        public async Task<IList<Hygrometer>> GetHygrometers(long humidorId)
        {
            return await _dbContext.Hygrometers.Where(hygrometer => hygrometer.HumidorId == humidorId).ToListAsync();
        }

        public async Task<long> SaveHumidor(Humidor humidor)
        {
            if (humidor.HumidorId == 0) _dbContext.Add(humidor);
            else _dbContext.Update(humidor);

            await _dbContext.SaveChangesAsync();

            return humidor.HumidorId;
        }

        public Task DeleteHumidor(long humidorId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<long> SaveHygrometer(Hygrometer hygrometer)
        {
            if (hygrometer.HygrometerId == 0) _dbContext.Add(hygrometer);
            else _dbContext.Update(hygrometer);

            await _dbContext.SaveChangesAsync();

            return hygrometer.HygrometerId;
        }

        public Task DeleteHygrometer(long hygrometerId)
        {
            throw new System.NotImplementedException();
        }
    }
}