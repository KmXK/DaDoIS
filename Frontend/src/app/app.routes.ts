import { Routes } from '@angular/router';
import { AccountListComponent } from './components/account-list/account-list.component';
import { ClientListComponent } from './components/client-list/client-list.component';
import { DepositListComponent } from './components/deposit-list/deposit-list.component';
import { DepositPlanListComponent } from './components/deposit-plan-list/deposit-plan-list.component';
import { TransactionListComponent } from './components/transaction-list/transaction-list.component';

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
        path: 'accounts',
        component: AccountListComponent
    },
    {
        path: 'transactions',
        component: TransactionListComponent
    },
    {
        path: '*',
        redirectTo: 'clients'
    }
];
