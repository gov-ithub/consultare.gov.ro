import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../shared/shared.module';
import { ScrollSpyModule } from 'ng2-scrollspy';
import { HomeComponent, HomeMasterComponent, NavbarComponent, PublicLoginComponent } from './';

@NgModule({
  imports: [
    SharedModule,
    ScrollSpyModule.forRoot()
  ],
  declarations: [
    HomeComponent,
    HomeMasterComponent,
    NavbarComponent
  ],
  entryComponents: [
    PublicLoginComponent
  ]
})
export class PublicModule { }
