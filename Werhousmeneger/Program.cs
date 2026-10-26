using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization.Formatters;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace Werhousmeneger
{
    public class Items
    {


        public int Id;
        public double Weight;
        public int Price;
        public string Destination;
        public Items(int id, double weight, int price, string destination)
        {
            Id = id;
            Weight = weight;
            Price = price;
            Destination = destination;
        }

        public virtual Dictionary<int, Dictionary<string, List<string>>> Save(int uniceID)
        {
            List<string> stringedData = new List<string>() { Convert.ToString(Id), Convert.ToString(Weight), Convert.ToString(Price), Destination };
            Dictionary<int,Dictionary<string, List<string>>>  saveble = new Dictionary<int, Dictionary<string, List<string>>>();
            saveble[uniceID].Add("Items", stringedData);
            return saveble;
        }
        public virtual void Print()
        {
            Console.WriteLine("Type: Item");
            Console.WriteLine($"     Id: {Id}");
            Console.WriteLine($"     Weight: {Weight}");
            Console.WriteLine($"     Price: {Price}");
            Console.WriteLine($"     Destination: {Destination}");
        }

    }
    public class Books : Items
    {
        public string Writer;
        public string Title;
        public int PageCount;
        public int ReleaseDate;
        public Books(string writer, string title, int pageCount, int releaseDate, int id, double weight, int price, string destination) : base(id, weight, price, destination)
        {
            
            Writer = writer;
            Title = title;
            PageCount = pageCount;
            ReleaseDate = releaseDate;
        }
        public override Dictionary<int, Dictionary<string, List<string>>> Save(int uniceID)
        {
            List<string> stringedData = new List<string>() { Convert.ToString(Id), Convert.ToString(Weight), Convert.ToString(Price), Destination, Writer, Title,Convert.ToString(PageCount), Convert.ToString(ReleaseDate)};
            Dictionary<int, Dictionary<string, List<string>>> saveble = new Dictionary<int, Dictionary<string, List<string>>>();
            saveble[uniceID].Add("Books", stringedData);
            return saveble;
        }
        public override void Print()
        {
            Console.WriteLine("Type: Book");
            Console.WriteLine($"     Id: {Id}");
            Console.WriteLine($"     Weight: {Weight}");
            Console.WriteLine($"     Price: {Price}");
            Console.WriteLine($"     Destination: {Destination}");
            Console.WriteLine($"     Writer: {Writer}");
            Console.WriteLine($"     Title: {Title}");
            Console.WriteLine($"     Pagecount: {PageCount}");
            Console.WriteLine($"     Release date: {ReleaseDate}");
        }
    }
    public class Electronics : Items
    {
        public string Name;
        public string Publisher;
        public string Type;
        public Electronics(string name, string publisher, string type, int id, double weight, int price, string destination) : base(id, weight, price, destination)
        {
            Name = name;
            Publisher = publisher;
            Type = type;
        }
        public override Dictionary<int, Dictionary<string, List<string>>> Save(int uniceID)
        {
            List<string> stringedData = new List<string>() { Convert.ToString(Id), Convert.ToString(Weight), Convert.ToString(Price), Destination, Name, Publisher, Type};
            Dictionary<int, Dictionary<string, List<string>>> saveble = new Dictionary<int, Dictionary<string, List<string>>>();
            saveble[uniceID].Add("Electronics", stringedData);
            return saveble;
        }
        public override void Print()
        {
            Console.WriteLine("Type: Electronic");
            Console.WriteLine($"     Id: {Id}");
            Console.WriteLine($"     Weight: {Weight}");
            Console.WriteLine($"     Price: {Price}");
            Console.WriteLine($"     Destination: {Destination}");
            Console.WriteLine($"     Name: {Name}");
            Console.WriteLine($"     Publisher: {Publisher}");
            Console.WriteLine($"     Type: {Type}");
        }
    }
    public class Furniture : Items
    {
        public string Type;
        public int Hight;
        public int With;
        public Furniture(string type, int hight, int with, int id, double weight, int price, string destination) : base(id, weight, price, destination)
        {
            Type = type;
            Hight = hight;
            With = with;
        }
        public override Dictionary<int, Dictionary<string, List<string>>> Save(int uniceID)
        {
            List<string> stringedData = new List<string>() { Convert.ToString(Id), Convert.ToString(Weight), Convert.ToString(Price), Destination, Type, Convert.ToString(Hight), Convert.ToString(With)};
            Dictionary<int, Dictionary<string, List<string>>> saveble = new Dictionary<int, Dictionary<string, List<string>>>();
            saveble[uniceID].Add("Furniture", stringedData);
            return saveble;
        }
        public override void Print()
        {
            Console.WriteLine("Type: Furniture");
            Console.WriteLine($"     Id: {Id}");
            Console.WriteLine($"     Weight: {Weight}");
            Console.WriteLine($"     Price: {Price}");
            Console.WriteLine($"     Destination: {Destination}");
            Console.WriteLine($"     Type: {Type}");
            Console.WriteLine($"     Hiht: {Hight}");
            Console.WriteLine($"     With: {With}");
        }
    }

    internal class Program
    {
        static void Save(List<Items> inventory)
        {

        }
        static List<Items> Load(string filname)
        {
            string json = File.ReadAllText(filname);

            Dictionary<int, Dictionary<string, List<string>>> data = JsonConvert.DeserializeObject<Dictionary<int, Dictionary<string, List<string>>>>(json);

            List<Items> inventory = new List<Items>();
            int index = 0;

            foreach (int id in data.Keys)
            {
                foreach (string k in data[id].Keys)
                {
                    switch (k)
                    {
                        case "Items":
                            {
                                inventory.Add(new Items(
                                    Convert.ToInt32(data[id][k][0]), Convert.ToDouble(data[id][k][1]), Convert.ToInt32(data[id][k][2]), data[id][k][3]
                                    ));
                                break;
                            }
                        case "Books":
                            {
                                inventory.Add(new Books(
                                    data[id][k][4], data[id][k][5], Convert.ToInt32(data[id][k][6]), Convert.ToInt32(data[id][k][7]), Convert.ToInt32(data[id][k][0]), Convert.ToDouble(data[id][k][1]), Convert.ToInt32(data[id][k][2]), data[id][k][3]
                                    ));
                                break;
                            }
                        case "Electronics":
                            {
                                inventory.Add(new Electronics(
                                    data[id][k][4], data[id][k][5], data[id][k][6], Convert.ToInt32(data[id][k][0]), Convert.ToDouble(data[id][k][1]), Convert.ToInt32(data[id][k][2]), data[id][k][3]
                                    ));
                                break;
                            }
                        case "Furniture":
                            {
                                inventory.Add(new Furniture(
                                    data[id][k][4], Convert.ToInt32(data[id][k][5]), Convert.ToInt32(data[id][k][6]), Convert.ToInt32(data[id][k][0]), Convert.ToDouble(data[id][k][1]), Convert.ToInt32(data[id][k][2]), data[id][k][3]
                                    ));
                                break;
                            }

                    }
                }
            }
            return inventory;
        }
        static int Menu()
        {
            Console.Clear();
            Console.WriteLine("========================");
            Console.WriteLine("1.) All items");
            Console.WriteLine("2.) Searches");
            Console.WriteLine("3.) Add item");
            Console.WriteLine("4.) Remuve item by id");
            Console.WriteLine("5.) Exit");
            Console.WriteLine("========================");
            Console.Write("Answer: ");
            int answer = Convert.ToInt32(Console.ReadLine());
            return answer;
        }
        static void Main(string[] args)
        {
            List<Items> inventory= Load("data.json");
            bool run = true;
            while (run)
            {
                try
                {
                   int answer = Menu();
                   switch (answer)
                    {
                        case 1:
                            {
                                Console.Clear();
                                foreach (var item in inventory)
                                {
                                    item.Print();
                                }
                                Console.ReadLine();
                                break;
                            }
                        case 2:
                            {
                                Console.Clear();
                                Console.WriteLine("========================");
                                Console.WriteLine("1) by id");
                                Console.WriteLine("2) by weight");
                                Console.WriteLine("3) by price");
                                Console.WriteLine("4) by destination");
                                Console.Write(">: ");
                                int v = Convert.ToInt32(Console.ReadLine());
                                switch(v)
                                {
                                    case 1:
                                        {
                                            Console.Write("Give the id: ");
                                            int id = Convert.ToInt32(Console.ReadLine());
                                            foreach (var item in inventory)
                                            {
                                                if (item.Id == id)
                                                {
                                                    item.Print();
                                                }
                                            }
                                            break;
                                        }
                                    case 2:
                                        {
                                            Console.Write("Give the weight: ");
                                            int weight = Convert.ToInt32(Console.ReadLine());
                                            foreach (var item in inventory)
                                            {
                                                if (item.Weight == weight)
                                                {
                                                    item.Print();
                                                }
                                            }
                                            break;
                                        }
                                    case 3:
                                        {
                                            Console.Write("Give the price: ");
                                            int price = Convert.ToInt32(Console.ReadLine());
                                            foreach (var item in inventory)
                                            {
                                                if (item.Price == price)
                                                {
                                                    item.Print();
                                                }
                                            }
                                            break;
                                        }
                                    case 4:
                                        {
                                            Console.Write("Give the destination: ");
                                            string destination = Console.ReadLine().ToLower();
                                            foreach (var item in inventory)
                                            {
                                                if (item.Destination.ToLower() == destination)
                                                {
                                                    item.Print();
                                                }
                                            }
                                            break;
                                        }
                                }
                                Console.ReadLine();
                                break;
                            }
                        case 3:
                            {
                                Console.Clear();
                                Console.WriteLine("========================");
                                Console.WriteLine("1.) Items");
                                Console.WriteLine("2.) Books");
                                Console.WriteLine("3.) Electronics");
                                Console.WriteLine("4.) Furniture");
                                Console.WriteLine();
                                Console.Write("Please give the typeof the item: ");
                                int type = Convert.ToInt16(Console.ReadLine());
                                switch (type)
                                {
                                    case 1:
                                        {
                                            Console.Write("Give the new item an id(int): ");
                                            int id = Convert.ToInt32(Console.ReadLine());
                                            Console.Write("Give the new item a weight(double): ");
                                            double weight = Convert.ToDouble(Console.ReadLine());
                                            Console.Write("Give the new item a price(int): ");
                                            int price = Convert.ToInt32(Console.ReadLine());
                                            Console.Write("Give the new item an destination(string): ");
                                            string destination = Console.ReadLine();
                                            inventory.Add(new Items(id, weight,price, destination));
                                            break;
                                        }
                                    case 2:
                                        {
                                            Console.Write("Give the new item an id(int): ");
                                            int id = Convert.ToInt32(Console.ReadLine());
                                            Console.Write("Give the new item a weight(double): ");
                                            double weight = Convert.ToDouble(Console.ReadLine());
                                            Console.Write("Give the new item a price(int): ");
                                            int price = Convert.ToInt32(Console.ReadLine());
                                            Console.Write("Give the new item a destination(string): ");
                                            string destination = Console.ReadLine();
                                            Console.Write("Give the new item a writer(string): ");
                                            string writer = Console.ReadLine();
                                            Console.Write("Give the new item a title(string): ");
                                            string title = Console.ReadLine();
                                            Console.Write("Give the new item a pageCount(int): ");
                                            int pageCount = Convert.ToInt32(Console.ReadLine());
                                            Console.Write("Give the new item a releaseDate(int): ");
                                            int releaseDate = Convert.ToInt32(Console.ReadLine());
                                            inventory.Add(new Books(writer,title,pageCount,releaseDate,id, weight, price, destination));
                                            break;
                                        }
                                    case 3:
                                        {
                                            Console.Write("Give the new item an id(int): ");
                                            int id = Convert.ToInt32(Console.ReadLine());
                                            Console.Write("Give the new item a weight(double): ");
                                            double weight = Convert.ToDouble(Console.ReadLine());
                                            Console.Write("Give the new item a price(int): ");
                                            int price = Convert.ToInt32(Console.ReadLine());
                                            Console.Write("Give the new item a destination(string): ");
                                            string destination = Console.ReadLine();
                                            Console.Write("Give the new item a name(string): ");
                                            string name = Console.ReadLine();
                                            Console.Write("Give the new item a publisher(string): ");
                                            string publisher = Console.ReadLine();
                                            Console.Write("Give the new item a type(string): ");
                                            string etype = Console.ReadLine();
                                            inventory.Add(new Electronics(name,publisher,etype,id, weight, price, destination));
                                            break;
                                        }
                                    case 4:
                                        {
                                            Console.Write("Give the new item an id(int): ");
                                            int id = Convert.ToInt32(Console.ReadLine());
                                            Console.Write("Give the new item a weight(double): ");
                                            double weight = Convert.ToDouble(Console.ReadLine());
                                            Console.Write("Give the new item a price(int): ");
                                            int price = Convert.ToInt32(Console.ReadLine());
                                            Console.Write("Give the new item a destination(string): ");
                                            string destination = Console.ReadLine();
                                            Console.Write("Give the new item a type(string): ");
                                            string ftype = Console.ReadLine();
                                            Console.Write("Give the new item a hight(int): ");
                                            int hight = Convert.ToInt32(Console.ReadLine());
                                            Console.Write("Give the new item a with(int): ");
                                            int with = Convert.ToInt32(Console.ReadLine());
                                            inventory.Add(new Furniture(ftype,hight ,with , id, weight, price, destination));
                                            break;
                                        }
                                }
                                Console.WriteLine("Successfuly added new item.");
                                Console.ReadLine();
                                break;
                            }
                        case 4:
                            {
                                Console.Clear();
                                Console.Write("Give the id you want to remuve: ");
                                int id = Convert.ToInt32(Console.ReadLine());
                                foreach (var item in inventory)
                                {
                                    if (item.Id == id)
                                    {
                                        item.Print();
                                        Console.WriteLine();
                                        Console.Write("Do you wnat to remove this item?(y/n): ");
                                        string choise = Console.ReadLine();
                                        if (choise.ToLower() == "y")
                                        {
                                            inventory.Remove(item);
                                            Console.WriteLine($"Remuved item with {id}");
                                            Console.ReadLine();
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Nothing");
                                            Console.ReadLine();
                                            break;
                                        }
                                    }
                                }
                                Console.WriteLine($"No item with {id}");
                                Console.ReadLine();
                                break;
                            }
                        case 5:
                            {
                                Console.WriteLine("Exiting.....");
                                Console.ReadLine();
                                run = false;
                                break;
                            }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Pleas try using int imput");
                }
            }
        }
    }
}
