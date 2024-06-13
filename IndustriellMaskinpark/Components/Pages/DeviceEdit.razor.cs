using IndustriellMaskinpark.Entities;
using IndustriellMaskinpark.Repositories;
using Microsoft.AspNetCore.Components;

namespace IndustriellMaskinpark.Components.Pages
{
    public partial class DeviceEdit
    {
        [Inject]
        public IDeviceRepository DeviceRepository { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public int DeviceId { get; set; }

        [SupplyParameterFromForm]
        public Device Device { get; set; } = new();

        protected bool IsSaved;
        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            IsSaved = false;
            Device = await DeviceRepository.GetDeviceById(DeviceId);
        }

        protected async Task HandleValidSubmit()
        {
            await DeviceRepository.UpdateDevice(Device);
            IsSaved = true;
            StatusClass = "alert-success";
            Message = "Employee updated successfully.";
        }
        protected void HandleÏnvalidSubmit()
        {
            StatusClass = "alert-danger";
            Message = "There is some validation errors. Please try again.";
        }
        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/deviceoverview");
        }


    }
}
