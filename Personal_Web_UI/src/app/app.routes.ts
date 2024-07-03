import { Routes } from '@angular/router';
import { HomeComponent } from './components/viewer/home/home.component';
import { PortfolioComponent } from './components/viewer/portfolio/portfolio.component';
import { AboutMeComponent } from './components/viewer/about-me/about-me.component';
import { AdminHomeComponent } from './components/owner/home/home.component';
import { AdminAboutMeComponent } from './components/owner/about-me/about-me.component';
import { AdminPortfolioComponent } from './components/owner/portfolio/portfolio.component';
import { LoginComponent } from './components/owner/login/login.component';
import { ProjectsComponent } from './components/owner/projects/projects.component';
import { SocialMediaComponent } from './components/owner/social-media/social-media.component';
import { ManageAboutMeComponent } from './components/owner/manage-about-me/manage-about-me.component';
import { UpdateProfileComponent } from './components/owner/update-profile/update-profile.component';
import { authGuard } from './guards/auth.guard';

export const routes: Routes = [
    {path: '', redirectTo: '/home', pathMatch: 'full'},
    {path: 'home', component: HomeComponent},
    {path: 'portfolio', component: PortfolioComponent},
    {path: 'about_me', component: AboutMeComponent},

    {path: 'admin/home', component: AdminHomeComponent, canActivate: [authGuard]},
    {path: 'admin/about_me', component: AdminAboutMeComponent, canActivate: [authGuard]},
    {path: 'admin/portfolio', component: AdminPortfolioComponent, canActivate: [authGuard]},
    {path: 'login', component: LoginComponent},
    {path: 'projects', component: ProjectsComponent, canActivate: [authGuard]},
    {path: 'social_media', component: SocialMediaComponent, canActivate: [authGuard]},
    {path: 'manage_about_me', component: ManageAboutMeComponent, canActivate: [authGuard]},
    {path: 'update_profile', component: UpdateProfileComponent, canActivate: [authGuard]}
];
