import { AbstractControl, ValidationErrors, ValidatorFn } from '@angular/forms';

export function isbnValidator(): ValidatorFn {
  return (control: AbstractControl): ValidationErrors | null => {
    const value = control.value;
    if (value === null || value === undefined || value === '') return null;

    const clean = String(value).replace(/[\s-]/g, '').toUpperCase();

    if (clean.length === 10 && isValidIsbn10(clean)) return null;
    if (clean.length === 13 && isValidIsbn13(clean)) return null;

    return { isbn: true };
  };
}

function isValidIsbn10(isbn: string): boolean {
  for (let i = 0; i < 9; i++) {
    if (!/[0-9]/.test(isbn[i])) return false;
  }
  const last = isbn[9];
  if (last !== 'X' && !/[0-9]/.test(last)) return false;

  let sum = 0;
  for (let i = 0; i < 9; i++) {
    sum += parseInt(isbn[i], 10) * (10 - i);
  }
  sum += last === 'X' ? 10 : parseInt(last, 10);

  return sum % 11 === 0;
}

function isValidIsbn13(isbn: string): boolean {
  if (!/^\d{13}$/.test(isbn)) return false;

  let sum = 0;
  for (let i = 0; i < 13; i++) {
    const weight = i % 2 === 0 ? 1 : 3;
    sum += parseInt(isbn[i], 10) * weight;
  }
  return sum % 10 === 0;
}
