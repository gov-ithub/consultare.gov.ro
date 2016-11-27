import { Routes } from '@angular/router';
import { BackendLoginComponent, ContentListComponent, ForgotPasswordComponent, ResetPasswordComponent, ProposalListComponent, ProposalEditComponent, BackendHomeComponent } from './';
import { ClaimsGuardService } from '../../services';

export const BackendRoutes: Routes = [
      { path: 'login', component: BackendLoginComponent },
      { path: 'forgot-password', component: ForgotPasswordComponent },
      { path: 'reset-password/:userId', component: ResetPasswordComponent },
      {
            path: '', component: BackendHomeComponent, data: { claims: ['adminLogin'] },
            canActivate: [ClaimsGuardService]
      }, {
            path: 'content-list', component: ContentListComponent, data: { claims: ['editHtmlContent'] },
            canActivate: [ClaimsGuardService]
      }, {
            path: 'proposal-list', component: ProposalListComponent, data: { claims: ['editHtmlContent'] },
            canActivate: [ClaimsGuardService]
      }, {
            path: 'proposal-edit', component: ProposalEditComponent, data: { claims: ['editHtmlContent'] },
            canActivate: [ClaimsGuardService]
      }
];
