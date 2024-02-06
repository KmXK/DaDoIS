import { Routes } from '@angular/router';
import { ClientListComponent } from './components/client-list/client-list.component';
import { DepositListComponent } from './components/deposit-list/deposit-list.component';
import { DepositPlanListComponent } from './components/deposit-plan-list/deposit-plan-list.component';

export const routes: Routes = [
    {
        path: 'clients',
        component: ClientListComponent
    },
    {
        path: 'plans',
        component: DepositPlanListComponent
    },
    {
        path: 'deposits',
        component: DepositListComponent
    },
    {
        path: '*',
        redirectTo: 'clients'
    }
];
