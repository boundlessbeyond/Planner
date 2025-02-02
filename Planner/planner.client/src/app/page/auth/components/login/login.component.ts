import { Component } from '@angular/core';
// TODO - import auth service from state
import { Router } from '@angular/router';
import { AuthService } from '../../../../state/auth-store';

@Component({
  selector: 'app-login',
  standalone: false,

  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent {
  email: string = '';
  password: string = '';
  errorMessage: string = '';

  constructor(private authService: AuthService, private router: Router) {}

  login(): void {
    this.authService.login(this.email, this.password).subscribe(
      (response) => {
        this.authService.saveToken(response.token);
        this.router.navigate(['/home']); // Navigate to a protected route after login
      },
      (error) => {
        this.errorMessage = 'Invalid login credentials';
      }
    );
  }
}
