import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { CreateAboutMe, GetAboutMe, UpdateAboutMe } from '../dtos/AboutMe';

@Injectable({
  providedIn: 'root'
})
export class AboutMeService {
  private url = 'AboutMe';

  constructor(private http: HttpClient) { }

  public getAboutMeOwner() : Observable<GetAboutMe[]> {
    return this.http.get<GetAboutMe[]>(`${environment.apiUrl}/${this.url}/Owner/GetAboutMe`);
  }

  public updateAboutMe(aboutMe: UpdateAboutMe) : Observable<any> {
    return this.http.put(`${environment.apiUrl}/${this.url}`, aboutMe);
  }
}
