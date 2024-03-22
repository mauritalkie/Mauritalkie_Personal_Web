import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { WeatherForecastService } from './services/weather-forecast.service';
import { HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet, HttpClientModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
  providers: [WeatherForecastService]
})
export class AppComponent {
  title = 'Personal_Web_UI';
  datos: any;

  constructor(private service: WeatherForecastService) { }
  ngOnInit(): void {
    this.service.getWeatherForecasts().subscribe((response) => {
      this.datos = response;
      console.log(this.datos);
    })
  }
}
