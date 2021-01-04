import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Divida } from '../Models/Divida';

@Injectable({
  providedIn: 'root'
})
export class DividaService {

baseUrl = `${environment.UrlPrincipal}/api/Divida`

constructor(private http: HttpClient) { }

getAll(): Observable<Divida[]> {
  return this.http.get<Divida[]>(`${this.baseUrl}`);
}
getById(id: number): Observable<Divida> {
  return this.http.get<Divida>(`${this.baseUrl}/${id}`);
}
post(divida: Divida): Observable<Divida>{
  return this.http.post<Divida>(`${this.baseUrl}`,divida);
}
put(divida: Divida): Observable<Divida>{
  return this.http.put<Divida>(`${this.baseUrl}/${divida.id}`,divida);
}
delete(id: number) {
  return this.http.delete(`${this.baseUrl}/${id}`);
}

}
