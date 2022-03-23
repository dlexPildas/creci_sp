import { RoomType } from "./room-type.model";

export class RoomFilterModel {
  number: number;
  floor: number;
  capacity: number;
  type: RoomType;
  status: boolean;

  constructor() {
    this.type = RoomType.Todos;
  }
}
