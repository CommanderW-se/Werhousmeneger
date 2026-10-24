using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        public virtual Dictionary<string, List<string>> Save()
        {
            List<string> stringedData = new List<string>() { Convert.ToString(Id), Convert.ToString(Weight), Convert.ToString(Price), Destination };
            Dictionary<string, List<string>> saveble = new Dictionary<string, List<string>>();
            saveble.Add("Items", stringedData);
            return saveble;
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
        public override Dictionary<string, List<string>> Save()
        {
            List<string> stringedData = new List<string>() { Convert.ToString(Id), Convert.ToString(Weight), Convert.ToString(Price), Destination, Writer, Title,Convert.ToString(PageCount), Convert.ToString(ReleaseDate)};
            Dictionary<string, List<string>> saveble = new Dictionary<string, List<string>>();
            saveble.Add("Books", stringedData);
            return saveble;
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
        public override Dictionary<string, List<string>> Save()
        {
            List<string> stringedData = new List<string>() { Convert.ToString(Id), Convert.ToString(Weight), Convert.ToString(Price), Destination, Name, Publisher, Type};
            Dictionary<string, List<string>> saveble = new Dictionary<string, List<string>>();
            saveble.Add("Electronics", stringedData);
            return saveble;
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
        public override Dictionary<string, List<string>> Save()
        {
            List<string> stringedData = new List<string>() { Convert.ToString(Id), Convert.ToString(Weight), Convert.ToString(Price), Destination, Type, Convert.ToString(Hight), Convert.ToString(With)};
            Dictionary<string, List<string>> saveble = new Dictionary<string, List<string>>();
            saveble.Add("Furniture", stringedData);
            return saveble;
        }
    }

    internal class Program
    {
        static List<Items> Load(string filname)
        {
            string json = File.ReadAllText(filname);

            Dictionary<string, List<string>> data = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(json);

            List<Items> inventory = new List<Items>();
            int index = 0;

            foreach (string k in data.Keys)
            {
                switch (k)
                {
                    case "Items":
                        {
                            inventory.Add(new Items(
                                Convert.ToInt32(data[k][0]),Convert.ToDouble(data[k][1]),Convert.ToInt32(data[k][2]), data[k][3]
                                ));
                            break;
                        }
                    case "Books":
                        {
                            inventory.Add(new Books(
                                data[k][4], data[k][5], Convert.ToInt32(data[k][6]), Convert.ToInt32(data[k][7]),Convert.ToInt32(data[k][0]), Convert.ToDouble(data[k][1]), Convert.ToInt32(data[k][2]), data[k][3]
                                ));
                            break;
                        }
                    case "Electronics":
                        {
                            inventory.Add(new Electronics(
                                data[k][4], data[k][5], data[k][6], Convert.ToInt32(data[k][0]), Convert.ToDouble(data[k][1]), Convert.ToInt32(data[k][2]), data[k][3]
                                ));
                            break;
                        }
                    case "Furniture":
                        {
                            inventory.Add(new Furniture(
                                data[k][4], Convert.ToInt32(data[k][5]), Convert.ToInt32(data[k][6]), Convert.ToInt32(data[k][0]), Convert.ToDouble(data[k][1]), Convert.ToInt32(data[k][2]), data[k][3]
                                ));
                            break;
                        }

                }
                index++;
            }
            return inventory;
        }
        static void Main(string[] args)
        {
            List<Items> inventroy= Load("data.json");
            Console.WriteLine(inventroy);
            Console.ReadLine();
        }
    }
}
