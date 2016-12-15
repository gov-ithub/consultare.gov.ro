import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { BackendLoginComponent,
   MenuAsideComponent, 
   AppHeaderComponent,
   ForgotPasswordComponent, 
   ResetPasswordComponent,
    BackendHomeComponent,
  ContentEditComponent,
  BackendMasterComponent,
  ContentListComponent,
  ProposalListComponent,
  ProposalEditComponent, 
  DocumentEditComponent,
  InstitutionEditComponent,
  InstitutionListComponent } from './';
import { BackendRoutes } from './backend.routes';
import { SharedModule } from '../shared/shared.module';


@NgModule({
  imports: [
    SharedModule
  ],
  declarations: [
    BackendLoginComponent,
    MenuAsideComponent,
    AppHeaderComponent,
    ForgotPasswordComponent,
    ResetPasswordComponent,
    BackendHomeComponent,
    BackendMasterComponent,
    ContentListComponent,
    ContentEditComponent,
    ProposalListComponent,
    ProposalEditComponent,
    InstitutionEditComponent,
    InstitutionListComponent,
    DocumentEditComponent,
  ],
  entryComponents: [
    ContentEditComponent,
    ProposalEditComponent,
    DocumentEditComponent,
  ],

})
export class BackendModule { }
