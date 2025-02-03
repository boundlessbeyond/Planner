import { Component } from '@angular/core';
import { AuthService } from '../../../../state/auth-store';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-register',
  standalone: false,

  templateUrl: './register.component.html',
  styleUrl: './register.component.scss',
})
export class RegisterComponent {
  email = new FormControl();
  password = new FormControl();
  confirmPassword = new FormControl();
  errorMessage: string = '';

  constructor(private authService: AuthService) {}

  onSubmit() {
    if (this.password.value != this.confirmPassword.value) {
      // TODO - proper password confirmation validation
      this.errorMessage = 'passwords don\'t match';
      return;
    }

    this.authService.register(this.email.value, this.password.value).subscribe(
      (response) => {
        alert('Registration successful');
      },
      (error) => {
        this.errorMessage = 'Registration failed. Please try again.';
      }
    );
  }
}
