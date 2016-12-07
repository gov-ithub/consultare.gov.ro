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
  ProposalEditComponent } from './';
import { BackendRoutes } from './backend.routes';
import { SharedModule } from '../shared/shared.module';
import { InstitutionEditComponent } from './institution/institution-edit/institution-edit.component';
import { InstitutionListComponent } from './institution/institution-list/institution-list.component';


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
    InstitutionListComponent
  ],
  entryComponents: [
    ContentEditComponent,
    ProposalEditComponent
  ],

})
export class BackendModule { }
