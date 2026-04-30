import { platformBrowser } from '@angular/platform-browser';
import { AppModule } from './app/app-module';

import 'zone.js'; // Software Engineering 1 setup, first install "npm install zone.js"

platformBrowser().bootstrapModule(AppModule, {

})
  .catch(err => console.error(err));
