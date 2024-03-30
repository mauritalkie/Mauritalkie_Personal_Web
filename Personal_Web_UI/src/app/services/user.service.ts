import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { DisplayUserInfo } from '../dtos/User';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private url = 'User';

  constructor(private http: HttpClient) { }

  public displayUserInfo() : Observable<DisplayUserInfo[]> {
    return this.http.get<DisplayUserInfo[]>(`${environment.apiUrl}/${this.url}/DisplayInfo/1`);
  }
}
