import { ValidatorFn, ValidationErrors, FormGroup } from "@angular/forms";

export class CustomValidators {
    static confirmPassword = (passwordKey: string, confirmPasswordKey: string): ValidatorFn => {
        return (control: FormGroup): ValidationErrors | null => {

            const password = control.get(passwordKey);
            const confirmPassword = control.get(confirmPasswordKey);
            return password && confirmPassword && password.value === confirmPassword.value ? null : { passwordMismatch: true };
        };
    }
}

