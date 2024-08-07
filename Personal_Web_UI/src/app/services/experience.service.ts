import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { GetExperience } from '../dtos/Experience';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ExperienceService {
  private url = 'Experience';

  constructor(private http: HttpClient) { }

  public getExperienceViewer() : Observable<GetExperience[]> {
    return this.http.get<GetExperience[]>(`${environment.apiUrl}/${this.url}/Viewer/GetExperience`);
  }

  public getExperienceOwner() : Observable<GetExperience[]> {
    return this.http.get<GetExperience[]>(`${environment.apiUrl}/${this.url}/Owner/GetExperience`);
  }
}
