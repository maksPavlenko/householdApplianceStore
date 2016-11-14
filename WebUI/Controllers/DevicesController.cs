using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class DevicesController : Controller
    {
       // конструктор который объявляет зависимость от IDeviceRepository
        private IDeviceRepository repository;
        public DevicesController(IDeviceRepository repo)
        {
            repository = repo;
        }
        // Метод list визуализирует представление отобажающее полный список товаров
        public ViewResult List()
        {
            //снабжаем инфраструктуру данными 
            return View(repository.Devices);
        }
    }
}