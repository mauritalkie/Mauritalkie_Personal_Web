import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { WeatherForecast } from '../models/WeatherForecast';
import { Observable } from 'rxjs/internal/Observable';

@Injectable({
  providedIn: 'root'
})
export class WeatherForecastService {

  constructor(private http: HttpClient) { }

  public getWeatherForecasts() : Observable<WeatherForecast[]> {
    return this.http.get<WeatherForecast[]>('http://localhost:5106/WeatherForecast');
  }

}
