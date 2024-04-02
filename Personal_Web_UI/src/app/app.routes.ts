import { Routes } from '@angular/router';
import { HomeComponent } from './components/viewer/home/home.component';
import { PortfolioComponent } from './components/viewer/portfolio/portfolio.component';
import { AboutMeComponent } from './components/viewer/about-me/about-me.component';
import { AdminHomeComponent } from './components/owner/home/home.component';

export const routes: Routes = [
    {path: '', redirectTo: '/home', pathMatch: 'full'},
    {path: 'home', component: HomeComponent},
    {path: 'portfolio', component: PortfolioComponent},
    {path: 'about_me', component: AboutMeComponent},

    {path: 'admin/home', component: AdminHomeComponent}
];
