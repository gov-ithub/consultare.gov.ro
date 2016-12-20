import { Component, Input, ApplicationRef } from '@angular/core';
import { Router } from '@angular/router';
import { ContentService, UserAccountService } from '../../../services';
import { HtmlContentPipe } from '../../../directives';
import { ApplicationRoutes } from '../../../app.routes';
import { BackendModule } from '../../backend/backend.module';
import { PublicModule } from '../../public/public.module';
import { DomSanitizer, SafeHtml } from '@angular/platform-browser';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { PublicSignupComponent } from '../../../components/public'

@Component({
  selector: 'app-html',
  templateUrl: './html.component.html',
  styleUrls: ['./html.component.css']
})
export class HtmlComponent {

  @Input('contentName')
  private contentName: string;
  private editorOpen: boolean = false;
  private saveSuccess: boolean = false;
  private get content(){
    return this.sanitizer.bypassSecurityTrustHtml(new HtmlContentPipe().transform(this.contentName, this.contentService.htmlContent));
  }

  constructor(private contentService: ContentService, 
  private router: Router, 
  private sanitizer: DomSanitizer,
  private modalService: NgbModal,
  private appRef: ApplicationRef,
  private userService: UserAccountService ) { 
    (<any>window).angular = (<any>window).angular || {parentComponent: this};
  }

  navigateUrl(url: string) {
    this.router.navigateByUrl(url);
    this.appRef.tick();
  }

  openSignUp() {
    let component = this.modalService.open(PublicSignupComponent, { keyboard: false });
    this.appRef.tick();
  }
  openEditor() {
    if (this.userService.currentUser && this.userService.currentUser.claims &&
    this.userService.currentUser.claims['editHtmlContent'] === 'true') {
      this.editorOpen=true;
      $('body').css('margin-bottom','365px');
    }
  }

  closeEditor() {
      this.editorOpen=false;
      $('body').css('margin-bottom','inherit');
  }

  quickSaveContent() {  
    this.contentService.quickSaveHtmlContent(this.contentName, this.contentService.htmlContent[this.contentName]).subscribe(res=> {
      if (res === true) {
        this.saveSuccess=true;
        setTimeout(()=>{ this.saveSuccess = false; }, 3000);
      } }); 
  }
}