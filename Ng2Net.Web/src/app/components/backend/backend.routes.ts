import { Routes } from '@angular/router';
import { BackendLoginComponent, ContentListComponent, ForgotPasswordComponent, ResetPasswordComponent, BackendHomeComponent, BackendMasterComponent } from './';
import { ClaimsGuardService } from '../../services';

export const BackendRoutes: Routes = [
      { path: 'admin', component: BackendMasterComponent, children: 

[
      { path: 'login', component: BackendLoginComponent },
      { path: 'forgot-password', component: ForgotPasswordComponent },
      { path: 'reset-password/:userId', component: ResetPasswordComponent },
      { path: '', component: BackendHomeComponent, data: { claims: [ 'adminLogin' ] },
      canActivate: [ ClaimsGuardService ] },
      { path: 'content-list', component: ContentListComponent, data: { claims: [ 'editHtmlContent' ]},
      canActivate: [ ClaimsGuardService ] }
]}];
