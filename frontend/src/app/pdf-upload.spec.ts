import { TestBed } from '@angular/core/testing';
import { PdfUpload } from './pdf-upload';

describe('PdfUpload', () => {
  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PdfUpload],
    }).compileComponents();
  });
});
