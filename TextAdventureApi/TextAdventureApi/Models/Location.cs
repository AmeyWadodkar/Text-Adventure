using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TextAdventureApi.Models
{
    public class Location
    {

        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int points { get; set; }

        public Location(int id, string name, string description, int points)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.points = points;
        }
    }
}
