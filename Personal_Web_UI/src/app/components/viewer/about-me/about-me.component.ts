import { Component } from '@angular/core';
import { NavbarComponent } from '../navbar/navbar.component';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-about-me',
  standalone: true,
  imports: [NavbarComponent, FormsModule, CommonModule],
  templateUrl: './about-me.component.html',
  styleUrl: './about-me.component.css'
})
export class AboutMeComponent {
  selectedOption: string = '';
  
  options = [
    {value: "about_me", text: "About me"},
    {value: "skills", text: "Skills"},
    {value: "experience", text: "Experience"},
    {value: "future_projects", text: "Future Projects"}
  ];

  onOptionChange() {
    console.log(this.selectedOption);

    //TODO: call the API and save description in a new variable, then bind it to <p>

    /* if (this.selectedOption === 'about_me') {
      this.selectedOption = 'about_me';
    } else if (this.selectedOption ==='skills') {
      this.selectedOption ='skills';
    } else if (this.selectedOption === 'experience') {
      this.selectedOption = 'experience';
    } else if (this.selectedOption === 'future_projects') {
      this.selectedOption = 'future_projects';
    } */

  }

  ngOnInit() {
    this.selectedOption = this.options[0].value;
  }
}
