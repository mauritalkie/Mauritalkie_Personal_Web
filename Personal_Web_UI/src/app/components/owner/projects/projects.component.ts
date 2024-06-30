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
  selectedProject?: number;
  updateProject: boolean = false;
  buttonText: string = 'Create';

  currentName?: string = '';
  currentDescription?: string = '';
  currentUrl?: string = '';
  currentImage?: string = 'https://linamed.com/wp-content/themes/dfd-native/assets/images/no_image_resized_675-450.jpg';

  @ViewChild('fileInput') fileInput!: ElementRef;

  projects: GetProject[] = [
    {
      id: 1, 
      projectName: 'First Project',
      projectDescription: 'Its Reimu Project',
      projectUrl: 'https://example',
      imageUrl: 'https://i.pinimg.com/originals/e6/f7/33/e6f733eedd4aa92d12ed173cd08c5f7a.jpg'
    },
    {
      id: 2, 
      projectName: 'Second Project',
      projectDescription: 'Its Marisa Project',
      projectUrl: 'https://example',
      imageUrl: 'https://i.pinimg.com/564x/8c/06/61/8c06617b7f297edae1f1804df6223184.jpg'
    },
    {
      id: 3, 
      projectName: 'Third Project',
      projectDescription: 'Its Sanae Project',
      projectUrl: 'https://example',
      imageUrl: 'https://i.pinimg.com/originals/0c/68/72/0c6872b1d634c1ed733a594af4508a5a.jpg'
    },
    {
      id: 4, 
      projectName: 'Fourth Project',
      projectDescription: 'Its Sakuya Project',
      projectUrl: 'https://example',
      imageUrl: 'https://i.pinimg.com/564x/7c/8a/36/7c8a36f2a9eb2ab8d2ed8e52cc02cc11.jpg'
    }
  ]

  ngOnInit() {
    console.log(this.selectedProject);
  }

  onProjectChange(){
    this.updateProject = true;
    this.buttonText = 'Update';

    this.currentName = this.projects.find(p => p.id == this.selectedProject)?.projectName;
    this.currentDescription = this.projects.find(p => p.id == this.selectedProject)?.projectDescription;
    this.currentUrl = this.projects.find(p => p.id == this.selectedProject)?.projectUrl;
    this.currentImage = this.projects.find(p => p.id == this.selectedProject)?.imageUrl;
  }

  submitProject() {
    if(this.currentName === '' || this.currentDescription === '' || this.currentUrl === '') {
      alert('Please fill all fields');
      return;
    }
    
    if(this.updateProject) {
      //todo: call the service
      
      this.projects = this.projects.map(p => p.id == this.selectedProject? 
        {
          id: this.selectedProject, 
          projectName: this.currentName, 
          projectDescription: this.currentDescription, 
          projectUrl: this.currentUrl, 
          imageUrl: this.currentImage
        } : p);

        alert('Project updated successfully');
    }
    else {
      //todo: call the service
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
