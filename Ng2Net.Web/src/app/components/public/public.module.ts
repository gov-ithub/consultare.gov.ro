import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../shared/shared.module';
import { ScrollSpyModule } from 'ng2-scrollspy';
import { HomeComponent, HomeMasterComponent, PublicSignupComponent, NavbarComponent, PublicLoginComponent, ProposalsComponent } from './';


@NgModule({
  imports: [
    SharedModule,
    ScrollSpyModule.forRoot()
  ],
  declarations: [
    HomeComponent,
    HomeMasterComponent,
    NavbarComponent,
    PublicLoginComponent,
    PublicSignupComponent,
    ProposalsComponent
  ],
  entryComponents: [
    PublicLoginComponent,
    PublicSignupComponent
  ]
})
export class PublicModule { }
