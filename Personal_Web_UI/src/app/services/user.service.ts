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

  public displayUserInfoViewer(): Observable<DisplayUserInfo[]> {
    return this.http.get<DisplayUserInfo[]>(`${environment.apiUrl}/${this.url}/DisplayInfoViewer/1`);
  }

  public displayUserInfoOwner(): Observable<DisplayUserInfo[]> {
    return this.http.get<DisplayUserInfo[]>(`${environment.apiUrl}/${this.url}/DisplayOwner`);
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
