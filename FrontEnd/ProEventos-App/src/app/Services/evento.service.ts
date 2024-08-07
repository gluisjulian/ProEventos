import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class EventoService {

  baseURL: "https://localhost:7197/api/eventos";

constructor(private http: HttpClient) { }

getEvento(){
  return this.http.get(this.baseURL)
}

}
