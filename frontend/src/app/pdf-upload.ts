import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'pdf-upload',
  templateUrl: './pdf-upload.html',
  imports: [CommonModule],
})
export class PdfUpload {
  constructor(private http: HttpClient) {}

  onFileSelected(event: Event): void {
    const target = event.target as HTMLInputElement;
    const file = target.files?.[0];
    if (file) {
      this.uploadFile(file);
    }
  }

  private uploadFile(file: File): void {
    const form = new FormData();
    form.append('file', file, file.name);

    this.http.post('http://localhost:5135/api/upload-pdf', form).subscribe({
      next: (res) => console.log('Upload successful', res),
      error: (err) => console.error('Upload failed', err),
    });
  }
}
