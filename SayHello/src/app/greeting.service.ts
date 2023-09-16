import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GreetingService {

  constructor(private http: HttpClient) { }

  PostGreetings(data:any):Observable<any>
  {
    return this.http.post<any>("https://localhost:7240/api/Greetings",data);
  }
  GetGreetings():Observable<any>
  {
    return this.http.get<any>("https://localhost:7240/api/Greetings");
  }
}
