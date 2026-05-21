import { Component, OnInit, inject } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { CaptchaApiService } from '../../../../api-services/captcha/captcha-api.service';

// Reusable captcha widget used by Login, Register and ForgotPassword forms.
//
// Why a shared component:
//   The backend requires every auth call to carry a (captchaToken, captchaAnswer) pair.
//   All three forms need exactly the same UI - image + refresh button + answer input -
//   so it lives here once and the auth forms just embed <app-captcha-input #captcha />.
//
// How parents use it:
//   1. Drop the tag into the template with a template reference variable (#captcha).
//   2. On submit, read this.captcha.getValue() to get { token, answer }.
//   3. On a server-side captcha failure, call this.captcha.refresh() to fetch a new one.
@Component({
  selector: 'app-captcha-input',
  standalone: false,
  templateUrl: './captcha-input.component.html',
  styleUrl: './captcha-input.component.scss',
})
export class CaptchaInputComponent implements OnInit {
  private captchaApi = inject(CaptchaApiService);

  // Token returned by /Captcha/generate. Kept private so parents must use getValue().
  private currentToken = '';

  // Data URL of the captcha image. Bound straight to <img [src]>.
  imageSrc = '';

  // The user types the 5-character answer into this control. Required + length 5 so the
  // submit button stays disabled until the user has filled it in.
  answerControl = new FormControl<string>('', {
    nonNullable: true,
    validators: [Validators.required, Validators.minLength(5), Validators.maxLength(5)],
  });

  // True while a fetch is in flight, so the refresh button can show a disabled state.
  loading = false;

  ngOnInit(): void {
    // Load the first challenge as soon as the form is shown.
    this.refresh();
  }

  // Fetches a fresh captcha challenge. The parent should call this:
  //   - on init (handled automatically)
  //   - when the user clicks the refresh button (handled in the template)
  //   - after the server rejects the previous attempt (parent calls captcha.refresh())
  refresh(): void {
    this.loading = true;
    // Reset value AND interaction state. Without markAsUntouched/markAsPristine the
    // control stays "touched" from the previous attempt, so after a server error
    // (e.g. wrong password) the captcha auto-refreshes and the empty value would
    // immediately trip the required/minLength validator - showing "Captcha mora imati
    // 5 karaktera" even though the user just refreshed the challenge and hasn't
    // typed anything yet.
    this.answerControl.setValue('');
    this.answerControl.markAsUntouched();
    this.answerControl.markAsPristine();
    this.captchaApi.generate().subscribe({
      next: (response) => {
        this.imageSrc = response.image;
        this.currentToken = response.token;
        this.loading = false;
      },
      error: () => {
        // If the captcha endpoint is down we still let the form load, but the answer
        // input will be empty and the parent's submit will fail server-side with an auth error.
        this.loading = false;
      },
    });
  }

  // Returns the current (token, answer) pair so the parent form can put them into
  // the login/register/forgot-password payload before sending it to the backend.
  getValue(): { token: string; answer: string } {
    return {
      token: this.currentToken,
      answer: this.answerControl.value,
    };
  }

  // Convenience getter used by parents to disable their submit button until the answer
  // looks plausible (5 characters typed). The real verification still happens on the server.
  get isValid(): boolean {
    return this.answerControl.valid;
  }
}
