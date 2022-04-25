import { UserTypeEnum } from "./user-type-enum";

export class UserFilterModel {
  name: string;
  cpf: string;
  email: string;
  type: UserTypeEnum;
  status: boolean | number;
  password: string;

  constructor() {
    this.type = UserTypeEnum.Todos;
    this.status = -1;
  }
}
