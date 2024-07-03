import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CloudinaryService {

  private cloudName = 'djzexfj7v';
  private uploadPreset = 'jnxrpmt1';

  constructor(private http: HttpClient) { }

  uploadImage(imageFile: File) : Observable<string> {
    const url = `${environment.cloudinaryApiUrl}/${this.cloudName}/image/upload`;
    const formData = new FormData();
    formData.append('file', imageFile);
    formData.append('upload_preset', this.uploadPreset);

    return this.http.post(url, formData).pipe(
      map((response: any) => response.secure_url)
    );
  }
}
