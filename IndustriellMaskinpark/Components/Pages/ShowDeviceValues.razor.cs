using IndustriellMaskinpark.Entities;
using IndustriellMaskinpark.Repositories;
using Microsoft.AspNetCore.Components.QuickGrid;
using Microsoft.AspNetCore.Components;

namespace IndustriellMaskinpark.Components.Pages
{
    public partial class ShowDeviceValues
    {
        [Parameter]
        public int DeviceId { get; set; }

        [Inject]
        public IDeviceReadingsRepository? DeviceReadingsRepository { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; } // Inject NavigationManager


        public List<DeviceSensorReading> SensorReadings { get; set; } = [];
        protected IQueryable<DeviceSensorReading>? valuesQueryable;
        public PaginationState pagination = new() { ItemsPerPage = 10 };
        protected int queryableCount = 0;

        protected override async Task OnInitializedAsync()
        {
            //Device = await DeviceRepository.GetDeviceById(DeviceId);
            valuesQueryable = (await DeviceReadingsRepository.GetDeviceSensorReadings(DeviceId)).AsQueryable();
            queryableCount = valuesQueryable.Count();
        }

        private void AddSensorValueDevicePage(int id)
        {
            NavigationManager.NavigateTo($"/deviceaddvalue/{id}");
        }
    }
}
