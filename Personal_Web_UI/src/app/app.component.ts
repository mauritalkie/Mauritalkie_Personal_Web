import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { WeatherForecastService } from './services/weather-forecast.service';
import { HttpClient } from '@angular/common/http';
import { UserService } from './services/user.service';
import { LoginUser } from './dtos/User';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
  providers: [WeatherForecastService, UserService, HttpClient]
})
export class AppComponent {
  
}
