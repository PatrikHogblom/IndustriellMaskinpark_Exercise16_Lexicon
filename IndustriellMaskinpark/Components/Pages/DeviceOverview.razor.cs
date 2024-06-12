using IndustriellMaskinpark.Entities;
using IndustriellMaskinpark.Repositories;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.QuickGrid;

namespace IndustriellMaskinpark.Components.Pages
{
    public partial class DeviceOverview
    {
        public List<Device> Devices { get; set; }
		IQueryable<Device> devicesQueryable { get; set; }
		PaginationState pagination = new PaginationState { ItemsPerPage = 20 }; // Set the page size

		[Inject]
        public IDeviceRepository? DeviceRepository { get; set; }

		protected override async Task OnInitializedAsync()
		{
			Devices = (await DeviceRepository.GetAllDevices()).ToList();
			devicesQueryable = Devices.AsQueryable();
		}
	}
}
