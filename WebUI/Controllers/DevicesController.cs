﻿using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class DevicesController : Controller
    {
       // конструктор который объявляет зависимость от IDeviceRepository
        private IDeviceRepository repository;
        public int pageSize = 4; //кол-во товаров на одной странице


        public DevicesController(IDeviceRepository repo)
        {
            repository = repo;
        }
        // Метод list визуализирует представление отобажающее полный список товаров
        //При вызове метода без праметра будет отображаться 1 страница
        public ViewResult List(string category, int page = 1 )
        {
            DevicesListViewModel model = new DevicesListViewModel
            {
                Devices = repository.Devices
                .Where(b => category == null || b.Category == category)
                .OrderBy(device => device.DeviceId)
                .Skip((page - 1) * pageSize)
                .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = category == null ? 
                        repository.Devices.Count() : 
                        repository.Devices.Where(device => device.Category == category).Count()
                },
                CurrentCategory = category
            };

            //снабжаем инфраструктуру данными 
            return View(model);
        }
    }
}