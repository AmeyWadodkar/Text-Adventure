using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TextAdventureApi.Models
{
    public class InventoryManager
    {
        List<string> inventory;

        public InventoryManager()
        {
            inventory = new List<string>();
            try
            {
                if (File.Exists("Inventory.txt"))
                {
                    inventory = ReadInventory();
                    
                }
                else
                {
                    inventory = new List<string>();
                    WriteInventory(inventory);
                }
            }
            catch (IOException io)
            {
                Console.WriteLine("I/O Exception occured");
            }
        }

        public void WriteInventory(IEnumerable<string> inventory)
        {
            File.WriteAllLines("Inventory.txt", inventory.ToArray());
        }

        public List<string> ReadInventory()
        {
            return System.IO.File.ReadAllLines("Inventory.txt").ToList();
        }


        public void updateInventory(string item,string action)
        {

            switch (action)
            {

                case "add":
                    inventory.Add(item);
                    break;

                case "delete":

                    if (inventory.Contains(item))
                    {
                        inventory.Remove(item);
                    }
                    break;

                default:
                    /*let setMsg = "Error encountered. Please try again.";
                    updateDisplay(setMsg);*/
                    break;
            }

            WriteInventory(inventory);
        }

        public List<string> GetInventory { get { return inventory; } }

        public void clearTextFileOnExit()
        {
            inventory.Clear();
            WriteInventory(inventory);
        }
    }
}
