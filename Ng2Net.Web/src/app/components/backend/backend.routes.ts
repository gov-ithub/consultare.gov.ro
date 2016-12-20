import { Routes } from '@angular/router';
import { BackendLoginComponent, ContentListComponent, ForgotPasswordComponent, ResetPasswordComponent, BackendHomeComponent, BackendMasterComponent, ProposalListComponent, ProposalEditComponent, InstitutionListComponent, InstitutionEditComponent } from './';
import { ClaimsGuardService } from '../../services';

export const BackendRoutes: Routes = [
      { path: 'admin', component: BackendMasterComponent, children: 

[
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
            path: 'proposal-list', component: ProposalListComponent, data: { claims: ['editProposals'] },
            canActivate: [ClaimsGuardService]
      }, {
            path: 'proposal-edit/:id', component: ProposalEditComponent, data: { claims: ['editProposals'] },
            canActivate: [ClaimsGuardService]
      }
      , {
            path: 'proposal-edit', component: ProposalEditComponent, data: { claims: ['editProposals'] },
            canActivate: [ClaimsGuardService]
      }, {
            path: 'institution-list', component: InstitutionListComponent, data: { claims: ['editProposals'] },
            canActivate: [ClaimsGuardService]
      }, {
            path: 'institution-edit/:id', component: InstitutionEditComponent, data: { claims: ['editProposals'] },
            canActivate: [ClaimsGuardService]
      }
      , {
            path: 'institution-edit', component: InstitutionEditComponent, data: { claims: ['editProposals'] },
            canActivate: [ClaimsGuardService]
      }
] }];
