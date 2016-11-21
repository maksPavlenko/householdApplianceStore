using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class DevicesListViewModel
    {
        public IEnumerable<Device> Devices { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }//характеризует текущую выбранную категорию
    }
}