import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { CreateProject, GetProject, UpdateProject } from '../dtos/Project';

@Injectable({
  providedIn: 'root'
})
export class ProjectService {
  private url = "Project";

  constructor(private http: HttpClient) { }

  public getProjects(): Observable<GetProject[]> {
    return this.http.get<GetProject[]>(`${environment.apiUrl}/${this.url}/Projects/1`);
  }

  public createProject(project: CreateProject): Observable<any> {
    return this.http.post<any>(`${environment.apiUrl}/${this.url}`, project);
  }

  public updateProject(project: UpdateProject): Observable<any> {
    return this.http.put<any>(`${environment.apiUrl}/${this.url}`, project);
  }

  public deleteProject(id: number): Observable<any> {
    return this.http.delete<any>(`${environment.apiUrl}/${this.url}/${id}`);
  }

  public getProjectById(id: number): Observable<any> {
    return this.http.get<any>(`${environment.apiUrl}/${this.url}/${id}`);
  }
}
