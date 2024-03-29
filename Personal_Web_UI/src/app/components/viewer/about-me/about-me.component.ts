import { Component } from '@angular/core';
import { NavbarComponent } from '../navbar/navbar.component';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { GetSocialMedia } from '../../../dtos/SocialMedia';
import { GetAboutMe } from '../../../dtos/AboutMe';
import { GetSkill } from '../../../dtos/Skill';
import { GetExperience } from '../../../dtos/Experience';
import { GetFutureProject } from '../../../dtos/FutureProject';

@Component({
  selector: 'app-about-me',
  standalone: true,
  imports: [NavbarComponent, FormsModule, CommonModule],
  templateUrl: './about-me.component.html',
  styleUrl: './about-me.component.css'
})
export class AboutMeComponent {
  selectedOption?: string;
  username: string = 'mauritalkie';
  aboutMe: string = 'hii I am mauritalkie! ^^';
  
  options = [
    {value: "about_me", text: "About me"},
    {value: "skills", text: "Skills"},
    {value: "experience", text: "Experience"},
    {value: "future_projects", text: "Future Projects"}
  ];

  socialMedia: GetSocialMedia[] = [
    {SocialMediaName: "Github", SocialMediaUrl: "https://github.com/mauritalkie", ImageUrl: "https://i.pinimg.com/564x/8c/06/61/8c06617b7f297edae1f1804df6223184.jpg"},
    {SocialMediaName: "LinkedIn", SocialMediaUrl: "https://www.linkedin.com/in/mauritalkie/", ImageUrl: "https://i.pinimg.com/originals/0c/68/72/0c6872b1d634c1ed733a594af4508a5a.jpg"},
    {SocialMediaName: "Twitter", SocialMediaUrl: "https://twitter.com/mauritalkie", ImageUrl: "https://i.pinimg.com/564x/7c/8a/36/7c8a36f2a9eb2ab8d2ed8e52cc02cc11.jpg"}
  ];

  skills: GetSkill[] = [
    {SkillDescription: "HTML5"},
    {SkillDescription: "CSS3"},
    {SkillDescription: "Javascript"},
    {SkillDescription: "TypeScript"},
    {SkillDescription: "Angular"},
    {SkillDescription: "React"},
    {SkillDescription: "NodeJS"},
    {SkillDescription: "ExpressJS"},
    {SkillDescription: "MongoDB"},
    {SkillDescription: "PostgreSQL"},
    {SkillDescription: "MySQL"},
    {SkillDescription: "Git"},
    {SkillDescription: "Docker"},
    {SkillDescription: "Kubernetes"},
    {SkillDescription: "AWS"},
    {SkillDescription: "GCP"}
  ];

  experience: GetExperience[] = [
    {ExperienceDescription: "Software Engineer"},
    {ExperienceDescription: "Software Engineer"}
  ];

  futureProjects: GetFutureProject[] = [
    {FutureProjectDescription: "Software Engineer2"},
    {FutureProjectDescription: "Software Engineer2"},
    {FutureProjectDescription: "Software Engineer2"},
    {FutureProjectDescription: "Software Engineer2"},
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
