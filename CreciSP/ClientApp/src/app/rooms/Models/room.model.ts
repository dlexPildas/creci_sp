import { RoomType } from "./room-type.model";

export class RoomModel {
  id: string;
  number: number;
  floor: number;
  capacity: number;
  type: RoomType;
  status: boolean;
}
