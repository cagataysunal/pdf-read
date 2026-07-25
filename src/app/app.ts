import { Component, signal } from '@angular/core';
import { PdfUpload } from './pdf-upload';

@Component({
  selector: 'app-root',
  templateUrl: './app.html',
  imports: [PdfUpload],
})
export class App {
  protected readonly title = signal('pdf-read');
}
