import { AbstractControl, ValidatorFn } from '@angular/forms';

export function uppercaseValidator(): ValidatorFn {
  return (control: AbstractControl): { [key: string]: any } | null => {
    const hasUppercase = /[A-Z]/.test(control.value);
    return hasUppercase ? null : { uppercase: true };
  };
}

export function specialCharacterValidator(): ValidatorFn {
  return (control: AbstractControl): { [key: string]: any } | null => {
    const hasSpecialCharacter = /[!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?]+/.test(control.value);
    return hasSpecialCharacter ? null : { specialCharacter: true };
  };
}

export function alphanumericValidator(): ValidatorFn {
  return (control: AbstractControl): { [key: string]: any } | null => {
    const isAlphanumeric = /^[a-zA-Z0-9]*$/.test(control.value);
    return isAlphanumeric ? null : { alphanumeric: true };
  };
}
