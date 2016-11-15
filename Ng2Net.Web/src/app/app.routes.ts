import { Routes } from '@angular/router';
import { ContentListComponent } from './components/backend/';
import { ClaimsGuardService } from './services';
import { BackendRoutes } from './components/backend/backend.routes';
import { BackendMasterComponent } from './components/backend'
import { PublicRoutes } from './components/public/public.routes';
import { HomeMasterComponent } from './components/public';

export const ApplicationRoutes: Routes = [
      { path: 'admin', component: BackendMasterComponent, children: BackendRoutes },
      { path: '', component: HomeMasterComponent, children: PublicRoutes },
];
