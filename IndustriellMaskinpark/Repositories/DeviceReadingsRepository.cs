using IndustriellMaskinpark.Data;
using IndustriellMaskinpark.Entities;
using Microsoft.EntityFrameworkCore;

namespace IndustriellMaskinpark.Repositories
{
    public class DeviceReadingsRepository : IDeviceReadingsRepository
    {
        private readonly MaskinparkDbContext _context;

        public DeviceReadingsRepository(IDbContextFactory<MaskinparkDbContext>dbContextFactory)
        {
            _context = dbContextFactory.CreateDbContext();
        }

        public async Task<List<DeviceSensorReading>> GetDeviceSensorReadings(int deviceId)
        {
            return await _context.DeviceSensorReadings.Where(d => d.DeviceId == deviceId).OrderBy(t => t.TimeStamp).ToListAsync();
        }
    }
}
