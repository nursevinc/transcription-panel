import { Component } from '@angular/core';
import { HttpClient, HttpEventType } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-upload',
  standalone: true,
  imports: [CommonModule, FormsModule, HttpClientModule],
  templateUrl: './upload.component.html',
  styleUrls: ['./upload.component.css']
})
export class UploadComponent {
  selectedFile: File | null = null;
  uploadMessage = '';

  constructor(private http: HttpClient) {}

  onFileSelected(event: any) {
    this.selectedFile = event.target.files[0];
  }

 upload() {
  if (!this.selectedFile) return;

  const token = localStorage.getItem('token');
  const headers = {
    Authorization: `Bearer ${token}`
  };

  const formData = new FormData();
  formData.append('file', this.selectedFile);

  this.http.post('https://localhost:7069/api/audio/upload', formData, { headers }).subscribe({
    next: (res) => {
      this.uploadMessage = 'Dosya başarıyla yüklendi!';
      console.log('Yanıt:', res);
    },
    error: (err) => {
      this.uploadMessage = 'Yükleme başarısız 😢';
      console.error(err);
    }
  });
}

}
