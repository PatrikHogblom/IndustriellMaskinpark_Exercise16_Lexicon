using IndustriellMaskinpark.Entities;
using IndustriellMaskinpark.Repositories;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.QuickGrid;

namespace IndustriellMaskinpark.Components.Pages
{
    public partial class DeviceDetail
    {
        [Parameter]
        public int DeviceId { get; set; }

        [Inject]
        public IDeviceRepository? DeviceRepository { get; set; }

        [Inject]
        public IDeviceReadingsRepository? DeviceReadingsRepository { get; set; }

        public List<DeviceSensorReading> SensorReadings { get; set; } = [];

        public Device Device { get; set; } = new Device();
        protected IQueryable<DeviceSensorReading>? valuesQueryable;
        public PaginationState pagination = new() { ItemsPerPage = 10 };
        protected int queryableCount = 0;

        protected override async Task OnInitializedAsync()
        {
            Device = await DeviceRepository.GetDeviceById(DeviceId);
            valuesQueryable = (await DeviceReadingsRepository.GetDeviceSensorReadings(DeviceId)).AsQueryable();
            queryableCount = valuesQueryable.Count();
        }

    }
}
