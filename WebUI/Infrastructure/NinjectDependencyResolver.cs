using Domain.Abstract;
using Domain.Entities;
using Moq;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam){
            kernel = kernelParam;
            AddBindings();
        }

        private void AddBindings()
        {
            //Привязки
            Mock<IDeviceRepository> mock = new Mock<IDeviceRepository>();
            mock.Setup(m => m.Devices).Returns(new List<Device>
            {
                new Device {Name = "afdsafdas", Description = "sl;agln sfg ", Country = "askng ds", Price = 123},
                new Device {Name = "afdas", Description = "sl;sagtwwt  tww ert ", Country = "a ds", Price = 143},
                new Device {Name = "afdsafd re erwtas", Description = "ewrt erwtln sfg ", Country = "arewt ert ds", Price = 123}
            });
            kernel.Bind<IDeviceRepository>().ToConstant(mock.Object);
        }

        public object GetService(Type serviceType){
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices( Type serviceType){
            return kernel.GetAll(serviceType);
        }

    }
}