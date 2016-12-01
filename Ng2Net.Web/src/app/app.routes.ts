import { Routes } from '@angular/router';
import { ContentListComponent } from './components/backend/';
import { ClaimsGuardService } from './services';
import { BackendRoutes } from './components/backend/backend.routes';
import { PublicRoutes } from './components/public/public.routes';

export const ApplicationRoutes: Routes = [
      ...BackendRoutes,
      ...PublicRoutes
];
