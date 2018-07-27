import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AppConstant } from '../common/app-constant';
import { Observable } from 'rxjs';
import { Direction } from '../Models/direction';
import { Locations } from '../Models/locations';

@Injectable({
  providedIn: 'root'
})
export class LocationService {

  vistedLocs: Array<string> = [];

  constructor(private http: HttpClient) { }

  getNextLocation(currentlocation:string,direction: string): Observable<any> {
    return this.http.get<any>(`${AppConstant.SERVER_BASE_URL}/${currentlocation}/${direction}`);
  }

  getPositions(currentlocation:string): Observable<any> {
    return this.http.get<any>(`${AppConstant.SERVER_BASE_URL}/${currentlocation}`);
  }

  addVisited(location) {
    this.vistedLocs.push(location);
  }

  hasVisited(location: string) {

    if (this.vistedLocs.indexOf(location) !== -1) {
      return true;
    }
    else {
      return false;
    }

  }


}
