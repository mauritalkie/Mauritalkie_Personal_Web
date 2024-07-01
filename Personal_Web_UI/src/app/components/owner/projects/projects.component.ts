import { Component, ElementRef, ViewChild } from '@angular/core';
import { NavbarComponent } from '../navbar/navbar.component';
import { CreateProject, GetProject, UpdateProject } from '../../../dtos/Project';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ProjectService } from '../../../services/project.service';

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

  newProjectData: any;
  updateProjectData: any;

  constructor(private service: ProjectService) { }

  @ViewChild('fileInput') fileInput!: ElementRef;

  projects: GetProject[] = []

  ngOnInit() {
    this.getProjects();
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

        this.updateProjectData = new UpdateProject (
          this.selectedProject, 
          this.currentName, 
          this.currentDescription, 
          this.currentUrl, 
          this.currentImage
        );

        this.service.updateProject(this.updateProjectData).subscribe();
        
        alert('Project updated successfully');
    }
    else {
      this.newProjectData = new CreateProject (
        this.currentName, 
        this.currentDescription, 
        this.currentUrl, 
        this.currentImage 
      );

      this.service.createProject(this.newProjectData).subscribe(response => {
        alert('Project created successfully');

        this.currentName = '';
        this.currentDescription = '';
        this.currentUrl = '';

        this.getProjects();
      });
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

  getProjects() {
    this.service.getProjectsOwner().subscribe((response) => this.projects = response);
  }
}
