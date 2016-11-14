using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Abstract;
using Moq;
using System.Collections.Generic;
using Domain.Entities;
using WebUI.Controllers;
using System.Linq;
using System.Web.WebPages.Html;
using WebUI.Models;
using System.Web.Mvc;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Can_Paginate() //тест разбиения на страницы
        {
            Mock<IDeviceRepository> mock = new Mock<IDeviceRepository>();
            mock.Setup(m => m.Devices).Returns(new List<Device> 
            {
                new Device {DeviceId = 1, Name = "device1"},
                new Device {DeviceId = 2, Name = "device2"},
                new Device {DeviceId = 3, Name = "device3"},
                new Device {DeviceId = 4, Name = "device4"},
                new Device {DeviceId = 5, Name = "device5"}
            });

            DevicesController controller = new DevicesController(mock.Object);
            controller.pageSize = 3;

            IEnumerable<Device> result = (IEnumerable<Device>)controller.List(2).Model;

            List<Device> devices = result.ToList();
            Assert.IsTrue(devices.Count == 2);
            Assert.AreEqual(devices[0].Name, "device4");
            Assert.AreEqual(devices[1].Name, "device5");
        }
    }
}
