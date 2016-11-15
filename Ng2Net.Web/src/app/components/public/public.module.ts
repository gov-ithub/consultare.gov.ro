import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../shared/shared.module';
import { HomeComponent, HomeMasterComponent } from './';

@NgModule({
  imports: [
    SharedModule
  ],
  declarations: [
    HomeComponent,
    HomeMasterComponent
  ]
})
export class PublicModule { }
