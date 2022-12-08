import { Component, OnInit } from '@angular/core';
import { AuthUser } from '../_models/app-user';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css'],
})
export class NavbarComponent {
  authUser: AuthUser = { username: 'cmorby0', password: 'P@$$w0rd1' };

  constructor(public accountService: AccountService) { }

  login() {
    this.accountService.login(this.authUser).subscribe();
  }
}
