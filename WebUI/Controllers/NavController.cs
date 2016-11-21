using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class NavController : Controller
    {
        private IDeviceRepository repository;

        public NavController(IDeviceRepository repo)
        {
            repository = repo;
        }
        
        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;

            IEnumerable<string> categorys = repository.Devices
                .Select(device => device.Category)
                .Distinct()
                .OrderBy(x => x);

            return PartialView(categorys);
        }
    }
}