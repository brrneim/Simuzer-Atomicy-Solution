import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Params } from '@angular/router';
import { BehaviorSubject, Observable, map } from 'rxjs';
import { DemandType } from '../../../core/models/demand-type';
import { DemandModel } from '../../../core/models/demandModel';
import { DemandService } from '../../../core/services/demand.service';
import { Firm } from 'src/core/models/firm';
import { Guid } from 'guid-typescript';
import { AuthenticationService } from 'src/core/services/authentication.service';
import { AlertService } from 'src/core/services/alert.service';

@Component({
  selector: 'app-demand-detail',
  templateUrl: './demand-detail.component.html',
  styleUrls: ['./demand-detail.component.css']
})
export class DemandDetailComponent implements OnInit {
  detailDemandForm: any;
  reservationForm: any;
  loading = false;
  submitted = false;
  demandModel = new BehaviorSubject<DemandModel>(new DemandModel());
  demandModel$!: Observable<DemandModel>;
  params!: Params;
  demandTypes: DemandType[] = [];
  selectedDemandType: DemandType | undefined;
  firms: Firm[] = [];
  router: any;
  demandId: Guid | undefined;
  constructor(
    private formBuilder: FormBuilder,
    private activatedRoute: ActivatedRoute,
    private demandService: DemandService,
    private authService: AuthenticationService,
    private alertService: AlertService
  ) {
    this.demandModel$ = this.demandModel.asObservable();
  }

  ngOnInit() {

    this.activatedRoute.params.subscribe((params: any) => {
      this.params = params;
      this.getDemandTypes();
      this.getFirms();
      this.getDemandDetail(params.id);
      this.demandId = params.id;
      

      this.detailDemandForm = this.formBuilder.group({
        demandTypeId: ['', Validators.required],
        from: ['', Validators.required],
        to: ['', Validators.required],
        note: ['']
      });

      this.reservationForm = this.formBuilder.group({
        firmId: ['', Validators.required],
        carryDate: ['', Validators.required],
        note: ['']
      });
    });
  }

  public getDemandTypes(): void {
    this.demandService.getDemandTypes().subscribe((demandTypes: DemandType[]) => {
      this.demandTypes = demandTypes;
    });
  }
  public getFirms(): void {
    this.demandService.getFirms().subscribe((firms: Firm[]) => {
      this.firms = firms;
    });
  }
  public getDemandDetail(demandId: string): void
  {
  
    this.demandService.getDemandDetail(demandId)  
    .subscribe((demandModel: DemandModel) => {
      debugger;
      this.demandModel.next(demandModel);
      this.selectedDemandType = this.demandTypes.find(a => a.demandTypeId == demandModel.demandTypeId);
    });
  }

  saveReservation() {
    this.submitted = true;

    // stop here if form is invalid
    if (this.reservationForm.invalid) {
      return;
    }

    this.loading = true;
    this.demandService.createReservation(this.reservationForm.value,this.userId,this.demandId!).subscribe((res) => {
      debugger;
      if (res) {
        this.reservationForm.markAsPristine();
        this.reservationForm.markAsUntouched();
        this.loading = false;
        alert("Reservasyonunuz başarıyla oluşturuldu.");
        
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

  get f() { return this.detailDemandForm.controls; }
  get m() { return this.reservationForm.controls; }


  messages = [
    { text: "bla", authorId: 'Domka' }
  ];
  textareaValue = '';
  isOpen = false;

  connection = null;

 

  openChat() {
    this.isOpen = true;
  }

  closeChat() {
    this.isOpen = false;
  }

  sendMessage() {
    if (this.textareaValue.trim() !== "") {
       this.textareaValue = '';
    }
  }
}
