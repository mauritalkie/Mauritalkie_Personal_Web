import { Component } from '@angular/core';
import { NavbarComponent } from '../navbar/navbar.component';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { GetSocialMedia } from '../../../dtos/SocialMedia';
import { GetAboutMe } from '../../../dtos/AboutMe';
import { GetSkill } from '../../../dtos/Skill';
import { GetExperience } from '../../../dtos/Experience';
import { GetFutureProject } from '../../../dtos/FutureProject';
import { DisplayUserInfo } from '../../../dtos/User';
import { UserService } from '../../../services/user.service';
import { SocialMediaService } from '../../../services/social-media.service';
import { SkillService } from '../../../services/skill.service';
import { ExperienceService } from '../../../services/experience.service';
import { FutureProjectsService } from '../../../services/future-projects.service';
import { HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-about-me',
  standalone: true,
  imports: [NavbarComponent, FormsModule, CommonModule, HttpClientModule],
  providers: [UserService, SocialMediaService, SkillService, ExperienceService, FutureProjectsService],
  templateUrl: './about-me.component.html',
  styleUrl: './about-me.component.css'
})
export class AdminAboutMeComponent {
  selectedOption?: string;

  username?: string;
  aboutMe?: string;
  imageUrl?: string;

  info: DisplayUserInfo[] = [];
  socialMedia: GetSocialMedia[] = [];
  skills: GetSkill[] = [];
  experience: GetExperience[] = [];
  futureProjects: GetFutureProject[] = [];

  constructor(
    private userService: UserService, 
    private socialMediaService: SocialMediaService, 
    private skillService: SkillService, 
    private experienceService: ExperienceService, 
    private futureProjectsService: FutureProjectsService
    ) { }
  
  options = [
    {value: "about_me", text: "About me"},
    {value: "skills", text: "Skills"},
    {value: "experience", text: "Experience"},
    {value: "future_projects", text: "Future Projects"}
  ];
  ngOnInit() {
    this.selectedOption = this.options[0].value;

    this.userService.displayUserInfo().subscribe((response) => {
      this.info = response;
      
      this.info.forEach((item) => {
        this.username = item.username;
        this.aboutMe = item.aboutMeDescription;
        this.imageUrl = item.userPictureUrl;
      });
    });

    this.socialMediaService.getSocialMedia().subscribe((response) => this.socialMedia = response);
    this.skillService.getSkills().subscribe((response) => this.skills = response);
    this.experienceService.getExperience().subscribe((response) => this.experience = response);
    this.futureProjectsService.getFutureProjects().subscribe((response) => this.futureProjects = response);
  }
}
