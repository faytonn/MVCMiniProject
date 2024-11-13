namespace BusinessLogicLayer.ViewModels.Common
{
    public class TPageableViewModel<T> : PageableViewModel
    {
        public List<T> Items { get; set; }

        public TPageableViewModel()
        {
            Items = new List<T>();
        }
    }
}
