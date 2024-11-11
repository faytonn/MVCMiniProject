using MVCMiniProject.Views.ViewModels;

namespace BusinessLogicLayer.UI.Services.Abstractions
{
    public interface IHomeService
    {
        Task<HomeViewModel> GetHomeViewModel();
    }
}
