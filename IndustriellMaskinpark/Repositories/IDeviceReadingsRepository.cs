using IndustriellMaskinpark.Entities;

namespace IndustriellMaskinpark.Repositories
{
    public interface IDeviceReadingsRepository
    {
        Task<List<DeviceSensorReading>> GetDeviceSensorReadings(int deviceId);
        Task AddDeviceValue(DeviceSensorReading deviceSensorReading);
    }
}
