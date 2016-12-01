import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { BackendModule } from './components/backend/backend.module';
import { SharedModule } from './components/shared/shared.module';
import { PublicModule } from './components/public/public.module';

@NgModule({
  declarations: [
    AppComponent

  ],
  imports: [
    BackendModule,
    SharedModule,
    PublicModule
  ],
  bootstrap: [AppComponent],
})
export class AppModule { }
