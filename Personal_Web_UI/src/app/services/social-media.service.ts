import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { GetSocialMedia } from '../dtos/SocialMedia';

@Injectable({
  providedIn: 'root'
})
export class SocialMediaService {
  private url = 'SocialMedia';

  constructor(private http: HttpClient) { }

  public getSocialMedia(): Observable<GetSocialMedia[]> {
    return this.http.get<GetSocialMedia[]>(`${environment.apiUrl}/${this.url}/1`);
  }
}
