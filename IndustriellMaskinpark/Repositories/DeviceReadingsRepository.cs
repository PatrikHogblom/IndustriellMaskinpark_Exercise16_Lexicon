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

        public async Task AddDeviceValue(DeviceSensorReading deviceSensorReading)
        {
            _context.DeviceSensorReadings.Add(deviceSensorReading);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSensorValue(int Id)
        {
            var foundValue = await _context.DeviceSensorReadings.FirstOrDefaultAsync(d => d.Id == Id);
            if (foundValue == null)
            {
                return;
            }

            _context.DeviceSensorReadings.Remove(foundValue);
            await _context.SaveChangesAsync();
        }

        public async Task<DeviceSensorReading> GetDeviceSensorReadingById(int id)
        {
            return await _context.DeviceSensorReadings.FindAsync(id);
        }

        public async Task UpdateDeviceSensorReading(DeviceSensorReading sensorReading)
        {
            _context.DeviceSensorReadings.Update(sensorReading);
            await _context.SaveChangesAsync();
        }
    }
}
