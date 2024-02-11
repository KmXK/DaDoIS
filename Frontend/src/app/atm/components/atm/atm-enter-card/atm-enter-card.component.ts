import { Component, inject } from '@angular/core';
import {
    FormControl,
    FormGroup,
    FormsModule,
    ReactiveFormsModule,
    Validators
} from '@angular/forms';
import { MatButton } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { AtmService } from '../../../services/atm.service';

@Component({
    selector: 'app-atm-enter-card',
    standalone: true,
    imports: [
        MatFormFieldModule,
        MatInputModule,
        FormsModule,
        MatButton,
        ReactiveFormsModule
    ],
    templateUrl: './atm-enter-card.component.html',
    styleUrl: './atm-enter-card.component.scss'
})
export class AtmEnterCardComponent {
    private readonly service = inject(AtmService);
    public error = '';

    public readonly formGroup = new FormGroup({
        cardNumber: new FormControl('', [
            Validators.required,
            Validators.pattern(/[0-9]{16}/)
        ]),
        pin: new FormControl('', [
            Validators.required,
            Validators.pattern(/[0-9]{4}/)
        ])
    });

    enterCard() {
        if (this.formGroup.invalid) {
            return;
        }

        this.error = '';

        const value = {
            cardNumber: this.formGroup.value.cardNumber!,
            pin: +this.formGroup.value.pin!
        };

        this.service.enterCard(value).subscribe({
            error: error => {
                this.error = error.errorMessage;
            }
        });
    }
}
