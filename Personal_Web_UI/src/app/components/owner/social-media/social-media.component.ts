import { Component } from '@angular/core';
import { NavbarComponent } from '../navbar/navbar.component';
import { GetSocialMedia } from '../../../dtos/SocialMedia';
import { ModalComponent } from '../modal/modal.component';

@Component({
  selector: 'app-social-media',
  standalone: true,
  imports: [NavbarComponent, ModalComponent],
  templateUrl: './social-media.component.html',
  styleUrl: './social-media.component.css'
})
export class SocialMediaComponent {
  isModalVisible: boolean = false;

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

  openModal() {
    this.isModalVisible = true;
  }

  closeModal() {
    this.isModalVisible = false;
  }
}
