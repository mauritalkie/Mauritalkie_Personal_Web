import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { GetSkill } from '../dtos/Skill';

@Injectable({
  providedIn: 'root'
})
export class SkillService {
  private url = "Skill";

  constructor(private http: HttpClient) { }

  public getSkillsViewer(): Observable<GetSkill[]> {
    return this.http.get<GetSkill[]>(`${environment.apiUrl}/${this.url}/Viewer/GetSkills`);
  }

  public getSkillsOwner(): Observable<GetSkill[]> {
    return this.http.get<GetSkill[]>(`${environment.apiUrl}/${this.url}/Owner/GetSkills`);
  }
}
