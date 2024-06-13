using IndustriellMaskinpark.Data;
using IndustriellMaskinpark.Entities;
using Microsoft.EntityFrameworkCore;

namespace IndustriellMaskinpark.Repositories
{
	public class DeviceRepository : IDeviceRepository, IDisposable
	{
		private readonly MaskinparkDbContext _context;
        public DeviceRepository(IDbContextFactory<MaskinparkDbContext> dbContextFactory)
        {
			_context = dbContextFactory.CreateDbContext();            
        }

        public async Task<Device> AddDevice(Device device)
        {
            var addedEntity = await _context.Devices.AddAsync(device);
            await _context.SaveChangesAsync();
            return addedEntity.Entity;
        }

        public void Dispose()
		{
			_context.Dispose();
		}

		public async Task<IEnumerable<Device>> GetAllDevices()
		{
			return await _context.Devices.ToListAsync();
		}

        public async Task<Device> GetDeviceById(int id)
        {
			return await _context.Devices.FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<Device> UpdateDevice(Device device)
        {
            var foundDevice = await _context.Devices.FirstOrDefaultAsync(d => d.Id == device.Id);

            if (foundDevice != null)
            {
                foundDevice.Id = device.Id;
                foundDevice.Location = device.Location;
                foundDevice.Date = device.Date;
                foundDevice.Type = device.Type;
                foundDevice.Status = device.Status;

                await _context.SaveChangesAsync();

                return foundDevice;
            }

            return null;
        }
    }
}
