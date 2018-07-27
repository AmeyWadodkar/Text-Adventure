import { Locations } from "./locations";
import { Direction } from "./direction";

export class Position {

    location: Locations;
    directions: Direction

    constructor(_location, _directions) {
        this.directions = _directions;
        this.location = _location;
    }
}
