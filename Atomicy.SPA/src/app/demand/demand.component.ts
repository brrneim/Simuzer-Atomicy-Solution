import { Component, OnInit } from '@angular/core';
import { User } from '../../core/models/user';
import { AuthenticationService } from '../../core/services/authentication.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-demand',
  templateUrl: './demand.component.html',
  styleUrls: ['./demand.component.css']
})
export class DemandComponent implements OnInit {
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

}
