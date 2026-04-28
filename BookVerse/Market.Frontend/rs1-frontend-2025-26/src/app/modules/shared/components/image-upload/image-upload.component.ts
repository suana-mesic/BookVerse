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
  private onTouched = () => {}; // kada forma externalno postavi vrijednost (npr. edit mode)

  writeValue(value: any): void {
    this.preview = value;
  }

  registerOnChange(fn: any): void {
    this.onChange = fn; // Angular "sluša" promjene vrijednosti
  }

  registerOnTouched(fn: any): void {
    this.onTouched = fn; // Angular "sluša" kada je polje touched
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
    event.preventDefault(); // OBAVEZNO — bez ovoga drop ne radi jer browseri po defaultu ne dozvoljavaju drop
    event.stopPropagation();
    this.isDragging = true; // mijenja CSS klasu → vizualni feedback
  }

  onDragLeave(event: Event) {
    event.preventDefault();
    event.stopPropagation();
    this.isDragging = false; // vraća normalan izgled
  }

  onDrop(event: DragEvent) {
    event.preventDefault();
    event.stopPropagation();
    this.isDragging = false;

    const file = event.dataTransfer?.files[0]; // uzima prvi fajl iz drag&drop
    if (file && file.type.startsWith('image/')) this.readFile(file); // validacija — samo slike
  }

  private readFile(file: File): void {
    const reader = new FileReader();
    reader.onload = (e: any) => {
      this.preview = e.target.result; // base64 string — prikazuje se u <img>
      this.onChange(e.target.result); // obavještava Angular formu o novoj vrijednosti
      this.onTouched();
    };
    reader.readAsDataURL(file); // pretvara fajl u base64
  }
}
