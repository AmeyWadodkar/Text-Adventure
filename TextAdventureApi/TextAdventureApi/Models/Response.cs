using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TextAdventureApi.Models
{
    public class Response
    {
        public string displayMessage { get; set; }
        public int score { get; set; }
        public Location location { get; set; }
        public Boolean north { get; set; }
        public Boolean south { get; set; }
        public Boolean east { get; set; }
        public Boolean west { get; set; }

        public Response()
        {
            this.displayMessage = "";
            this.score = 0;
            this.north = false;
            this.south = false;
            this.east = false;
            this.west = false;
        }
    }
}
