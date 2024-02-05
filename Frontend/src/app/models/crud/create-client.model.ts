import { DisabilityGroup } from '../../enums/disability-group.enum';
import { Gender } from '../../enums/gender.enum';
import { MaritalStatus } from '../../enums/marital-status.enum';
import { Optional } from '../../shared/types';

export interface CreateClientModel {
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
    livingCityId: number;
    livingAddress: string;
    homePhoneNumber: Optional<string>;
    phoneNumber: Optional<string>;
    email: Optional<string>;
    workPlace: Optional<string>;
    position: Optional<string>;
    registrationCityId: number;
    registrationAddress: string;
    maritalStatus: MaritalStatus;
    citizenshipId: number;
    disabilityGroup: DisabilityGroup;
    isRetired: boolean;
    salary: Optional<number>;
    isLiableForMilitaryService: boolean;
}
