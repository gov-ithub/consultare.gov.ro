import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { ApplicationRoutes } from './app.routes';
import { AppComponent } from './app.component';
import { UserAccountService, HttpClient, ContentService, ClaimsGuardService } from './services';
import { CookieService } from 'angular2-cookie/services/cookies.service';
import { GlobalService } from './services/global/global.service';
import { EqualValidatorDirective } from './directives/equal-validator';
import { BackendModule } from './components/backend/backend.module';
import { HtmlComponent } from './components/shared';
import { HtmlContentPipe } from './directives';
import { CKEditorModule } from 'ng2-ckeditor';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
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
