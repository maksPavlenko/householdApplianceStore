using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstract
{
    public interface IDeviceRepository
    {
        //IEnumerable позволяет возвращать последовательность объектов Device, ничего не сообщаая как и где храняться данные.
        IEnumerable<Device> Devices { get; }

    }
}
