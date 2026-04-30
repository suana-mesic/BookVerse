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

  //generates a new image for captcha verification; this endpoint returns the image and a token with the correct answer
  generate():Observable<CaptchaGenerateDto>{
    return this.http.get<CaptchaGenerateDto>(`${this.baseUrl}/generate`);
  }

  //we send the token back to the backend along with the user's answer
  verify(token:string, answer:string):Observable<any>{
    return this.http.post(`${this.baseUrl}/verify`,{token, answer});
  }
}
