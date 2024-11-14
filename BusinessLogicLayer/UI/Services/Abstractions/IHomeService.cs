using MVCMiniProject.Views.ViewModels;

namespace BusinessLogicLayer.UI.Services.Abstractions
{
    public interface IHomeService
    {
        Task<HomeViewModel> GetHomeViewModel();
    }
}


//viewMdels ve dtos ferqi nedi
//dtolari entityler uzre qurdum viewmodel ise bilmedim nece meselen homedto edim dedim viewmodel :D tamam