import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  standalone: true, // Bunu ekle
  imports: [RouterOutlet],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'] //  styleUrl değil, style**Urls** olacak
})
export class AppComponent {
  title = 'transcription-panel';
}
