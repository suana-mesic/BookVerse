import { AfterViewInit, Component } from '@angular/core';
import * as L from 'leaflet';

@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
})
export class MapComponent implements AfterViewInit {
  private map!: L.Map;

  ngAfterViewInit(): void {
    this.map = L.map('map').setView([43.634031, 18.14347], 9); // Between Mostar and Sarajevo

    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
      attribution: '© OpenStreetMap',
    }).addTo(this.map);

    // Marker 1 - Mostar (Stari most)
    L.marker([43.337, 17.8156])
      .addTo(this.map)
      .bindPopup('<b>Central Bookstore<br>12 books</b><br><a>Contact</a>');

    // Marker 2 - Mostar (Musala trg)
    L.marker([43.3438, 17.8078])
      .addTo(this.map)
      .bindPopup('<b>Fortica Books<br>14 books</b><br><a>Contact</a>');

    // Marker 3 - Sarajevo (Bascarsija)
    L.marker([43.8593, 18.4301])
      .addTo(this.map)
      .bindPopup('<b>Space Bookstore<br>19 books</b><br><a>Contact</a>');
  }
}
