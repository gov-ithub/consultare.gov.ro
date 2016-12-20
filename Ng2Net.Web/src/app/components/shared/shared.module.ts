import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RuntimeCompiler, CompileMetadataResolver, NgModuleResolver, DirectiveResolver, PipeResolver, ElementSchemaRegistry } from '@angular/compiler';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { ApplicationRoutes } from '../../app.routes';
import { AppComponent } from '../../app.component';
import { UserAccountService, HttpClient, ProposalsService, ContentService, ClaimsGuardService, InstitutionService, PagerService } from '../../services';
import { CookieService } from 'angular2-cookie/services/cookies.service';
import { GlobalService } from '../../services/global/global.service';
import { EqualValidatorDirective } from '../../directives/equal-validator';
import { BackendModule } from '../../components/backend/backend.module';
import { PublicModule } from '../../components/public/public.module';
import { PublicRoutes } from '../../components/public/public.routes';
import { HtmlComponent } from '../../components/shared';
import { HtmlContentPipe, ToDateTimePipe } from '../../directives';
import { CKEditorModule } from 'ng2-ckeditor';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NKDatetimeModule } from 'ng2-datetime/ng2-datetime';
import { MaterialModule } from '@angular/material';
import { ReCaptchaModule } from 'angular2-recaptcha';
import { MomentModule } from 'angular2-moment';
import { HtmlPageComponent } from './html-page/html-page.component';
import { HtmlPopupComponent } from './html-popup/html-popup.component';
import { PagerComponent } from './pager/pager.component';


@NgModule({
  declarations: [
    EqualValidatorDirective,
    HtmlComponent, 
    HtmlContentPipe,
    HtmlPageComponent,
    PagerComponent,
    ToDateTimePipe,
    HtmlPopupComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    RouterModule.forRoot(ApplicationRoutes),
    NgbModule.forRoot(),
    CKEditorModule,
    NKDatetimeModule,
    MaterialModule.forRoot(),
    ReCaptchaModule,
    MomentModule,
  ],
  providers: [
     ClaimsGuardService,
     CookieService,
     UserAccountService,
     GlobalService,
     HttpClient,
     ContentService,
     InstitutionService,
     ProposalsService,
     PagerService,
  ],
  entryComponents: [
    HtmlPopupComponent,
  ],
  exports: [ 
    BrowserModule,
    FormsModule,
    HttpModule,
    RouterModule,
    NgbModule,
    CKEditorModule,
    EqualValidatorDirective,
    HtmlComponent, 
    HtmlContentPipe,
    NKDatetimeModule,
    MaterialModule,
    ReCaptchaModule,
    MomentModule,
    PagerComponent,
    ToDateTimePipe,
],
})

export class SharedModule { }
