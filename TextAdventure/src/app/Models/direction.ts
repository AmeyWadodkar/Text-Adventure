
export class Direction {

    north: Location;
    south: Location;
    east: Location;
    west: Location;

    constructor(north, south, east, west) {
        this.north = north;
        this.south = south;
        this.east = east;
        this.west = west;
    }
}
