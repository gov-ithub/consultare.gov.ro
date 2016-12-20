import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { UserAccountService, HttpClient } from '../../../services';
import '../_assets/js/app.js';

@Component({
  selector: 'app-backend-master',
  templateUrl: './backend-master.component.html',
  styleUrls: ['./backend-master.component.css', '../_assets/css/AdminLTE.css', '../_assets/css/skins/skin-black-light.css', '../_assets/css/Custom.css' ],
  encapsulation: ViewEncapsulation.None
})
export class BackendMasterComponent implements OnInit {

  constructor(private userAccountService: UserAccountService, private http: HttpClient) { }

  ngOnInit() {
  }

}
