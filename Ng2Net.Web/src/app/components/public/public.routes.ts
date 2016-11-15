import { Routes } from '@angular/router';
import { ClaimsGuardService } from '../../services';
import { HomeComponent } from './';

export const PublicRoutes: Routes = [
      { path: '', component: HomeComponent },
];
