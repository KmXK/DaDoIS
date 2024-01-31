import { DatePipe, KeyValuePipe } from '@angular/common';
import { Component, inject } from '@angular/core';
import { MatButton } from '@angular/material/button';
import {
    MAT_DIALOG_DATA,
    MatDialogModule,
    MatDialogRef
} from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { getDisabilityGroupName } from '../../../enums/disability-group.enum';
import { getGenderName } from '../../../enums/gender.enum';
import { getMaritalStatusName } from '../../../enums/marital-status.enum';
import { Client } from '../../../models/client.model';

@Component({
    selector: 'app-client-view-dialog',
    standalone: true,
    imports: [
        MatDialogModule,
        MatFormFieldModule,
        MatButton,
        DatePipe,
        KeyValuePipe
    ],
    templateUrl: './client-view-dialog.component.html',
    styleUrl: './client-view-dialog.component.scss'
})
export class ClientViewDialog {
    private readonly dialogRef = inject(MatDialogRef<ClientViewDialog>);
    public readonly client = inject<Client>(MAT_DIALOG_DATA);

    public readonly clientsData = this.mapData(this.client);

    constructor() {
        this.dialogRef.updateSize('600px');
    }

    public close(): void {
        this.dialogRef.close();
    }

    private mapData(client: Client): [string, string | null | undefined][] {
        return [
            ['Фамилия', client.lastName],
            ['Имя', client.firstName],
            ['Отчество', client.patronymic],
            [
                'Дата рождения',
                new DatePipe('en-US').transform(
                    client.birthDate,
                    'dd.MM.yyyy г.'
                )!
            ],
            ['Пол', getGenderName(client.gender)],
            ['Номер паспорта', client.passportSeries + client.passportNumber],
            [
                'Дата выдачи',
                new DatePipe('en-US').transform(
                    client.passportIssueDate,
                    'dd.MM.yyyy г.'
                )!
            ],
            ['Выдан', client.passportIssuer],
            ['Идентификационный номер', client.identificationNumber],
            ['Место рождения', client.birthPlace],
            ['Город факт. проживания', client.livingCity.name],
            ['Адрес факт. проживания', client.livingAddress],
            ['Домашний телефон', client.homePhoneNumber],
            ['Мобильный телефон', client.phoneNumber],
            ['E-mail', client.email],
            ['Место работы', client.workPlace],
            ['Должность', client.position],
            ['Город прописки', client.registrationCity.name],
            ['Адрес прописки', client.registrationAddress],
            ['Семейное положение', getMaritalStatusName(client.maritalStatus)],
            ['Гражданство', client.citizenship.name],
            ['Инвалидность', getDisabilityGroupName(client.disabilityGroup)],
            ['Пенсионер', client.isRetired ? 'Да' : 'Нет'],
            ['Ежемесячный доход', client.salary?.toString()],
            [
                'Военнообязанный',
                client.isLiableForMilitaryService ? 'Да' : 'Нет'
            ]
        ];
    }
}
