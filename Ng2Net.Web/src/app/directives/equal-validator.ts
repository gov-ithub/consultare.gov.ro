import { Directive, forwardRef, Input } from '@angular/core';
import { Validator, AbstractControl, NG_VALIDATORS } from '@angular/forms';

@Directive({
    selector: '[validateEqual][formControlName],[validateEqual][formControl],[validateEqual][ngModel]',
    providers: [
        { provide: NG_VALIDATORS, useExisting: forwardRef(() => EqualValidatorDirective), multi: true }
    ]
})
export class EqualValidatorDirective implements Validator {
 
    subscribedToChild: boolean;

    @Input()
    public validateEqual: string;
    @Input()
    public reverse: string;

    constructor() {
    }

    private get isReverse() {
        if (!this.reverse) return false;
        return this.reverse === 'true' ? true : false;
    }

    validate(c: AbstractControl): { [key: string]: any } {
        // self value
        let v = c.value;
        // control vlaue
        let e = c.root.get(this.validateEqual);
        
        if (!this.subscribedToChild)
            e.valueChanges.subscribe(() => { c.updateValueAndValidity(); } );
        
        this.subscribedToChild = true;
        // value not equal
        if (e && v !== e.value && !this.isReverse) {
          return {
            validateEqual: false
          };
        }

        // value equal and reverse
        if (e && v === e.value && this.isReverse) {
            delete e.errors['validateEqual'];
            if (!Object.keys(e.errors).length) e.setErrors(null);
        }

        // value not equal and reverse
        if (e && v !== e.value && this.isReverse) {
            e.setErrors({
                validateEqual: false
            });
        }

        return null;
    }
}
