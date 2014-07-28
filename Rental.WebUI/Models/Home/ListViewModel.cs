using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using Rental.WebUI.Models.Advert;

namespace Rental.WebUI.Models.Home
{
    public class ListViewModel
    {
        public IPagedList<AdvertViewModel> AdvertPagedList { get; set; }
        public FilterViewModel CurrentFilter { get; set; }
    }
}