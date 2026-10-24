using System;
using System.Collections.Generic;
using System.Linq;
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
            saveble.Add("Books", stringedData);
            return saveble;
        }
    }
    public class furniture : Items
    {
        public string Type;
        public int Hight;
        public int With;
        public furniture(string type, int hight, int with, int id, double weight, int price, string destination) : base(id, weight, price, destination)
        {
            Type = type;
            Hight = hight;
            With = with;
        }
        public override Dictionary<string, List<string>> Save()
        {
            List<string> stringedData = new List<string>() { Convert.ToString(Id), Convert.ToString(Weight), Convert.ToString(Price), Destination, Type, Convert.ToString(Hight), Convert.ToString(With)};
            Dictionary<string, List<string>> saveble = new Dictionary<string, List<string>>();
            saveble.Add("Books", stringedData);
            return saveble;
        }
    }

    internal class Program
    {
        static void Load(string filname)
        {

        }
        static void Main(string[] args)
        {
            Convert.ToString(1);
        }
    }
}
