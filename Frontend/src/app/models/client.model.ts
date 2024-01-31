import { Gender } from '../enums/gender.enum';
import { Citizenship } from './citizenship.model';
import { City } from './city.model';

export interface Client {
    id: string;
    firstName: string;
    lastName: string;
    patronymic: string;
    birthDate: Date;
    gender: Gender;
    passportSeries: string;
    passportNumber: string;
    passportIssueDate: Date;
    passportIssuer: string;
    identificationNumber: string;
    birthPlace: string;
    livingCity: City;
    livingAddress: string;
    homePhoneNumber: string | null;
    phoneNumber: string | null;
    email: string | null;
    workPlace: string | null;
    position: string | null;
    registrationCity: City;
    registrationAddress: string;
    maritalStatus: number;
    citizenship: Citizenship;
    disabilityGroup: number;
    isRetired: boolean;
    salary: number | null;
    isLiableForMilitaryService: boolean;
}
