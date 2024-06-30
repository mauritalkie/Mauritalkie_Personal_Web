import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { DisplayUserInfo, LoginUser } from '../dtos/User';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private url = 'User';

  constructor(private http: HttpClient) { }

  public displayUserInfo(): Observable<DisplayUserInfo[]> {
    return this.http.get<DisplayUserInfo[]>(`${environment.apiUrl}/${this.url}/DisplayInfo/1`);
  }

  public login(loginUser: LoginUser): Observable<any> {
    return this.http.post<any>(`${environment.apiUrl}/${this.url}/Login`, loginUser);
  }

  public getMyName(): Observable<string> {
    return this.http.get(`${environment.apiUrl}/${this.url}/GetMyName`, {
      responseType: 'text'
    });
  }
}
