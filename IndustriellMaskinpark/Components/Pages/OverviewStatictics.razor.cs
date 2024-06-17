
using IndustriellMaskinpark.Repositories;
using Microsoft.AspNetCore.Components;

namespace IndustriellMaskinpark.Components.Pages
{
	public partial class OverviewStatictics
	{
		[Inject]
		IDeviceRepository DeviceRepository { get; set; }

		int TotalDevicesCount { get; set; }
		int TotalDevicesOnline { get; set; }
		int TotalDevicesEditedAndAddedToday { get; set; }


        protected override async Task OnInitializedAsync()
        {
            await LoadStatistics();
        }

        public async Task LoadStatistics()
        {
            TotalDevicesCount = await DeviceRepository.GetTotalDevicesCount();
            TotalDevicesOnline = await DeviceRepository.GetTotalOnlineDevicesCount();
            TotalDevicesEditedAndAddedToday = await DeviceRepository.GetDevicesAddedTodayCount();
        }

        public async Task Refresh()
        {
            await LoadStatistics();
            await InvokeAsync(StateHasChanged);
        }
    }
}
