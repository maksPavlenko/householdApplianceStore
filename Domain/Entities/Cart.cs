using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        //свойствопозволяющее обратится к содержимому корзины 
        public IEnumerable<CartLine> Lines { get { return lineCollection; } }

        //метод добавдения товара в корзину
        public void RemoveLine(Device device, int quantity)
        {
            CartLine line = lineCollection
                .Where(b => b.Device.DeviceId == device.DeviceId)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartLine { Device = device, Quantity = quantity });
            }
            else
            {
                line.Quantity += quantity;
            }
        }
        //метод удаления товара из карзины
        public void RemoveLine(Device device)
        {
            lineCollection.RemoveAll(l => l.Device.DeviceId == device.DeviceId);
        }
        //метод вычисления общей стоимости товаров в корзине
        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Device.Price * e.Quantity);
        }
        //метод очистки корзины путем удаления всех элементов
        public void Clear()
        {
            lineCollection.Clear();
        }
    }

    //Представление еденицы товара
    public class CartLine
    {
        public Device Device { get; set; }
        public int Quantity { get; set; }
    }
}
