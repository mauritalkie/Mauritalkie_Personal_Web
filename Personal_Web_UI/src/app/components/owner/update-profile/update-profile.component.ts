import { Component, ElementRef, ViewChild } from '@angular/core';
import { NavbarComponent } from '../navbar/navbar.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { UserService } from '../../../services/user.service';
import { UpdateUser } from '../../../dtos/User';
import { CloudinaryService } from '../../../services/cloudinary.service';

@Component({
  selector: 'app-update-profile',
  standalone: true,
  imports: [NavbarComponent, FormsModule, HttpClientModule],
  templateUrl: './update-profile.component.html',
  styleUrl: './update-profile.component.css'
})
export class UpdateProfileComponent {
  isChecked: boolean = false;
  file: any;

  currentImage?: string = ''
  currentUsername?: string = '';
  newPassword: string = '';
  confirmPassword: string = '';

  @ViewChild('fileInput') fileInput!: ElementRef;

  constructor(private service: UserService, private cloudinaryService: CloudinaryService) { }

  ngOnInit() {
    this.service.getCurrentUser().subscribe(user => {
      this.currentUsername = user.username;
      this.currentImage = user.userPictureUrl;
    });
  }

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
        this.file = e.target.files[0];
      }
    }
  }

  updateProfile() {
    if(this.file) {
      this.cloudinaryService.uploadImage(this.file).subscribe(url => this.currentImage = url);
    }
    
    if(this.currentUsername === '') {
      alert('Please enter an username');
      return;
    }

    if(this.isChecked && (this.newPassword === '' || this.confirmPassword === '')) {
      alert('Please fill out the password fields');
      return;
    }

    if(this.isChecked && this.newPassword!== this.confirmPassword) {
      alert('Passwords do not match');
      return;
    }

    const updateUser = new UpdateUser();
    updateUser.username = this.currentUsername;
    updateUser.userPictureUrl = this.currentImage;
    updateUser.userPassword = this.newPassword;

    this.service.updateUser(updateUser).subscribe();

    alert('User updated successfully');
    this.newPassword = '';
    this.confirmPassword = '';
  }
}
