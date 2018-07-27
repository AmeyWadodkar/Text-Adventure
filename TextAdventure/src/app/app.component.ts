import { Component, OnInit, HostListener } from '@angular/core';
import { LocationService } from './services/location.service';
import { Direction } from './Models/direction';
import { Locations } from './Models/locations';
import { CommandService } from './services/command.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  @HostListener('window:beforeunload', [ '$event' ])
  beforeUnloadHander(event) {
    this.commandService.clearInventory().subscribe();
  }


  storyLine: string = "";
  score = 0;
  currentLocation: string = "home";
  inventory: Array<string> = [];
  eastButton: boolean = true; westButton: boolean = true; southButton: boolean = true; northButton: boolean = true;
  displayInventory: boolean = false;

  constructor(private locationService: LocationService, private commandService: CommandService) { }

  ngOnInit() {
    this.storyLine = "You wake up on plush carpet in a sparsely decorated room. You don't recognize where you are and feel uneased by how quiet it is. Looking around, you see 4 different ways out of this room. Perhaps someone else is here...";
  }

  showInventory() {
    this.displayInventory = !this.displayInventory;
    this.commandService.getInventory().subscribe(items=>{
      this.inventory= [];
      items.forEach(item=>this.inventory.push(item));
    });
  }

  updateLocation(location) {
    this.currentLocation = location;
  }

  updateDisplay(message) {
    var msg = message;
    this.storyLine = msg + "\n\n" + this.storyLine;
  }

  updateScore(setPoints) {
    var addPoints;
    if (setPoints === null) {
      addPoints = 5;
    } else {
      addPoints = setPoints;
    }
    this.score += addPoints;
  }

  enableDirectionButton(value: boolean) {
    this.eastButton = value;
    this.westButton = value;
    this.northButton = value;
    this.southButton = value;
  }

  directionButtonClick(btn: string) {
    let currentLocation;
    this.locationService.getNextLocation(this.currentLocation, btn).subscribe(location => {
      currentLocation = location;

      if (currentLocation !== null) {
        this.updateDisplay(currentLocation.description);

        if (!this.locationService.hasVisited(currentLocation.name)) {
          this.updateScore(currentLocation.points);
        }
        this.locationService.addVisited(currentLocation);
        this.currentLocation = currentLocation.name;
        this.checkNavButtons(currentLocation);
      }
    });
  }

  checkNavButtons(currentLocation: Locations) {
    this.locationService.getPositions(currentLocation.name).subscribe(position => {
      if (position.directions.east === null) {
        this.eastButton = false;
      } else {
        this.eastButton = true;
      }
      if (position.directions.west === null) {
        this.westButton = false;
      } else {
        this.westButton = true;
      }
      if (position.directions.north === null) {
        this.northButton = false;
      } else {
        this.northButton = true;
      }
      if (position.directions.south === null) {
        this.southButton = false;
      } else {
        this.southButton = true;
      }
    });
  }

  enterCommand(command: string) {
    console.log(command);
    this.commandService.executeCommand(this.currentLocation, command).subscribe(response => {
      if (response.displayMessage != undefined) {
        this.updateDisplay(response.displayMessage);
      }
      this.updateScore(response.score);
      if (response.location != undefined) {
        this.updateLocation(response.location.name);
        this.enableButton(response.north,response.south,response.east,response.west);
      }
    });
  }

  enableButton(north,south,east,west){
    this.northButton=north;
    this.southButton=south;
    this.eastButton=east;
    this.westButton=west;

  }

}
