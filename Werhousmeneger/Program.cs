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

        public virtual Dictionary<int, Dictionary<string, List<string>>> Save(int uniceID)
        {
            List<string> stringedData = new List<string>() { Convert.ToString(Id), Convert.ToString(Weight), Convert.ToString(Price), Destination };
            Dictionary<int,Dictionary<string, List<string>>>  saveble = new Dictionary<int, Dictionary<string, List<string>>>();
            saveble[uniceID].Add("Items", stringedData);
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
        public override Dictionary<int, Dictionary<string, List<string>>> Save(int uniceID)
        {
            List<string> stringedData = new List<string>() { Convert.ToString(Id), Convert.ToString(Weight), Convert.ToString(Price), Destination, Writer, Title,Convert.ToString(PageCount), Convert.ToString(ReleaseDate)};
            Dictionary<int, Dictionary<string, List<string>>> saveble = new Dictionary<int, Dictionary<string, List<string>>>();
            saveble[uniceID].Add("Books", stringedData);
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
        public override Dictionary<int, Dictionary<string, List<string>>> Save(int uniceID)
        {
            List<string> stringedData = new List<string>() { Convert.ToString(Id), Convert.ToString(Weight), Convert.ToString(Price), Destination, Name, Publisher, Type};
            Dictionary<int, Dictionary<string, List<string>>> saveble = new Dictionary<int, Dictionary<string, List<string>>>();
            saveble[uniceID].Add("Electronics", stringedData);
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
        public override Dictionary<int, Dictionary<string, List<string>>> Save(int uniceID)
        {
            List<string> stringedData = new List<string>() { Convert.ToString(Id), Convert.ToString(Weight), Convert.ToString(Price), Destination, Type, Convert.ToString(Hight), Convert.ToString(With)};
            Dictionary<int, Dictionary<string, List<string>>> saveble = new Dictionary<int, Dictionary<string, List<string>>>();
            saveble[uniceID].Add("Furniture", stringedData);
            return saveble;
        }
    }

    internal class Program
    {
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
            Console.WriteLine("4.) Remuve item");
            Console.WriteLine("========================");
            Console.Write("Answer: ");
            int answer = Convert.ToInt32(Console.ReadLine());
            return answer;
        }
        static void Main(string[] args)
        {
            List<Items> inventroy= Load("data.json");
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
                                break;
                            }
                        case 2:
                            {
                                break;
                            }
                        case 3:
                            {
                                break;
                            }
                        case 4:
                            {
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
