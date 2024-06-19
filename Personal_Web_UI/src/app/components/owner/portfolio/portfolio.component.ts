import { Component } from '@angular/core';
import { NavbarComponent } from '../navbar/navbar.component';
import { GetProject } from '../../../dtos/Project';

@Component({
  selector: 'app-portfolio',
  standalone: true,
  imports: [NavbarComponent],
  templateUrl: './portfolio.component.html',
  styleUrl: './portfolio.component.css'
})
export class AdminPortfolioComponent {
  projects: GetProject[] = [
    {
      Id: 1,
      ProjectName: 'Personal_Web_UI',
      ProjectDescription: 'Personal Web UI',
      ProjectUrl: 'https://github.com/Mauritalkie/Personal_Web_UI',
      ImageUrl: 'https://i.pinimg.com/originals/e6/f7/33/e6f733eedd4aa92d12ed173cd08c5f7a.jpg'
    },
    {
      Id: 2,
      ProjectName: 'Personal_Web_UI',
      ProjectDescription: 'Personal Web UI',
      ProjectUrl: 'https://github.com/mauritalkie',
      ImageUrl: 'https://i.pinimg.com/564x/8c/06/61/8c06617b7f297edae1f1804df6223184.jpg'
    },
    {
      Id: 3,
      ProjectName: 'Personal_Web_UI',
      ProjectDescription: 'Personal Web UI',
      ProjectUrl: 'https://github.com/Mauritalkie/Personal_Web_UI',
      ImageUrl: 'https://i.pinimg.com/originals/0c/68/72/0c6872b1d634c1ed733a594af4508a5a.jpg'
    },
    {
      Id: 4,
      ProjectName: 'Personal_Web_UI',
      ProjectDescription: 'Personal Web UI',
      ProjectUrl: 'https://github.com/Mauritalkie/Personal_Web_UI',
      ImageUrl: 'https://i.pinimg.com/564x/7c/8a/36/7c8a36f2a9eb2ab8d2ed8e52cc02cc11.jpg'
    }
  ];
}
