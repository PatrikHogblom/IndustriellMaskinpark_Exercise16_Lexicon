using IndustriellMaskinpark.Entities;
using IndustriellMaskinpark.Repositories;
using Microsoft.AspNetCore.Components;

namespace IndustriellMaskinpark.Components.Pages
{
    public partial class SendValueToDevice
    {
        [Parameter]
        public int DeviceId { get; set; }
        [Inject]
        public IDeviceReadingsRepository DeviceReadingsRepository { get; set; }

        private DeviceSensorReading newReading = new DeviceSensorReading();

        private async Task AddSensorValueReading()
        {
            newReading.DeviceId = DeviceId;
            newReading.TimeStamp = DateTime.Now;
            await DeviceReadingsRepository.AddDeviceValue(newReading);
        }
    }
}
