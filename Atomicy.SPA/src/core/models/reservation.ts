import { Guid } from "guid-typescript";

export class Reservation {
  reservationId!: Guid;
  demandId!: Guid;
  userId!: Guid;
  firmId!: Guid;
  note!:string;
  reservationDate!: Date;
  carryDate!: Date;
  completed!: boolean;
}
