using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lbN9
{
    class Collections
    {  
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public double Age { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Tag { get; set; }
        public int Price { get; set; }
        public string CustomerId { get; set; }
        public string ProductId { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}\n  Имя и фамилия: {Name}\n Электронный адрес : {Email}\n Номер телефона: {Phone}\n Возраст: {Age}\n Город: {City}\n Улица: {Street}\n Тэг:{Tag}\n Цена: {Price}\n Id покупателя: {CustomerId}\n Id товара: {ProductId}\n ";
        }
        public string ToExcel()
        {
            return $"{Id};{Name};{Email};{Phone};{Age};{City};{Street};{Tag};{Price};{CustomerId};{ProductId}";

        }

    }
}
