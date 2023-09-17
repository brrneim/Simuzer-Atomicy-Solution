import { CommonModule } from "@angular/common";
import { HttpClientModule } from "@angular/common/http";
import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { AlertService } from "../../core/services/alert.service";
import { AuthenticationService } from "../../core/services/authentication.service";
import { BaseHttpClientService } from "../../core/services/base-http-client.service";
import { DemandService } from "../../core/services/demand.service";
import { DemandCreateComponent } from "./demand-create/demand-create.component";
import { DemandDetailComponent } from "./demand-detail/demand-detail.component";
import { DemandRoutingModule } from "./demand-routing.module";
import { DemandComponent } from "./demand.component";
import { DemandsListComponent } from "./demands-list/demands-list.component";
import {MatDatepickerModule} from '@angular/material/datepicker';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatNativeDateModule} from '@angular/material/core';

@NgModule({
  declarations: [
    DemandsListComponent,
    DemandComponent,
    DemandDetailComponent,
    DemandCreateComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    DemandRoutingModule,
    MatFormFieldModule, MatInputModule, MatDatepickerModule, MatNativeDateModule
  ],
  providers: [AuthenticationService, BaseHttpClientService, DemandService, AlertService
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class DemandModule { }
