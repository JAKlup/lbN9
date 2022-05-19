using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace lbN9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding encoding = Encoding.GetEncoding(1251);
            string patch = @"C:\Users\JOKlup.DESKTOP-NDKP1MJ\source\repos\lbN9\lbN9\excelf.csv";
            var lines = File.ReadAllLines(patch, encoding);
            var Collection = new Collections[lines.Length - 1];
            for (int i = 1; i < lines.Length; i++)
            {
                var splits = lines[i].Split(';');
                var customer = new Collections();
                customer.Id = Convert.ToInt32(splits[0]);
                customer.Name = splits[1];
                customer.Phone = splits[3];
                customer.Email = splits[2];
                customer.Age = Convert.ToDouble(splits[4]);
                customer.City = splits[5];
                customer.Street = splits[6];
                customer.Tag = splits[7];
                customer.Price = Convert.ToInt32(splits[8]);
                customer.CustomerId = splits[9];
                customer.ProductId = splits[10];
                Collection[i - 1] = customer;
            }
            //EX.1
            Console.WriteLine($"Задание 1");
            int chel = 0;
            for (var i = 0; i < Collection.Length; i++)
            {
                int k = Collection.Count(s => s.Street == Collection[i].Street);
                if (k != 1)
                {
                    Console.WriteLine("Есть повторяющиеся улицы");
                    break;
                }
                chel++;
            }
            if (chel == Collection.Length) Console.WriteLine("Нет повторяющихся улиц");
            Console.WriteLine();
            //EX.2
            Console.WriteLine("Задание 2");
            var minprice = Collection.Min(x => x.Price);
            Console.WriteLine("минимальная цена :" + minprice);
            Console.WriteLine();
            //EX.3
            Console.WriteLine($"Задание 3");
            var Phone = from y in Collection
                        orderby y.Phone
                        select y;
            var Result1 = "Phone.csv";
            using (StreamWriter streamWriter = new StreamWriter(Result1, false, encoding))
            {
                streamWriter.WriteLine($"Id;Name;Email;Phone;Age;City;Street;Tag;Price;CustomerId;ProductId");
                foreach (var a in Phone)
                {
                    streamWriter.WriteLine(a.ToExcel());
                }
            }
            Console.WriteLine($"Заказы успешно отсортированы. Файл Эксель создан.");
            Console.WriteLine();
            //EX.4
            Console.WriteLine($"Задание 4:");
            var searchcity = from i in Collection
                            where i.City == "Курск" 
                            select i;
            var result = "city.csv";
            using (StreamWriter streamWriter = new StreamWriter(result, false, encoding)) 
            {
                streamWriter.WriteLine($"Id;Name;Email;Phone;Age;City;Street;Tag;Price;CustomerId;ProductId");

                foreach (var x in searchcity)
                {
                    streamWriter.WriteLine(x.ToExcel());
                }
            }
            Console.WriteLine($"Файл Эксель с пользователями,которые жиувт в городе Курск, создан и сохранен");
            Console.WriteLine();
            //EX.5
            Console.WriteLine($"Задание 5:");           
            char[] symbols = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };//из них будет сформированы CustomerID и ProductID
            string[] emails = { "gasdhjk@mail.ru", "hjhhgfdtf@gmail.com", "197hbty@mail.r", "yrtgh67@gmail.com", "opiktr5@yandex.ru", "ytb67jus@mail.ru", "uyfghj8917@mail.ru", "982hyjnbfx8@mail.ru", "yhhgftyh@mail.ru", "jnnnjnjn788@gmail.com", "ojggvv98654321@gmail.com", "yjbyhfge@mail.ru", "kraft678@gmail.com", "oiuyt567@mail.ru", "123kjhd@gmail.com", "oiuab78@mail.ru", "0912aslk0@gmail.com", "oiqwe78@gmail.com", "zmxncn@mail.ru", "erdnjgf@gmail.com", "34983498hjdddjj@gmail.com", "njcfcfj7878@gmail.com" };
            string[] names = { "Андрей Борисов", "Дмитрий Николаев", "Александр Романов", "Алена Соколова", "Оксана Наумцева", "Любовь Чепелина", "Дмитрий Ягудин", "Валентина Заворотнюк", "Ольга Борисова", "Алевтина Будько", "Валерия Белоусова", "Константин Гузеев", "Роза Сябитова", "Евгения Медведева", "Иван Иванов", "Андрей Петров", "Ксения Алексеева", "Надежда Петрова" };
            string[] cities = { "Подольск", "Обнинск", "Красноярск", "Брянск", "Киров", "Краснодар", "Астрахань", "Первомайск", "Питер", "СОчи", "Мурманск", "Красноярк", "Константинополь", "Муром", "Новосибирск" };
            string[] phones = { "(945)789-56-81", "(910)106-42-67", "(900)278-55-77", "(919)194-42-00", "(923)675-89-58", "(900)600-300-00", "(901)002-03-04", "(977)977-97-79", "(906)123-45-67", "(987)654-32-01", "(901)234-56-78", "(987)124-32-01" };
            string[] streets = { "Проспект Ленина", "Проспект маркса", "Белкинская улица", "Улица Маркса", "Улица Орджоникидзе", "центральная улица", "Школьная улица", "Улица Ленина", "Улица лесная", "Зеленая улица", "Улица Гагарина", "Улица Кирова", "Улица Партизан", "Улица Речная", "Улица Нагорная" };
            string[] tags = { "Сумка", "Плойка", "Постельное", "Нож", "Свитер", "Шоколад", "Диски", "Резина", "Диван", "Пудра", "Кроссовки", "Пижама", "Игрушка Олень", "Зубная щетка", "Ёж игрушечный", "Кофеварка", "Мармелад" };
            //для возраста можно сдеть отдельный массив, либо выбрать из промежутка число
            //string[] ages = { "16", "18", "17", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30" };
            var customId = new List<string>();
            var productID = new List<string>();
            Random random = new Random();
            for (int j = 0; j < 10; j++)
            {
                string str = "";
                for (int i = 0; i < 10; i++)
                {
                    var newstr = symbols[random.Next(0, symbols.Length)];
                    str += newstr;
                }
                customId.Add(str);
            }
            for (int g = 0; g < 10; g++)
            {
                string stri = "";
                for (int o = 0; o < 10; o++)
                {
                    var newstri = symbols[random.Next(0, symbols.Length)];
                    stri += newstri;
                }
                productID.Add(stri);
            }
            using (var writer = new StreamWriter(patch, true, encoding))

            {
                for (int l = Collection.Length + 1; l < Collection.Length + 5; l++)
                {
                    var NewRecord = new List<Collections>()
                    {
                      new Collections { Id = l, Name = names[random.Next(0, names.Length)], Email = emails[random.Next(0, emails.Length)], Phone = phones[random.Next(0, phones.Length)], Age = random.Next(16, 78), City = cities[random.Next(0, cities.Length)], Street = streets[random.Next(0, streets.Length)], Tag = tags[random.Next(0, tags.Length)], Price = random.Next(100, 50000), CustomerId = customId[random.Next(0, customId.Count)], ProductId = productID[random.Next(0, productID.Count)] }
                    };
                    foreach (var n in NewRecord)
                    {
                        writer.WriteLine(n.ToExcel());
                    }
                }
                Console.WriteLine($"Новые записи добавлены. ");
            }
        }
    }
}
