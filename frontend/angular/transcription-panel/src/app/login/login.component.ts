import { Component } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms'; //  bunu ekle
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, FormsModule, HttpClientModule],
   templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  username = '';
  password = '';
  errorMessage = '';

  constructor(private http: HttpClient, private router: Router) {}

  login() {
    const body = {
      username: this.username,
      password: this.password
    };

    this.http.post<any>('https://localhost:7069/api/auth/login', body).subscribe({
      next: (res) => {
        console.log('Login başarılı:', res);
        localStorage.setItem('token', res.token);
        this.router.navigate(['/audios']);
      },
      
      error: (err) => {
        this.errorMessage = err.error?.message || err.statusText || 'Giriş başarısız';
      }
    });
  }
}
