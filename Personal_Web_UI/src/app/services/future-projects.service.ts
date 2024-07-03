import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { GetFutureProject } from '../dtos/FutureProject';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class FutureProjectsService {
  private url = "FutureProject";

  constructor(private http: HttpClient) { }

  public getFutureProjectsViewer() : Observable<GetFutureProject[]> {
    return this.http.get<GetFutureProject[]>(`${environment.apiUrl}/${this.url}/Viewer/GetFutureProjects`);
  }

  public getFutureProjectsOwner() : Observable<GetFutureProject[]> {
    return this.http.get<GetFutureProject[]>(`${environment.apiUrl}/${this.url}/Owner/GetFutureProjects`);
  }
}
