using IndustriellMaskinpark.Entities;
using IndustriellMaskinpark.Repositories;
using Microsoft.AspNetCore.Components;

namespace IndustriellMaskinpark.Components.Pages
{
    public partial class EditDeviceValues
    {
        [Inject]
        public IDeviceReadingsRepository DeviceReadingsRepository { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public int DeviceId { get; set; }

        [SupplyParameterFromForm]
        public DeviceSensorReading DeviceSensorReading { get; set; } = new();

        protected bool IsSaved;
        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            IsSaved = false;
            DeviceSensorReading = await DeviceReadingsRepository.GetDeviceSensorReadingById(DeviceId);
        }

        protected async Task HandleValidSubmit()
        {
            await DeviceReadingsRepository.UpdateDeviceSensorReading(DeviceSensorReading);
            IsSaved = true;
            StatusClass = "alert-success";
            Message = "Device sensor value updated successfully.";
        }
        protected void HandleÏnvalidSubmit()
        {
            StatusClass = "alert-danger";
            Message = "There is some validation errors. Please try again.";
        }
        protected void NavigateBackToSensorOverview(int id)
        {
            NavigationManager.NavigateTo($"/devicesensorvalues/{id}");
        }
    }
}
