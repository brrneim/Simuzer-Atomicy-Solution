import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { DemandType } from '../../../core/models/demand-type';
import { DemandService } from '../../../core/services/demand.service';
import { AuthenticationService } from 'src/core/services/authentication.service';
import { Guid } from 'guid-typescript';

@Component({
  selector: 'app-demand-create',
  templateUrl: './demand-create.component.html',
  styleUrls: ['./demand-create.component.css']
})
export class DemandCreateComponent implements OnInit {
  createDemandForm: any;
  loading = false;
  submitted = false;
  demandTypes: DemandType[] = [];

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private demandService: DemandService,
    private authService:AuthenticationService
  ) {
  }

  ngOnInit() {
    this.createDemandForm = this.formBuilder.group({
      demandTypeId: ['', Validators.required],
      from: ['', Validators.required],
      to: ['', Validators.required],
      note: ['']
    });
    this.getDemandTypes();
  }

  public getDemandTypes(): void {
    this.demandService.getDemandTypes().subscribe((demandTypes: DemandType[]) => {
      this.demandTypes = demandTypes;
    });
  }

  get f() { return this.createDemandForm.controls; }

  onSubmit() {
    this.submitted = true;

    // stop here if form is invalid
    if (this.createDemandForm.invalid) {
      return;
    }

    this.loading = true;
    this.demandService.createDemand(this.createDemandForm.value,this.userId).subscribe((res) => {
      if (res) {
        this.createDemandForm.markAsPristine();
        this.createDemandForm.markAsUntouched();
        this.loading = false;
        this.router.navigate(['/demand/demands']);
      }
    }, error => {
      if (error) {
        this.loading = false;
      }
    })
  }
  user: any; 
  get userId(): Guid {
    debugger;
   this.authService.currentUser?.subscribe(user => this.user = user);
    if (this.authService.currentUser) {
      this.authService.currentUser?.subscribe(user => this.user = user);
      return this.user == undefined || this.user == null  ? false : this.user.id;
    }
    return Guid.create();
  }
}
