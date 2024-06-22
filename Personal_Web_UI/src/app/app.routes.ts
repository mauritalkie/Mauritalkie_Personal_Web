import { Routes } from '@angular/router';
import { HomeComponent } from './components/viewer/home/home.component';
import { PortfolioComponent } from './components/viewer/portfolio/portfolio.component';
import { AboutMeComponent } from './components/viewer/about-me/about-me.component';
import { AdminHomeComponent } from './components/owner/home/home.component';
import { AdminAboutMeComponent } from './components/owner/about-me/about-me.component';
import { AdminPortfolioComponent } from './components/owner/portfolio/portfolio.component';
import { LoginComponent } from './components/owner/login/login.component';
import { ProjectsComponent } from './components/owner/projects/projects.component';

export const routes: Routes = [
    {path: '', redirectTo: '/home', pathMatch: 'full'},
    {path: 'home', component: HomeComponent},
    {path: 'portfolio', component: PortfolioComponent},
    {path: 'about_me', component: AboutMeComponent},

    {path: 'admin/home', component: AdminHomeComponent},
    {path: 'admin/about_me', component: AdminAboutMeComponent},
    {path: 'admin/portfolio', component: AdminPortfolioComponent},
    {path: 'login', component: LoginComponent},
    {path: 'projects', component: ProjectsComponent}
];
