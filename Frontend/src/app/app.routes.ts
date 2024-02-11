import { Routes } from '@angular/router';
import { AtmComponent } from './atm/components/atm/atm.component';
import { AccountListComponent } from './components/account-list/account-list.component';
import { AdminPanelComponent } from './components/admin-panel.component';
import { CardListComponent } from './components/card-list/card-list.component';
import { ClientListComponent } from './components/client-list/client-list.component';
import { CreditListComponent } from './components/credit-list/credit-list.component';
import { CreditPlanListComponent } from './components/credit-plan-list/credit-plan-list.component';
import { DepositListComponent } from './components/deposit-list/deposit-list.component';
import { DepositPlanListComponent } from './components/deposit-plan-list/deposit-plan-list.component';
import { HomeComponent } from './components/home/home.component';
import { TransactionListComponent } from './components/transaction-list/transaction-list.component';

export const routes: Routes = [
    {
        path: 'atm',
        component: AtmComponent
    },
    {
        path: '',
        component: AdminPanelComponent,
        children: [
            {
                path: '',
                component: HomeComponent
            },
            {
                path: 'clients',
                component: ClientListComponent
            },
            {
                path: 'deposit-plans',
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
                path: 'credit-plans',
                component: CreditPlanListComponent
            },
            {
                path: 'credits',
                component: CreditListComponent
            },
            {
                path: 'cards',
                component: CardListComponent
            }
        ]
    },
    {
        path: '*',
        redirectTo: ''
    }
];
