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

        protected bool IsDeleted = false;
        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;

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

        private void GoToSensorValueEditPage(int id)
        {
            NavigationManager.NavigateTo($"/devicesensoredit/{id}");
        }

        protected async Task DeleteValue(int id)
        {
            await DeviceReadingsRepository.DeleteSensorValue(id);
            StatusClass = "alert-success";
            Message = "Deleted successfully";
            IsDeleted = true;
            await LoadDevices(); // Refresh the devices list*/
        }

        private async Task LoadDevices()
        {
            SensorReadings = (await DeviceReadingsRepository.GetDeviceSensorReadings(DeviceId)).ToList();
            valuesQueryable = SensorReadings.AsQueryable();
        }
    }
}
