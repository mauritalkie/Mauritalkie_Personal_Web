import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { WeatherForecastService } from './services/weather-forecast.service';
import { HttpClientModule } from '@angular/common/http';
import { ProjectService } from './services/project.service';
import { CreateProject, UpdateProject } from './dtos/Project';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet, HttpClientModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
  providers: [WeatherForecastService, ProjectService]
})
export class AppComponent {
  title = 'Personal_Web_UI';
  datos: any;

  constructor(private service: ProjectService) { }
  ngOnInit(): void {
    /* this.service.getWeatherForecasts().subscribe((response) => {
      this.datos = response;
      console.log(this.datos);
    }); */

    this.service.getProjects().subscribe((response) => {
      this.datos = response;
      console.log(this.datos);
    });

    /* let project: CreateProject = new CreateProject("primer proyecto", "primer url", "primera imagen");
    this.service.createProject(project).subscribe((response) => {
      this.datos = response;
      console.log(this.datos);
    }) */

    /* let project: UpdateProject = new UpdateProject(5, "quinto proyecto", "quinta url", "quinta imagen");
    this.service.updateProject(project).subscribe((response) => {
      this.datos = response;
      console.log(this.datos);
    }) */

    /* this.service.deleteProject(4).subscribe((response) => {
      this.datos = response;
      console.log(this.datos);
    }); */ 

    /* this.service.getProjectById(4).subscribe((response) => {
      this.datos = response;
      console.log(this.datos);
    }); */ 

  }
}
