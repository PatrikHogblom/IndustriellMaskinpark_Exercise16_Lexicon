using IndustriellMaskinpark.Entities;

namespace IndustriellMaskinpark.Repositories
{
	public interface IDeviceRepository
	{
		Task<IEnumerable<Device>> GetAllDevices();
	}
}
