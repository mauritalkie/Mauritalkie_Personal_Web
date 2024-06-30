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
    {Id: 1, SocialMediaName: 'quora', SocialMediaUrl: 'quora.com'},
    {Id: 2, SocialMediaName: 'facebook', SocialMediaUrl: 'facebook.com'},
    {Id: 3, SocialMediaName: 'twitter', SocialMediaUrl: 'twitter.com'},
    {Id: 4, SocialMediaName: 'instagram', SocialMediaUrl: 'instagram.com'},
    {Id: 5, SocialMediaName: 'youtube', SocialMediaUrl: 'youtube.com'},
    {Id: 6, SocialMediaName: 'linkedin', SocialMediaUrl: 'linkedin.com'},
    {Id: 7, SocialMediaName: 'github', SocialMediaUrl: 'github.com'},
    {Id: 8, SocialMediaName: 'pinterest', SocialMediaUrl: 'pinterest.com'},
  ];

  deleteSocialMedia(id: any) {
    this.socialMedia = this.socialMedia.filter(item => item.Id!== id);
  }

  openModal(state: boolean, action: string, event: Event) {
    this.isModalVisible = true;
    this.isAdding = state;
    this.currentAction = action;

    if(!this.isAdding) {
      const target = event.target as HTMLInputElement;
      this.currentId = parseInt(target.id);

      this.currentName = this.socialMedia.find(s => s.Id == this.currentId)?.SocialMediaName;
      this.currentUrl = this.socialMedia.find(s => s.Id == this.currentId)?.SocialMediaUrl;
    }
  }

  closeModal() {
    this.isModalVisible = false;
    this.currentName = '';
    this.currentUrl = '';
  }

  onSubmit() {
    if(this.isAdding) {
      // todo: add logic to get max Id value or get the social media list from database again
      this.socialMedia.push({Id: ++this.currentId, SocialMediaName: this.currentName, SocialMediaUrl: this.currentUrl});
    }
    else {
      this.socialMedia = this.socialMedia.map(s => s.Id == this.currentId? {Id: this.currentId, SocialMediaName: this.currentName, SocialMediaUrl: this.currentUrl} : s);
    }
    this.closeModal();
  }
}
