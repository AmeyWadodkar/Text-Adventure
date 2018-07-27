using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TextAdventureApi.Models
{
    public class CommandsManager
    {
        List<String> validCommands = new List<string>();
        InventoryManager im;
        LocationManager lm;

        public CommandsManager()
        {
            im = new InventoryManager();
            lm = new LocationManager();
            addValidCommands();
        }


        
        private void addValidCommands()
        {
            validCommands.Add("commands");
            validCommands.Add("take paper");
            validCommands.Add("take painting");
            validCommands.Add("take key");
            validCommands.Add("inventory");
            validCommands.Add("use key");
            validCommands.Add("hang painting");
        }

        public Response enterCommand(string inputCmd,String currentLocation)
        {
            Response response=null;

            if (validCommands.Contains(inputCmd.ToLower()))
            {
                switch (inputCmd)
                {
                    case "commands":
                        response=listCommands();
                        break;

                    case "inventory":
                        response = listInventory();
                        break;

                    case "take paper":
                        response =takePaper(currentLocation);
                        break;

                    case "take painting":
                        response = takePainting(currentLocation);
                        break;

                    case "take key":
                        response = takeKey(currentLocation);
                        break;                

                    case "use key":
                        response = useKey(currentLocation);
                        break;

                    case "hang painting":
                        response = hangPainting(currentLocation);
                        break;

                    default:
                        var setMsg = "Invalid command. If you need help, enter 'commands' without quotes in the input box.";
                        response = new Response();
                        response.displayMessage = setMsg;
                        //updateDisplay(setMsg);
                        break;
                }

            }
            else
            {
                var setMsg = "This is not a valid command. For help with commands, please type 'commands' without quotations into the input box.";
                response = new Response();
                response.displayMessage = setMsg;
                
                //updateDisplay(setMsg);
            }

            return response;
        }

        

        private Response listCommands()
        {
            var setMsg = String.Join(",",validCommands.ToArray())+"\nView inventory by typing inventory or clicking the plus icon. ";

            Response response = new Response();
            response.displayMessage = setMsg;
            return response;

            //updateDisplay(setMsg);
        }

        public Response listInventory()
        {
            var setMsg = "Inventory:";
            List<string> getInventory = im.GetInventory;
            if (getInventory.Count != 0) { 
                getInventory.ForEach(s => { setMsg += "-" + s; });
            }
            Response response = new Response();
            response.displayMessage = setMsg;
            return response;

        }

        public Response takePaper(string currentLocation)
        {
            Response response= new Response();
            if (currentLocation.Equals("windowWall") && !im.GetInventory.Contains("map"))
            {
                var setMsg = "You take the paper and read it. It seems to be a crudely drawn map of some location. Maybe it's for this house?";
                response.displayMessage = setMsg;

                var item = "map";
                var action = "add";
                im.updateInventory(item, action);
            }
            else
            {
                var setMsg = "You can't do that here!";
                response.displayMessage = setMsg;
            }
            return response;
        }

        public Response takePainting(string currentLocation)
        {
            Response response= new Response();
            if (currentLocation.Equals("painting") && !im.GetInventory.Contains("painting"))
            {
                var setMsg = "You take the crooked painting off the wall. There was a tunnel behind it!";
                response.score = 15;
                response.displayMessage = setMsg;
                response.location = lm.GetAllPositions.First(position=>position.location.name.Equals("holeInWall")).location;
                response.east = true;

                var item = "painting";
                var action = "add";
                im.updateInventory(item, action);

            }
            else
            {
                var setMsg = "You can't do that here!";
                response.displayMessage = setMsg;
            }

            return response;
        }

        public Response takeKey(string currentLocation)
        {
            Response response= new Response();
            if (currentLocation.Equals("tunnel") && !im.GetInventory.Contains("key"))
            {
                var setMsg = "You take the skeleton key. It has the word 'escape' engraved on the handle and looks quite old. You should probably take this now. It doesn't seem like you'll be able to get back in here!";
                response.score = 20;
                response.displayMessage = setMsg;

                var item = "key";
                var action = "add";
                im.updateInventory(item, action);

            }
            else
            {
                var setMsg = "You can't do that here! There aren't any keys to pick up, doofus!";
                response.displayMessage = setMsg;
            }
            return response;
        }


        public Response hangPainting(string currentLocation)
        {
            Response response= new Response();
            if (currentLocation.Equals("emptyPainting") && im.GetInventory.Contains("painting"))
            { 
                var setMsg = "You hang the painting and watch it slowly sink down the wall. The hook must have been connected to some kind of lever. You hear a door unlock at the end of the hall.";
                response.score = 35;
                response.displayMessage = setMsg;
                response.location = lm.GetAllPositions.First(position => position.location.name.Equals("hungPainting")).location;
                response.south = true;
            }
            else
            {
                var setMsg = "Can't do that here. What are you even thinking trying to pull that kind of stunt?";
                response.displayMessage = setMsg;
            }

            return response;
        }     

        public Response useKey(string currentLocation)
        {
            Response response= new Response();
            if (currentLocation.Equals("southArtHallway") && im.GetInventory.Contains("key"))
            {
                var setMsg = "You put the key into the door and unlock it. The door slowly swings open and nothing else happens. Whelp. Guess you have to go forward.";
                response.score=25;
                response.displayMessage=setMsg;
                response.location= lm.GetAllPositions.First(position => position.location.name.Equals("unlockedDoor")).location;
                response.south = true;
            }
            else
            {
                var setMsg = "You can't do that here, doofus!";
                response.displayMessage = setMsg;
            }
            return response;
        }

    }
}
