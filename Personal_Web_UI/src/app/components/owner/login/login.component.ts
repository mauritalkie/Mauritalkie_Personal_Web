import { Component } from '@angular/core';
import { UserService } from '../../../services/user.service';
import { LoginUser, SessionUser } from '../../../dtos/User';
import { HttpClient, HttpClientModule, provideHttpClient, withInterceptors } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { loggerInterceptor } from '../../../interceptors/logger.interceptor';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule],
  providers: [UserService, HttpClient],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  loginUser = new LoginUser();
  sessionUser = new SessionUser();

  constructor(private userService: UserService, private router: Router) { }

  login(user: LoginUser) {
    this.userService.login(user).subscribe((response) => {
      
      if(response.token == undefined) {
        alert(response);
        return;
      }

      this.sessionUser.token = response.token;
      localStorage.setItem('authToken', this.sessionUser.token);
      this.router.navigate(['/admin/home']);
    });
  }

  getMyName() {
    this.userService.getMyName().subscribe((name: string) => console.log(name));
  }

  submit() {
    
    if(this.loginUser.username === '' || this.loginUser.userPassword === '') {
      alert('Please fill in both username and password.');
      return;
    }

    this.login(this.loginUser);
  }
}
