import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AppConstant } from '../common/app-constant';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CommandService {

  constructor(private http: HttpClient) { }

  executeCommand(currentLocation: string, command: string):Observable<any> {
    return this.http.get<any>(`${AppConstant.COMMAND_URL}/${currentLocation}/${command}`);
  }

  getInventory(){
    return this.http.get<any>(`${AppConstant.GET_INVENTORY_URL}`);
  }

  clearInventory(){
    return this.http.get<any>(`${AppConstant.CLEAR_URL}`);
  }
  
}

