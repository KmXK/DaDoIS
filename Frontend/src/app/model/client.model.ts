import { City } from "./city.model";
import { Gender } from "./gender.model";

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
    passportIssuedBy: string;
    passportIdentificationNumber: string;
    birthPlace: string;
    cityOfResidence: City;
    addressOfResidence: string;
    homePhone: string | null;
    mobilePhone: string | null;
    email: string | null;
    placeOfWork: string | null;
    position: string | null;
    registrationCity: City;
    registrationAddress: string;
    maritalStatusId: number;
    citizenshipId: number;
    disabilityTypeId: number;
    isRetired: boolean;
    salary: number | null;
    isLiableForMilitaryService: boolean;
}