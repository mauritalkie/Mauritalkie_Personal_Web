import { Component } from '@angular/core';
import { NavbarComponent } from '../navbar/navbar.component';
import { CreateSocialMedia, GetSocialMedia, UpdateSocialMedia } from '../../../dtos/SocialMedia';
import { ModalComponent } from '../modal/modal.component';
import { FormsModule } from '@angular/forms';
import { SocialMediaService } from '../../../services/social-media.service';

@Component({
  selector: 'app-social-media',
  standalone: true,
  imports: [NavbarComponent, ModalComponent, FormsModule],
  templateUrl: './social-media.component.html',
  styleUrl: './social-media.component.css'
})
export class SocialMediaComponent {
  isModalVisible: boolean = false;
  isAdding: boolean = false;
  currentAction: string = '';

  currentId: number = 0;
  currentName?: string = '';
  currentUrl?: string = '';

  socialMedia: GetSocialMedia[] = [];

  newSocialMedia: any;
  updateSocialMedia: any;

  constructor(private service: SocialMediaService) { }

  ngOnInit() {
    this.getSocialMedia();
  }

  deleteSocialMedia(id: any) {
    this.socialMedia = this.socialMedia.filter(item => item.id!== id);
    this.service.deleteSocialMedia(id).subscribe();
  }

  openModal(state: boolean, action: string, event: Event) {
    this.isModalVisible = true;
    this.isAdding = state;
    this.currentAction = action;

    if(!this.isAdding) {
      const target = event.target as HTMLInputElement;
      this.currentId = parseInt(target.id);

      this.currentName = this.socialMedia.find(s => s.id == this.currentId)?.socialMediaName;
      this.currentUrl = this.socialMedia.find(s => s.id == this.currentId)?.socialMediaUrl;
    }
  }

  closeModal() {
    this.isModalVisible = false;
    this.currentName = '';
    this.currentUrl = '';
  }

  onSubmit() {
    if(this.currentName === '' || this.currentUrl === '') {
      alert('Please fill out all fields');
      return;
    }
    
    if(this.isAdding) {
      this.newSocialMedia = new CreateSocialMedia(this.currentName, this.currentUrl);
      this.service.createSocialMedia(this.newSocialMedia).subscribe(response => {
        alert("Social media created successfully");
        this.getSocialMedia();
      });
    }
    else {
      this.socialMedia = this.socialMedia.map(s => s.id == this.currentId? {id: this.currentId, socialMediaName: this.currentName, socialMediaUrl: this.currentUrl} : s);
      this.updateSocialMedia = new UpdateSocialMedia(this.currentId, this.currentName, this.currentUrl);
      this.service.updateSocialMedia(this.updateSocialMedia).subscribe();
      alert("Social media updated successfully");
    }

    this.closeModal();
  }

  getSocialMedia() {
    this.service.getSocialMediaOwner().subscribe(response => this.socialMedia = response)
  }
}
