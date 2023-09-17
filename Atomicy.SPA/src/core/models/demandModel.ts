import { Guid } from "guid-typescript";

export class DemandModel {
  demandId!: Guid;
  demandTypeId!: Guid;
  from!: string;
  to!: string;
  note!: string;
  userId!: Guid;
  demandDate!: Date;
  completed!: boolean;
  
  
 // conversations! : IConversation[];
}

export class IConversation {
  demandId!: Guid;
  demandConversationId!: Guid;
  userId!: Guid;
  firmId!: Guid;
  customerMessage!:string;
  firmMessage!: string;
  date!: Date;
  read!: boolean;
}


