import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-user-management',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './user-management.component.html',
  styleUrls: ['./user-management.component.css']
})
export class UserManagementComponent implements OnInit {
  users: any[] = [];
  newUser = {
    username: '',
    password: '',
    role: 'editor'
  };

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.getUsers();
  }

  get token() {
    return localStorage.getItem('token') || '';
  }

  get headers() {
    return { headers: new HttpHeaders({ Authorization: `Bearer ${this.token}` }) };
  }

  getUsers() {
    this.http.get<any[]>('https://localhost:7069/api/user', this.headers).subscribe({
      next: (data) => this.users = data,
      error: (err) => console.error('Kullanıcılar alınamadı:', err)
    });
  }

  addUser() {
    this.http.post('https://localhost:7069/api/user', this.newUser, this.headers).subscribe({
      next: () => {
        this.getUsers();
        this.newUser = { username: '', password: '', role: 'editor' };
      },
      error: (err) => console.error('Kullanıcı eklenemedi:', err)
    });
  }

  deleteUser(id: number) {
    if (confirm('Bu kullanıcı silinsin mi?')) {
      this.http.delete(`https://localhost:7069/api/user/${id}`, this.headers).subscribe({
        next: () => this.getUsers(),
        error: (err) => console.error('Kullanıcı silinemedi:', err)
      });
    }
  }
}
