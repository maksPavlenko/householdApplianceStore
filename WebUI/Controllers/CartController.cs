using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class CartController : Controller
    {
        private IDeviceRepository repository;
        public CartController(IDeviceRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index(Cart cart , string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart =  cart,
                ReturnUrl = returnUrl
                
            });
        }

        public RedirectToRouteResult AddToCart(Cart cart ,int deviceId, string returnUrl)
        {
            Device device = repository.Devices
                .FirstOrDefault(b => b.DeviceId == deviceId);

            if (device != null)
            {
                cart.RemoveLine(device, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int deviceId, string returnUrl)
        {
            Device device = repository.Devices
                .FirstOrDefault(b => b.DeviceId == deviceId);

            if (device != null)
            {
                cart.RemoveLine(device);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public PartialViewResult Summary (Cart cart)
        {
            return PartialView(cart);
        }
    }
}