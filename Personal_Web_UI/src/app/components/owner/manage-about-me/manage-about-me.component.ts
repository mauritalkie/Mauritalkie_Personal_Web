import { Component } from '@angular/core';
import { NavbarComponent } from '../navbar/navbar.component';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-manage-about-me',
  standalone: true,
  imports: [NavbarComponent, FormsModule],
  templateUrl: './manage-about-me.component.html',
  styleUrl: './manage-about-me.component.css'
})
export class ManageAboutMeComponent {
  currentAboutMe: string = 'Hi I am mauritalkie!'
  // todo: get the about me from database

  saveAboutMe() {
    if(this.currentAboutMe === '') {
      alert('About me cannot be empty!');
      return;
    }
    // Save about me to the server or database
  }
}
