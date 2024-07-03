import { Component } from '@angular/core';
import { NavbarComponent } from '../navbar/navbar.component';
import { FormsModule } from '@angular/forms';
import { AboutMeService } from '../../../services/about-me.service';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { GetAboutMe, UpdateAboutMe } from '../../../dtos/AboutMe';

@Component({
  selector: 'app-manage-about-me',
  standalone: true,
  imports: [NavbarComponent, FormsModule],
  providers: [HttpClient],
  templateUrl: './manage-about-me.component.html',
  styleUrl: './manage-about-me.component.css'
})
export class ManageAboutMeComponent {
  aboutMe: GetAboutMe[] = [];
  currentAboutMe?: string = '';
  updateAboutMe = new UpdateAboutMe();

  constructor(private service: AboutMeService) { }
  
  ngOnInit() {
    this.service.getAboutMeOwner().subscribe((response) => {
      this.aboutMe = response;
      this.currentAboutMe = this.aboutMe[0].aboutMeDescription;
    });
  }

  saveAboutMe() {
    if(this.currentAboutMe === '') {
      alert('About me cannot be empty!');
      return;
    }

    this.updateAboutMe.id = this.aboutMe[0].id;
    this.updateAboutMe.aboutMeDescription = this.currentAboutMe;

    this.service.updateAboutMe(this.updateAboutMe).subscribe();
    alert('About me updated successfully');
  }
}
