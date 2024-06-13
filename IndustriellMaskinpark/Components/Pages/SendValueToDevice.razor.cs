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

        [Inject]
		public NavigationManager NavigationManager { get; set; }

		private DeviceSensorReading newReading = new DeviceSensorReading();

		protected bool IsSaved =false;
		protected string Message = string.Empty;
		protected string StatusClass = string.Empty;

		private async Task AddSensorValueReading()
        {
            IsSaved = true;
            Message = "You sucessfully added value to device";
            StatusClass = "alert-success";
            newReading.DeviceId = DeviceId;
            newReading.TimeStamp = DateTime.Now;
            await DeviceReadingsRepository.AddDeviceValue(newReading);
        }

		protected void NavigateToOverview()
		{
			NavigationManager.NavigateTo("/deviceoverview");
		}

		protected void NavigateToSensorValues(int id)
		{
			NavigationManager.NavigateTo($"/devicesensorvalues/{id}");
		}
	}
}
