using IndustriellMaskinpark.Entities;
using IndustriellMaskinpark.Repositories;
using Microsoft.AspNetCore.Components;

namespace IndustriellMaskinpark.Components.Pages
{
    public partial class DeviceAdd
    {
        [SupplyParameterFromForm]
        public Device Device { get; set; }

        [Inject]
        public IDeviceRepository DeviceRepository { get; set; }
        protected string Message = string.Empty;
        protected bool IsSaved = false;

        protected override void OnInitialized()
        {
            Device ??= new();
        }

        private async Task OnSumbit()
        {
            Device.Date = DateTime.Now;
            await DeviceRepository.AddDevice(Device);
            IsSaved = true;
            Message = "Device Added successfully!";
        }


    }
}
