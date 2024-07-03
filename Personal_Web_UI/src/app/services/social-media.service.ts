import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { CreateSocialMedia, GetSocialMedia, UpdateSocialMedia } from '../dtos/SocialMedia';

@Injectable({
  providedIn: 'root'
})
export class SocialMediaService {
  private url = 'SocialMedia';

  constructor(private http: HttpClient) { }

  public getSocialMediaViewer(): Observable<GetSocialMedia[]> {
    return this.http.get<GetSocialMedia[]>(`${environment.apiUrl}/${this.url}/Viewer/GetSocialMedia`);
  }

  public getSocialMediaOwner(): Observable<GetSocialMedia[]> {
    return this.http.get<GetSocialMedia[]>(`${environment.apiUrl}/${this.url}/Owner/GetSocialMedia`);
  }

  public createSocialMedia(socialMedia: CreateSocialMedia): Observable<any> {
    return this.http.post(`${environment.apiUrl}/${this.url}`, socialMedia);
  }

  public updateSocialMedia(socialMedia: UpdateSocialMedia): Observable<any> {
    return this.http.put(`${environment.apiUrl}/${this.url}`, socialMedia);
  }

  public deleteSocialMedia(id: number): Observable<any> {
    return this.http.delete(`${environment.apiUrl}/${this.url}/${id}`);
  }
}
