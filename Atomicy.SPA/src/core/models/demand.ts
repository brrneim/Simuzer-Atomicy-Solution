import { Guid } from "guid-typescript";

export interface IDemand {
    demandId: Guid;
    demandTypeId: Guid;
    demandType: string;
    from: string;
    to: string;
    note: string;
    userId: Guid;
    demandDate: Date;
    completed: Boolean
  }
