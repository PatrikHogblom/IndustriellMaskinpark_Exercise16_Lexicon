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
    }
}
