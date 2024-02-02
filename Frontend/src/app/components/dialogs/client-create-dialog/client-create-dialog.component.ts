import { AsyncPipe } from '@angular/common';
import { Component, inject, OnInit, signal } from '@angular/core';
import { toSignal } from '@angular/core/rxjs-interop';
import {
    FormControl,
    FormGroup,
    FormsModule,
    ReactiveFormsModule,
    Validators
} from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCheckboxModule } from '@angular/material/checkbox';
import {
    MatOptionModule,
    provideNativeDateAdapter
} from '@angular/material/core';
import { MatDatepickerModule } from '@angular/material/datepicker';
import {
    MAT_DIALOG_DATA,
    MatDialogModule,
    MatDialogRef
} from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { Observer } from 'rxjs';
import {
    DisabilityGroup,
    getDisabilityGroupName
} from '../../../enums/disability-group.enum';
import { Gender, getGenderName } from '../../../enums/gender.enum';
import {
    getMaritalStatusName,
    MaritalStatus
} from '../../../enums/marital-status.enum';
import { Client } from '../../../models/client.model';
import { CreateClientModel } from '../../../models/crud/create-client.model';
import { CitizenshipService } from '../../../services/citizenship.service';
import { CityService } from '../../../services/city.service';
import { ClientService } from '../../../services/client.service';
import { maxDateFilter } from '../../../shared/date-filters';
import { getEnumMap } from '../../../shared/enum.helper';

@Component({
    selector: 'app-client-view-dialog',
    standalone: true,
    imports: [
        MatDialogModule,
        MatFormFieldModule,
        FormsModule,
        ReactiveFormsModule,
        MatDatepickerModule,
        MatInputModule,
        MatButtonModule,
        MatSelectModule,
        MatOptionModule,
        AsyncPipe,
        MatCheckboxModule
    ],
    providers: [provideNativeDateAdapter()],
    templateUrl: './client-create-dialog.component.html',
    styleUrl: './client-create-dialog.component.scss'
})
export class ClientCreateDialog implements OnInit {
    private readonly dialogRef = inject(MatDialogRef<ClientCreateDialog>);
    private readonly cityService = inject(CityService);
    private readonly citizenshipService = inject(CitizenshipService);
    private readonly clientService = inject(ClientService);

    public readonly client: Client | undefined = inject(MAT_DIALOG_DATA);

    public readonly birthdayFilter = maxDateFilter(new Date());
    public readonly sexOptions = getEnumMap(Gender, getGenderName);
    public readonly maritalStatusOptions = getEnumMap(
        MaritalStatus,
        getMaritalStatusName
    );
    public readonly disabilityGroupOptions = getEnumMap(
        DisabilityGroup,
        getDisabilityGroupName
    );
    public readonly cities = toSignal(this.cityService.cities$);
    public readonly citizenship = toSignal(
        this.citizenshipService.citizenship$
    );

    public inProcess = signal(false);

    public readonly form = new FormGroup({
        firstName: new FormControl('', [
            Validators.required,
            Validators.pattern(/^[А-Я][а-я]+$/)
        ]),
        lastName: new FormControl('', [
            Validators.required,
            Validators.pattern(/^[А-Я][а-я]+$/)
        ]),
        patronymic: new FormControl('', [
            Validators.required,
            Validators.pattern(/^[А-Я][а-я]+$/)
        ]),
        birthDate: new FormControl<Date>(null!, [
            Validators.required,
            Validators.max(Date.now())
        ]),
        sex: new FormControl(Gender.Undefined, [Validators.required]),
        passport: new FormControl('', [
            Validators.required,
            Validators.pattern(/^[A-Z]{2}[0-9]{7}$/)
        ]),
        passportIssueDate: new FormControl<Date>(null!, [
            Validators.required,
            Validators.max(Date.now())
        ]),
        passportIssuer: new FormControl('', [Validators.required]),
        identificationNumber: new FormControl('', [
            Validators.required,
            Validators.pattern(/^[0-9A-Z]{14}$/)
        ]),
        birthPlace: new FormControl('', [Validators.required]),
        livingCity: new FormControl(-1, [Validators.required]),
        livingAddress: new FormControl('', [Validators.required]),
        homePhoneNumber: new FormControl('', [
            Validators.pattern(/^[0-9]{7}$/)
        ]),
        phoneNumber: new FormControl('', [Validators.pattern(/\+?[0-9]{12}/)]),
        email: new FormControl('', [Validators.email]),
        workPlace: new FormControl(''),
        position: new FormControl(''),
        registrationCity: new FormControl(-1, [Validators.required]),
        registrationAddress: new FormControl('', [Validators.required]),
        maritalStatus: new FormControl(MaritalStatus.Single, [
            Validators.required
        ]),
        citizenship: new FormControl(-1, [Validators.required]),
        disabilityGroup: new FormControl(DisabilityGroup.None, [
            Validators.required
        ]),
        isRetired: new FormControl(false),
        salary: new FormControl(0, [
            Validators.min(0),
            Validators.pattern(/^[0-9]+(\.[0-9]{0,2})?$/)
        ]),
        isLiableForMilitaryService: new FormControl(false)
    });

