import { AsyncPipe } from '@angular/common';
import { Component, inject } from '@angular/core';
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
import { MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import {
    DisabilityGroup,
    getDisabilityGroupName
} from '../../../enums/disability-group.enum';
import { Gender, getGenderName } from '../../../enums/gender.enum';
import {
    getMaritalStatusName,
    MaritalStatus
} from '../../../enums/marital-status.enum';
import { CitizenshipService } from '../../../services/citizenship.service';
import { CityService } from '../../../services/city.service';
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
export class ClientCreateDialog {
    private readonly dialogRef = inject(MatDialogRef<ClientCreateDialog>);
    private readonly cityService = inject(CityService);
    private readonly citizenshipService = inject(CitizenshipService);

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

    public readonly form = new FormGroup({
        firstName: new FormControl('', [
            Validators.required,
            Validators.pattern('[А-Я][а-я]+')
        ]),
        lastName: new FormControl('', [
            Validators.required,
            Validators.pattern('[А-Я][а-я]+')
        ]),
        patronymic: new FormControl('', [
            Validators.required,
            Validators.pattern('[А-Я][а-я]+')
        ]),
        birthDate: new FormControl(new Date(), [
            Validators.required,
            Validators.max(Date.now())
        ]),
        sex: new FormControl(Gender.Undefined, [Validators.required]),
        passport: new FormControl('', [
            Validators.required,
            Validators.pattern('[A-Z]{2}[0-9]{7}')
        ]),
        passportIssueDate: new FormControl(new Date(), [
            Validators.required,
            Validators.max(Date.now())
        ]),
        passportIssuer: new FormControl('', [Validators.required]),
        identificationNumber: new FormControl('', [
            Validators.required,
            Validators.pattern('[0-9A-Z]{14}')
        ]),
        birthPlace: new FormControl('', [Validators.required]),
        livingCity: new FormControl('', [Validators.required]),
        livingAddress: new FormControl('', [Validators.required]),
        homePhoneNumber: new FormControl('', [
            Validators.pattern('\\+?[0-9]{9}')
        ]),
        phoneNumber: new FormControl('', [Validators.pattern('\\+?[0-9]{9}')]),
        email: new FormControl('', [Validators.email]),
        workPlace: new FormControl(''),
        position: new FormControl(''),
        registrationCity: new FormControl('', [Validators.required]),
        registrationAddress: new FormControl('', [Validators.required]),
        maritalStatus: new FormControl(MaritalStatus.Single, [
            Validators.required
        ]),
        citizenship: new FormControl('', [Validators.required]),
        disabilityGroup: new FormControl(DisabilityGroup.None, [
            Validators.required
        ]),
        isRetired: new FormControl(false),
        salary: new FormControl(0, [Validators.min(0)]),
        isLiableForMilitaryService: new FormControl(false)
    });

    constructor() {
        this.dialogRef.updateSize('600px');
    }

    public close(): void {
        this.dialogRef.close();
    }
}
