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

        public async Task DeleteDevice(int id)
        {
            var foundDevice = await _context.Devices.FirstOrDefaultAsync(d => d.Id == id);
            if (foundDevice == null)
            {
                return;
            }

            _context.Devices.Remove(foundDevice);
            await _context.SaveChangesAsync();
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

		public async Task<int> GetTotalDevicesCount()
		{
			return await _context.Devices.CountAsync();
		}

		public async Task<int> GetTotalOnlineDevicesCount()
		{
			return await _context.Devices.Where(d => d.Status == true).CountAsync();
		}

		public async Task<int> GetDevicesAddedTodayCount()
		{
			DateTime today = DateTime.Today;
			return await _context.Devices.Where(d => d.Date.Date == today).CountAsync();
		}

	}
}
