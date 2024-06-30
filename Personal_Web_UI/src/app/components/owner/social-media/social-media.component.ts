import { Component } from '@angular/core';
import { NavbarComponent } from '../navbar/navbar.component';
import { GetSocialMedia } from '../../../dtos/SocialMedia';
import { ModalComponent } from '../modal/modal.component';
import { FormsModule } from '@angular/forms';

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

  socialMedia: GetSocialMedia[] = [
    {id: 1, socialMediaName: 'quora', socialMediaUrl: 'quora.com'},
    {id: 2, socialMediaName: 'facebook', socialMediaUrl: 'facebook.com'},
    {id: 3, socialMediaName: 'twitter', socialMediaUrl: 'twitter.com'},
    {id: 4, socialMediaName: 'instagram', socialMediaUrl: 'instagram.com'},
    {id: 5, socialMediaName: 'youtube', socialMediaUrl: 'youtube.com'},
    {id: 6, socialMediaName: 'linkedin', socialMediaUrl: 'linkedin.com'},
    {id: 7, socialMediaName: 'github', socialMediaUrl: 'github.com'},
    {id: 8, socialMediaName: 'pinterest', socialMediaUrl: 'pinterest.com'},
  ];

  deleteSocialMedia(id: any) {
    //todo: call the remove service method
    this.socialMedia = this.socialMedia.filter(item => item.id!== id);
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
      // todo: call the service to get the social media list
      this.socialMedia.push({id: ++this.currentId, socialMediaName: this.currentName, socialMediaUrl: this.currentUrl});
    }
    else {
      this.socialMedia = this.socialMedia.map(s => s.id == this.currentId? {id: this.currentId, socialMediaName: this.currentName, socialMediaUrl: this.currentUrl} : s);
    }
    this.closeModal();
  }
}
