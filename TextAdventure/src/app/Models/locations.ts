export class Locations {
    id: number;
    name: string;
    description: string;
    points: number;

    constructor(_id, _name, _description, _points) {

        this.id = _id;
        this.name = _name; 
        this.description = _description;
        this.points = _points;
    }
}
