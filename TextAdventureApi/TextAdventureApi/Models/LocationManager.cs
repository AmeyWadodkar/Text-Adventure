using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TextAdventureApi.Models
{
    public class LocationManager
    {
        List<Position> allPositions;

        public LocationManager()
        {
            
            List<Location> locations = new List<Location>();

            Location home = new Location(1, "home", "You are on plush carpet in a sparsely decorated room. You don't recognize where you are and feel uneased by how quiet it is.Looking around, you see 4 different ways out of this room.Perhaps someone else is here...", 5);
            locations.Add(home);
            Location libraryMain = new Location(2, "libraryMain", "You enter a room lined with books and a small fireplace sits inside the opposite wall. A fine Persian carpet fills the floor and the air is musky. It seems like no one has been in this room for a while.", 15);
            locations.Add(libraryMain);
            Location northendLibrary= new Location(3, "northendLibrary", "You walk towards a bookcase opposite the door. Most of these books seem fairly old and have accumulated years of dust. However, one book seems to have been recently added to this library. It is titled 'Escaping' by Randy Butternubs.", 10);
            locations.Add(northendLibrary);
            Location artHall = new Location(4, "artHall", "There is a double door at the end of the hallway. Several abstract paintings line the hallway. One of these paintings is crooked.", 5);
            locations.Add(artHall);
            Location windowWall = new Location(5, "windowWall", "You face a small window with cast iron bars welded to the outside. There is a piece of paper taped to the window.", 5);
            locations.Add(windowWall);
            Location kitchen = new Location(6, "kitchen", "You enter an immaculate kitchen with white walls and a linoleum floor. There is a small cellar door next to the counter.", 10);
            locations.Add(kitchen);
            Location painting = new Location(7, "painting", "You turn and look at the crooked painting. It's a family portrait, but none of these people have faces.The exposed wall where the painting is tilted away from seems a lot cleaner than the rest of the wall...", 5);
            locations.Add(painting);
            Location tunnel = new Location(8, "tunnel", "This tunnel seems well excavated. There are even lamps on the walls! The lights turn on and you notice that there's a key in front of you.Take the key now, it seems like you won't be able to come back here.", 5);
            locations.Add(tunnel);
            Location southArtHallway = new Location(9, "southArtHallway", "You approach the double door at the end of the hall. It's ornately decorated with gold leaf inlays and the door handles are antique gold.The door's locked, so you need a key.", 5);
            locations.Add(southArtHallway);
            Location cellar = new Location(10, "cellar", "You open the door and descend the stairs to the cellar. The cellar has a dirt floor and rotten wooden posts supporting the ceiling. Suddenly, a growling dog approaches you. He doesn't seem friendly!", 5);
            locations.Add(cellar);
            Location holeInWall = new Location(11, "holeInWall", " ", 5);
            locations.Add(holeInWall);
            Location unlockedDoor = new Location(12, "unlockedDoor", " ", 5);
            locations.Add(unlockedDoor);
            Location lockedHallway = new Location(13, "lockedHallway", "Another hallway stands before you. There's an empty picture hook to your east with a door, again, at the end of the hallway.Maybe these two are related ? ", 10);
            locations.Add(lockedHallway);
            Location emptyPainting = new Location(14, "emptyPainting", "You face the empty hook. You seem convinced that it should be hanging something.", 5);
            locations.Add(emptyPainting);
            Location hungPainting = new Location(15, "hungPainting", "", 0);
            locations.Add(hungPainting);
            Location finalDoor = new Location(16, "finalDoor", "You approach the door at the end of the hallway and jiggle the doorknob. Thank the lord, this door doesn't require a key!You push through and exit the house.You're free!! \n\n ***YOU WON!!!***\n Press F5 to restart.", 55);
            locations.Add(finalDoor);
            Directions homeDirection = new Directions(locations[1], locations[3], locations[4], locations[5]);
            Directions windowWallDirection = new Directions(null, null, null, locations[0]);
            Directions artHallDirection = new Directions(locations[0], locations[8], locations[6], null);
            Directions kitchenDirection = new Directions(null, null, locations[0], null);
            Directions libraryMainDirection = new Directions(locations[2], locations[0], null, null);
            Directions northendLibraryDirection = new Directions(null, locations[1], null, null);
            Directions paintingDirection = new Directions(null, null, null, locations[3]);
            Directions tunnelDirection = new Directions(null, null, null, locations[6]);
            Directions southArtHallwayDirection = new Directions(locations[3], null, null, null);
            Directions holeInWallDirection = new Directions(null, null, locations[7], null);
            Directions unlockedDoorDirection = new Directions(locations[8], locations[12], null, null);
            Directions lockedHallwayDirection = new Directions(locations[11], null, locations[13], null);
            Directions emptyPaintingDirection = new Directions(locations[12], null, null, null);
            Directions hungPaintingDirection = new Directions(null,locations[15], null, null);
            Directions finalDoorDirection = new Directions(null, null, null, null);


            allPositions = new List<Position>();
            allPositions.Add(new Position(home,homeDirection));
            allPositions.Add(new Position(libraryMain,libraryMainDirection));
            allPositions.Add(new Position(northendLibrary,northendLibraryDirection));
            allPositions.Add(new Position(artHall, artHallDirection));
            allPositions.Add(new Position(windowWall,windowWallDirection));
            allPositions.Add(new Position(kitchen, kitchenDirection));
            allPositions.Add(new Position(painting, paintingDirection));
            allPositions.Add(new Position(tunnel, tunnelDirection));
            allPositions.Add(new Position(southArtHallway, southArtHallwayDirection));
            allPositions.Add(new Position(cellar, new Directions(null,null,null,null)));
            allPositions.Add(new Position(holeInWall, holeInWallDirection));
            allPositions.Add(new Position(unlockedDoor, unlockedDoorDirection));
            allPositions.Add(new Position(lockedHallway,lockedHallwayDirection));
            allPositions.Add(new Position(emptyPainting,emptyPaintingDirection));
            allPositions.Add(new Position(hungPainting, hungPaintingDirection));
            allPositions.Add(new Position(finalDoor, finalDoorDirection));


        }

        public IEnumerable<Position> GetAllPositions { get { return allPositions; } }

    }
}
