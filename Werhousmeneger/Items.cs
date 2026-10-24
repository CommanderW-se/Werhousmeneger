using System;
using System.Collections.Generic;

namespace items
{
    public class Items
    {
        public Items(int id, double weight, int price, string destination)
        {
            int Id = id;
            double Weight = weight;
            int Price = price;
            int Destination = destination;
        }
        public virtual string Save()
        {
            List<string> stringedData = new() { };
            Dictionary<string, List<string>> saveble
        }
    }
    public class Books : Items
    {
        public Books(string writer, string title, int pageCount, int releaseDate) : base(id, weight, price, destination)
        {
            string Writer = writer;
            string Title = title;
            int PageCount = pageCount;
            int ReleaseDate = releaseDate;
        }
    }
    public class Electronics : Items
    {
        public Electronics(string name, string publisher, string type) : base(id, weight, price, destination)
        {
            string Name = name;
            string Publisher = publisher;
            string Type = type;
        }
    }
    public class furniture
    {
        public furniture(string type, int hight, string with) : base(id, weight, price, destination)
        {
            string Type = type;
            string Hight = hight;
            string With = with;
        }
    }

}
