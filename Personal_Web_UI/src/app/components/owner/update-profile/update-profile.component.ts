import { Component, ElementRef, ViewChild } from '@angular/core';
import { NavbarComponent } from '../navbar/navbar.component';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-update-profile',
  standalone: true,
  imports: [NavbarComponent, FormsModule],
  templateUrl: './update-profile.component.html',
  styleUrl: './update-profile.component.css'
})
export class UpdateProfileComponent {
  isChecked: boolean = false;

  currentImage: string = 'https://i.pinimg.com/originals/e6/f7/33/e6f733eedd4aa92d12ed173cd08c5f7a.jpg'
  currentUsername: string = '';
  newPassword: string = '';
  confirmPassword: string = '';

  @ViewChild('fileInput') fileInput!: ElementRef;

  emptyPasswordFields() {
    if(!this.isChecked) {
      this.newPassword = '';
      this.confirmPassword = '';
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
