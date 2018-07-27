using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TextAdventureApi.Models
{
    public class Directions
    {
        public Location north { get; set; }
        public Location south { get; set; }
        public Location east { get; set; }
        public Location west { get; set; }

        public Directions(Location north, Location south, Location east, Location west)
        {
            this.north = north;
            this.south = south;
            this.east = east;
            this.west = west;
        }
    }
}
