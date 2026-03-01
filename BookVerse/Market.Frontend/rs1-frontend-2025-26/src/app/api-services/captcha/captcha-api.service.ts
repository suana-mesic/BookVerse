import { inject, Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CaptchaGenerateDto } from './captcha-api.model';

@Injectable({
  providedIn: 'root',
})
export class CaptchaApiService {
  private readonly baseUrl = `${environment.apiUrl}/captcha`;
  private http = inject(HttpClient);

  //generiše novu sliku za captcha provjeru, od ovog endpointa dobijamo sliku i token tačnog odgovora
  generate():Observable<CaptchaGenerateDto>{
    return this.http.get<CaptchaGenerateDto>(`${this.baseUrl}/generate`);
  }

  //tokon u šaljemo nazad (backend-u) i uz to šaljemo korisnikov odgovor
  verify(token:string, answer:string):Observable<any>{
    return this.http.post(`${this.baseUrl}/verify`,{token, answer});
  }
}
