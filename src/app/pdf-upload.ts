import { Component } from '@angular/core';

@Component({
  selector: 'pdf-upload',
  templateUrl: './pdf-upload.html',
})
export class PdfUpload {
  onFileSelected(event: Event): void {
    const target = event.target as HTMLInputElement;
    const file = target.files?.[0];
    if (file) {
      console.log('File selected:', file.name);
    }
  }
}
