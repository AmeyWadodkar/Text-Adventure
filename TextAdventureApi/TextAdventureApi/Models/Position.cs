using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TextAdventureApi.Models
{
    public class Position
    {
        public Location location { get; set; }
        public Directions directions { get; set; }

        public Position(Location location,Directions directions)
        {
            this.location = location;
            this.directions = directions;
        }
    }
}
