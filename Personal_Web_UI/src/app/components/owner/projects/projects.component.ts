import { Component, ElementRef, ViewChild } from '@angular/core';
import { NavbarComponent } from '../navbar/navbar.component';
import { GetProject } from '../../../dtos/Project';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-projects',
  standalone: true,
  imports: [NavbarComponent, FormsModule, CommonModule],
  templateUrl: './projects.component.html',
  styleUrl: './projects.component.css'
})
export class ProjectsComponent {
  selectedProject?: string;
  updateProject: boolean = false;
  buttonText: string = 'Create';

  currentName?: string = '';
  currentDescription?: string = '';
  currentUrl?: string = '';
  currentImage?: string = 'https://linamed.com/wp-content/themes/dfd-native/assets/images/no_image_resized_675-450.jpg';

  @ViewChild('fileInput') fileInput!: ElementRef;

  projects: GetProject[] = [
    {
      Id: 1, 
      ProjectName: 'First Project',
      ProjectDescription: 'Its Reimu Project',
      ProjectUrl: 'https://example',
      ImageUrl: 'https://i.pinimg.com/originals/e6/f7/33/e6f733eedd4aa92d12ed173cd08c5f7a.jpg'
    },
    {
      Id: 2, 
      ProjectName: 'Second Project',
      ProjectDescription: 'Its Marisa Project',
      ProjectUrl: 'https://example',
      ImageUrl: 'https://i.pinimg.com/564x/8c/06/61/8c06617b7f297edae1f1804df6223184.jpg'
    },
    {
      Id: 3, 
      ProjectName: 'Third Project',
      ProjectDescription: 'Its Sanae Project',
      ProjectUrl: 'https://example',
      ImageUrl: 'https://i.pinimg.com/originals/0c/68/72/0c6872b1d634c1ed733a594af4508a5a.jpg'
    },
    {
      Id: 4, 
      ProjectName: 'Fourth Project',
      ProjectDescription: 'Its Sakuya Project',
      ProjectUrl: 'https://example',
      ImageUrl: 'https://i.pinimg.com/564x/7c/8a/36/7c8a36f2a9eb2ab8d2ed8e52cc02cc11.jpg'
    }
  ]

  ngOnInit() {
    console.log(this.selectedProject);
  }

  onProjectChange(){
    this.updateProject = true;
    this.buttonText = 'Update';

    this.currentName = this.projects.find(p => p.Id == this.selectedProject)?.ProjectName;
    this.currentDescription = this.projects.find(p => p.Id == this.selectedProject)?.ProjectDescription;
    this.currentUrl = this.projects.find(p => p.Id == this.selectedProject)?.ProjectUrl;
    this.currentImage = this.projects.find(p => p.Id == this.selectedProject)?.ImageUrl;
  }

  submitProject() {
    if(this.updateProject) {
      alert('Updating project');
    }
    else {
      alert('Creating project');
    }
  }

  onImageClick() {
    this.fileInput.nativeElement.click();
  }

  onSelectFile(e: any) {
    if (e.target.files && e.target.files[0]) {
      var reader = new FileReader();
      reader.readAsDataURL(e.target.files[0]);
      reader.onload = (event: any) => {
        this.currentImage = event.target.result;
      }
    }
  }
}
