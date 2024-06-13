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
        public Device Device { get; set; } = new Device();

        protected override async Task OnInitializedAsync()
        {
            Device = await DeviceRepository.GetDeviceById(DeviceId);
        }

    }
}
