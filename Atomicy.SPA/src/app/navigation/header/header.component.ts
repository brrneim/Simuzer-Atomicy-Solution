import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { User } from 'src/core/models/user';
import { AuthenticationService } from 'src/core/services/authentication.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})

export class HeaderComponent implements OnInit {
  @Output() public sidenavToggle = new EventEmitter();
  get isLoggedIn(): boolean {

    return this.authService.isLoggedIn();
  }
  user: any; 
  get userName(): string {
   this.authService.currentUser?.subscribe(user => this.user = user);
    if (this.authService.currentUser) {
      this.authService.currentUser?.subscribe(user => this.user = user);
      return this.user == undefined || this.user == null  ? '' : this.user['userName'];
    }
    return '';
  }
  
  constructor(private router: Router, private authService: AuthenticationService) { }
  ngOnInit() {
  }
  public onToggleSidenav = () => {
    this.sidenavToggle.emit();
  }
  logOut(): void {
    debugger;
    this.authService.logout();
    this.router.navigate(['/']);
  }
}
