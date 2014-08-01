using PagedList;
using Rental.WebUI.ViewModels.Advert;

namespace Rental.WebUI.ViewModels.Home
{
    public class ListViewModel
    {
        public IPagedList<AdvertViewModel> AdvertPagedList { get; set; }
        public FilterViewModel CurrentFilter { get; set; }
    }
}