    public ngOnInit(): void {
        this.dialogRef.updateSize('600px');

        if (this.client === undefined) {
            return;
        }

        for (const key in this.client) {
            if (key in this.form.controls) {
                this.form.controls[key].setValue(this.client[key]);
            }
        }
        this.form.controls.livingCity.setValue(this.client.livingCity.id);
        this.form.controls.passport.setValue(
            this.client.passportSeries + this.client.passportNumber
        );
        this.form.controls.registrationCity.setValue(
            this.client.registrationCity.id
        );
        this.form.controls.citizenship.setValue(this.client.citizenship.id);
    }

    public close(): void {
        this.dialogRef.close();
    }

    public create(): void {
        if (this.form.invalid) return;

        this.inProcess.set(true);

        const client: CreateClientModel = {
            firstName: this.form.value.firstName!,
            lastName: this.form.value.lastName!,
            patronymic: this.form.value.patronymic!,
            birthDate: this.form.value.birthDate!,
            gender: this.form.value.sex!,
            passportSeries: this.form.value.passport!.slice(0, 2),
            passportNumber: this.form.value.passport!.slice(2),
            passportIssueDate: this.form.value.passportIssueDate!,
            passportIssuer: this.form.value.passportIssuer!,
            identificationNumber: this.form.value.identificationNumber!,
            birthPlace: this.form.value.birthPlace!,
            livingCityId: this.form.value.livingCity!,
            livingAddress: this.form.value.livingAddress!,
            homePhoneNumber: this.form.value.homePhoneNumber,
            phoneNumber: this.form.value.phoneNumber,
            email: this.form.value.email,
            workPlace: this.form.value.workPlace,
            position: this.form.value.position,
            registrationCityId: this.form.value.registrationCity!,
            registrationAddress: this.form.value.registrationAddress!,
            maritalStatus: this.form.value.maritalStatus!,
            citizenshipId: this.form.value.citizenship!,
            disabilityGroup: this.form.value.disabilityGroup!,
            isRetired: this.form.value.isRetired!,
            salary: this.form.value.salary,
            isLiableForMilitaryService:
                this.form.value.isLiableForMilitaryService!
        };

        const obj:
            | Partial<Observer<any>>
            | ((value: void) => void)
            | undefined = {
            next: () => {
                this.dialogRef.close();
            },
            error: err => {
                this.showErrors(
                    err.error as {
                        propertyName: string;
                        errorMessage: string;
                    }[]
                );
                console.log(err);
            },
            complete: () => {
                this.inProcess.set(false);
            }
        };

        if (this.client === undefined) {
            this.clientService.createClient(client).subscribe(obj);
        } else {
            this.clientService.edit(this.client.id, client).subscribe(obj);
        }
    }

    private showErrors(
        errors: { propertyName: string; errorMessage: string }[]
    ): void {
        const controlsMap: Record<string, string> = {
            passportSeries: 'passport',
            passportNumber: 'passport',
            citizenshipId: 'citizenship',
            registrationCityId: 'registrationCity',
            livingCityId: 'livingCity',
            gender: 'sex'
        };

        if (Array.isArray(errors) && errors.length > 0) {
            const formErrors: Record<string, boolean> = {};

            for (const error of errors) {
                const propertyName =
                    error.propertyName[0].toLowerCase() +
                    error.propertyName.slice(1);

                const controlName = controlsMap[propertyName] || propertyName;
                // @ts-ignore
                this.form.controls[controlName]?.setErrors({
                    serverError: true
                });
                formErrors[controlName] = true;
            }

            this.form.setErrors(formErrors);
            this.form.markAllAsTouched();
            console.log(this.form);
        }
    }
}
