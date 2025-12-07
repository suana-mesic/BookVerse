import { Component, EventEmitter, forwardRef, Output, output } from '@angular/core';
import { NG_VALUE_ACCESSOR } from '@angular/forms';
import { multicast } from 'rxjs';

@Component({
  selector: 'app-image-upload',
  standalone: false,
  templateUrl: './image-upload.component.html',
  styleUrl: './image-upload.component.scss',
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef((() => ImageUploadComponent)),
      multi: true
    }
  ]
})
export class ImageUploadComponent {
  preview: string | null = null;
  private onChange = (value: any) => { };
  private onTouched = () => { };

  writeValue(value: any): void {
    this.preview = value;
  }

  registerOnChange(fn: any): void {
    this.onChange = fn;
  }

  registerOnTouched(fn: any): void {
    this.onTouched = fn;
  }


  onFileSelect(event: any) {
    const file = event.target.files[0];
    if (file) {
      const reader = new FileReader();
      reader.onload = (e: any) => {
        this.preview = e.target.result;
        this.onChange(e.target.result);
        this.onTouched();
      }
      reader.readAsDataURL(file);
    }
  }
  remove(): void {
    this.preview = null;
    this.onChange(null);
    this.onTouched();
  }
}
