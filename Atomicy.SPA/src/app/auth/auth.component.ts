import { Component, OnInit } from '@angular/core';
import { User } from '../../core/models/user';
import { AuthenticationService } from '../../core/services/authentication.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.css']
})
export class AuthComponent implements OnInit {
  currentUser: User | undefined;

  constructor(
    private router: Router,
    private authenticationService: AuthenticationService
  ) {
    if (this.authenticationService.currentUser) {
      this.authenticationService.currentUser.subscribe(x => this.currentUser = x);
    }
  }
  ngOnInit() { }
  logout() {
    this.authenticationService.logout();
    this.router.navigate(['/login']);
  }
}
