using System;
using System.Collections.Generic;
using System.Text;

namespace CarTryApplicationMVC.Application.ViewModels.Ad
{
    public class ListAdForListVm
    {
        public List<AdForListVm> Ads { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int Count { get; set; }
        public string CarBrandString { get;  set; }
        public string CarModelString { get;  set; }
        public string CarLocationString { get;  set; }
        public int CarProductionYearTo { get;  set; }
        public int CarProductionYearFrom { get;  set; }
        public string DriveTrainString { get;  set; }
        public string FuelTypeString { get;  set; }
        public int NumberOfCylindersStringTo { get;  set; }
        public int NumberOfCylindersStringFrom { get;  set; }
        public string CarTypeBodyString { get;  set; }
        public int OdometerValueStringTo { get;  set; }
        public int OdometerValueStringFrom { get;  set; }
    }
}
