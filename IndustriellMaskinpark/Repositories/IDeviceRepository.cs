using IndustriellMaskinpark.Entities;

namespace IndustriellMaskinpark.Repositories
{
	public interface IDeviceRepository
	{
		Task<IEnumerable<Device>> GetAllDevices();
		Task<Device> GetDeviceById(int id);
		Task<Device> AddDevice(Device device);
		Task<Device> UpdateDevice(Device device);
	}
}
