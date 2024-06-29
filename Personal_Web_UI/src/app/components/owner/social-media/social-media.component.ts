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
    this.socialMedia = this.socialMedia.filter(item => item.id!== id);
  }

  openModal() {
    this.isModalVisible = true;
  }

  closeModal() {
    this.isModalVisible = false;
  }
}
