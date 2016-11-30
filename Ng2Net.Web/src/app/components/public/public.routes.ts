import { Routes } from '@angular/router';
import { ClaimsGuardService } from '../../services';
import { HomeComponent, HomeMasterComponent } from './';

export const PublicRoutes: Routes = [
      { path: '', component: HomeMasterComponent, children: [
      { path: '', component: HomeComponent }
]} ];
