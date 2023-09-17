import { ChangeDetectionStrategy, Component } from '@angular/core';
import { Subscription } from 'rxjs';
import { IDemand } from 'src/core/models/demand';
import { DemandService } from 'src/core/services/demand.service';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/core/services/authentication.service';

@Component({
  selector: 'app-demands-list',
  templateUrl: './demands-list.component.html',
  styleUrls: ['./demands-list.component.css']
})
export class DemandsListComponent {
  pageTitle = 'Talepler';
  errorMessage: string = '';
  sub!: Subscription;
  demands: IDemand[] = [];
  constructor(private demandService: DemandService, private router: Router, private authService: AuthenticationService) { }
  ngOnInit(): void {
    this.sub = this.demandService.getDemands().subscribe({
      next: demands => {
        this.demands = demands;   
      },
      error: err => this.errorMessage = err
    });
  }
 
  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }
  newDemand(): void {
   // [routerLink]="['/demand/demandDetail', demand.demandId]"
   this.router.navigate(['/demand/demand-create']);
  }
  user: any; 
  get isFirm(): boolean {
    debugger;
   this.authService.currentUser?.subscribe(user => this.user = user);
    if (this.authService.currentUser) {
      this.authService.currentUser?.subscribe(user => this.user = user);
      return this.user == undefined || this.user == null  ? false : this.user.firm;
    }
    return false;
  }
}
