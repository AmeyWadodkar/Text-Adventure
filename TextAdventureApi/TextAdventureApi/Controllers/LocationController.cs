using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TextAdventureApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TextAdventureApi.Controllers
{

    [EnableCors("AllowSpecificOrigin")]
    public class LocationController : Controller
    {
        LocationManager lm = new LocationManager();
        CommandsManager cm= new CommandsManager();
        InventoryManager im = new InventoryManager();
        
        // GET api/<controller>/5
        [HttpGet]
        [Route("api/[controller]/{name}/{direction}")]
        public Location Get(string name,string direction)
        {
            Position currentPosition = lm.GetAllPositions.First((Position playerlocation) => playerlocation.location.name.Equals(name));
            if ("north".Equals(direction))
            {
                return currentPosition.directions.north;
            }
            else if ("east".Equals(direction))
            {
                return currentPosition.directions.east;
            }
            else if ("west".Equals(direction))
            {
                return currentPosition.directions.west;
            }
            else if ("south".Equals(direction))
            {
                return currentPosition.directions.south;
            }
            return null;
        }

        [HttpGet]
        [Route("api/[controller]/{name}")]
        public Position GetPosition(string name)
        {
            return lm.GetAllPositions.First((Position playerlocation) => playerlocation.location.name.Equals(name));
        }

        [HttpGet]
        [Route ("api/[controller]/[action]/{currentlocation}/{command}")]
        [ActionName("Command")]
        public Response Command(string currentlocation, string command)
        {
            return cm.enterCommand(command,currentlocation);
        }

        [HttpGet]
        [Route ("api/[controller]/[action]")]
        [ActionName("GetInventory")]
        public List<string> GetInventory()
        {
            return im.GetInventory;
        }

        [HttpPost]
        [Route("api/[controller]/[action]")]
        [ActionName("Clear")]
        public Task<StatusCodeResult> Clear()
        {
            im.clearTextFileOnExit();
            return Task.FromResult(new StatusCodeResult(200));
        }

    }
}
