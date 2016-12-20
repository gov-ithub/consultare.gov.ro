import { Injectable } from '@angular/core';
import { CanActivate, Router, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';

import { UserAccountService } from '../useraccount/user-account.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Injectable()
export class ClaimsGuardService implements CanActivate {

  constructor(private userAccountService: UserAccountService, private router: Router, private modalService: NgbModal) {
   }

   canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
    ) {
    let obs = this.userAccountService.getCurrentUser(true);
     return obs.map((result) => {
      let retValue = true;
      route.data['claims'].forEach(x => {
        retValue = retValue && (result !== null && result.claims[x] === 'true'); 
      });
      if (!retValue) {
            this.userAccountService.redirectTo = route.url.toString();
            if (result)
              this.userAccountService.authError = 'Nu aveti suficiente drepturi pentru a accesa pagina dorita';
            this.router.navigate([route.parent.url + '/login']);          
      } else {
        this.userAccountService.authError = undefined;
      } 
      return retValue;
    });
  }
}
