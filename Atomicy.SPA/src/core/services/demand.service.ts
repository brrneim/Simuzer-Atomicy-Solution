
import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, catchError, map, tap, throwError } from "rxjs";
import { ApiConfig } from "../configs/url.config";
import { DemandType } from "../models/demand-type";
import { DemandModel } from "../models/demandModel";
import { BaseHttpClientService } from "./base-http-client.service";
import { Guid } from 'guid-typescript';
import { IDemand } from '../models/demand';
import { AuthenticationService } from "./authentication.service";
import { Firm } from "../models/firm";
import { Reservation } from "../models/reservation";
@Injectable()
export class DemandService {
    constructor(private httpBaseService: BaseHttpClientService,private authService: AuthenticationService) {
      
  }
      user :any;
        getDemands(): Observable<IDemand[]> {
            this.authService.currentUser?.subscribe(user => this.user = user);
            //?isCustomer=true&id=3fa85f64-5717-4562-b3fc-2c963f66afa6
            let isCustomer = "false";
            debugger;
            if(!this.user.firm)
            {
                isCustomer = "true";
            }
            var url = ApiConfig.baseUrl + ApiConfig.baseDemandPath + ApiConfig.demandAllPath + "?isCustomer="+  isCustomer +"&id=" + this.user.id;
            console.log(url);

            return this.httpBaseService.get<IDemand[]>(url)
            .pipe(
                tap(data => console.log('All', JSON.stringify(data))),
                catchError(this.handleError)
            );
    
            }
  public getDemandTypes(): Observable<Array<DemandType>> {
    const url = ApiConfig.baseUrl + ApiConfig.baseDemandTypePath + ApiConfig.getAllDemandTypesPath;
    return this.httpBaseService.get<Array<DemandType>>(url);
  }
  public getFirms(): Observable<Array<Firm>> {
    const url = ApiConfig.baseUrl + ApiConfig.baseFirmPath + ApiConfig.getAllFirmsPath;
    return this.httpBaseService.get<Array<Firm>>(url);
  }
  createDemand(demand: DemandModel, userId: Guid) {
    debugger;
    demand.userId = userId;
    var url = ApiConfig.baseUrl + ApiConfig.baseDemandPath + ApiConfig.addDemandPath;
    return this.httpBaseService.post(url, demand);
  }
  createReservation(reservation: Reservation, userId: Guid, demandId: Guid) {

    reservation.userId = userId;
    reservation.demandId = demandId;
    const now = new Date();
    reservation.reservationDate = now;
    var url = ApiConfig.baseUrl + ApiConfig.baseReservationPath + ApiConfig.addReservationPath;
    return this.httpBaseService.post(url, reservation);
  }
  getDemandDetail(demandId: string): Observable<DemandModel> {
    const url = ApiConfig.baseUrl + ApiConfig.baseDemandPath + ApiConfig.demandInfoPath + demandId;
    return this.httpBaseService.get<DemandModel>(url);
  }
  private handleError(err: any) {
    // in a real world app, we may send the server to some remote logging infrastructure
    // instead of just logging it to the console
    let errorMessage: string;
    if (err.error instanceof ErrorEvent) {
      // A client-side or network error occurred. Handle it accordingly.
      errorMessage = `An error occurred: ${err.error.message}`;
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong,
      errorMessage = `Backend returned code ${err.status}: ${err.body.error}`;
    }
    console.error(err);
    return throwError(errorMessage);
  }
}
