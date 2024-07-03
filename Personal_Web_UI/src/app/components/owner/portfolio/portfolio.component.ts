import { Component } from '@angular/core';
import { NavbarComponent } from '../navbar/navbar.component';
import { GetProject } from '../../../dtos/Project';
import { ProjectService } from '../../../services/project.service';
import { HttpClient, HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-portfolio',
  standalone: true,
  imports: [NavbarComponent],
  providers: [ProjectService, HttpClient],
  templateUrl: './portfolio.component.html',
  styleUrl: './portfolio.component.css'
})
export class AdminPortfolioComponent {
  projects: GetProject[] = [];

  constructor(private service: ProjectService) { }

  ngOnInit(): void {
    this.service.getProjectsOwner().subscribe((response) => this.projects = response);
  }
}
