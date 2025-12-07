import { Component, ElementRef, ViewChild } from '@angular/core';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-header',
  imports: [RouterLink],
  templateUrl: './header.component.html',
  styleUrl: 'header.component.css',
})
export class HeaderComponent {
  @ViewChild('dropMenu') dropMenu!: ElementRef;

  dropMenuOpened = false;

  showDropMenu() {
    console.log(this.dropMenu);
    if (!this.dropMenuOpened) {
      this.dropMenu.nativeElement.style.height = '455px';
    } else {
      this.dropMenu.nativeElement.style.height = '0px';
    }
    this.dropMenuOpened = !this.dropMenuOpened;
  }
}
