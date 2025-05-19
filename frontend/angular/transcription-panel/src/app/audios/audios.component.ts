import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders, HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-audios',
  standalone: true,
  imports: [CommonModule, HttpClientModule, FormsModule], // FormsModule burada önemli!
  templateUrl: './audios.component.html',
  styleUrls: ['./audios.component.css']
})
export class AudiosComponent implements OnInit {
  audios: any[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    const token = localStorage.getItem('token');
    const headers = new HttpHeaders({ Authorization: `Bearer ${token}` });

    this.http.get<any[]>('https://localhost:7069/api/audio', { headers }).subscribe({
      next: (data) => {
        this.audios = data;
        console.log('Sesler:', this.audios);
      },
      error: (err) => {
        console.error('Ses dosyaları alınamadı:', err);
      }
    });
  }

  saveTranscription(audio: any) {
    const token = localStorage.getItem('token');
    const headers = {
      Authorization: `Bearer ${token}`
    };

    this.http.put(`https://localhost:7069/api/audio/${audio.id}`, audio, { headers }).subscribe({
      next: () => {
        alert('Transkripsiyon başarıyla kaydedildi!');
      },
      error: (err) => {
        console.error('Hata:', err);
        alert('Kaydetme başarısız 😢');
      }
    });
  }
}

