import { AtmStateEnum } from '../enums/atm-state.enum';

type Enum<T> = {
    state: T;
};

type LoggedEnum<T> = Enum<T> & { id: string };

export type AtmState =
    | Enum<AtmStateEnum.LOGGED_OUT>
    | Enum<AtmStateEnum.ENTERING_CARD>
    | LoggedEnum<AtmStateEnum.MENU>
    | LoggedEnum<AtmStateEnum.WITHDRAW>
    | LoggedEnum<AtmStateEnum.MOBILE>
    | LoggedEnum<AtmStateEnum.BALANCE>;
