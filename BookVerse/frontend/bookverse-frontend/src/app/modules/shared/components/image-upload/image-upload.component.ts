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
      useExisting: forwardRef(() => ImageUploadComponent),
      multi: true,
    },
  ],
})
export class ImageUploadComponent {
  preview: string | null = null;
  isDragging: boolean = false;

  private onChange = (value: any) => {};
  private onTouched = () => {}; // called when the form externally sets a value (e.g., edit mode)

  writeValue(value: any): void {
    this.preview = value;
  }

  registerOnChange(fn: any): void {
    this.onChange = fn; // Angular "listens" for value changes
  }

  registerOnTouched(fn: any): void {
    this.onTouched = fn; // Angular "listens" for when the field is touched
  }

  onFileSelect(event: any) {
    const file = event.target.files[0];
    if (file) {
      const reader = new FileReader();
      reader.onload = (e: any) => {
        this.preview = e.target.result;
        this.onChange(e.target.result);
        this.onTouched();
      };
      reader.readAsDataURL(file);
    }
  }
  remove(): void {
    this.preview = null;
    this.onChange(null);
    this.onTouched();
  }

  onDragOver(event: DragEvent) {
    event.preventDefault(); // REQUIRED — without this, drop does not work because browsers do not allow drop by default
    event.stopPropagation();
    this.isDragging = true; // changes the CSS class → visual feedback
  }

  onDragLeave(event: Event) {
    event.preventDefault();
    event.stopPropagation();
    this.isDragging = false; // restores normal appearance
  }

  onDrop(event: DragEvent) {
    event.preventDefault();
    event.stopPropagation();
    this.isDragging = false;

    const file = event.dataTransfer?.files[0]; // takes the first file from drag&drop
    if (file && file.type.startsWith('image/')) this.readFile(file); // validation — images only
  }

  private readFile(file: File): void {
    const reader = new FileReader();
    reader.onload = (e: any) => {
      this.preview = e.target.result; // base64 string — displayed in <img>
      this.onChange(e.target.result); // notifies the Angular form of the new value
      this.onTouched();
    };
    reader.readAsDataURL(file); // converts the file to base64
  }
}
