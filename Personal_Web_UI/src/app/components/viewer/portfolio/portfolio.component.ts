import { Component } from '@angular/core';
import { NavbarComponent } from '../navbar/navbar.component';
import { GetProject } from '../../../dtos/Project';
import { ProjectService } from '../../../services/project.service';
import { HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-portfolio',
  standalone: true,
  imports: [NavbarComponent, HttpClientModule],
  providers: [ProjectService],
  templateUrl: './portfolio.component.html',
  styleUrl: './portfolio.component.css'
})
export class PortfolioComponent {
  projects: GetProject[] = [];

  constructor(private service: ProjectService) { }

  ngOnInit(): void {
    this.service.getProjectsViewer().subscribe((response) => this.projects = response);
  }
}
