import { Routes } from '@angular/router';
import { ClaimsGuardService } from '../../services';
import { HomeComponent, HomeMasterComponent, ProposalsPageComponent } from './';
import { HtmlPageComponent } from '../shared';

export const PublicRoutes: Routes = [
      { path: '', component: HomeMasterComponent, children: [
      { path: '', component: HomeComponent },
      { path: 'propuneri-legislative', component: ProposalsPageComponent },
      { path: 'propuneri-legislative/:arhiva', component: ProposalsPageComponent },
      { path: 'p/:url', component: HtmlPageComponent },
      { path: 'reset-password/:userId', component: HomeComponent, data: { action: 'resetPassword' } },
      { path: 'confirm-account/:userId', component: HomeComponent, data: { action: 'confirmAccount' } },
      { path: 'unsubscribe', component: HomeComponent, data: { action: 'unsubscribe' } },
]} ];
