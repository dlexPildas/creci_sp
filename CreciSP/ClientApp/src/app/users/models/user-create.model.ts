import { UserTypeEnum } from "./user-type-enum";

export class UserCreateModel {
  id: string;
  name: string;
  cpf: string;
  email: string;
  type: UserTypeEnum;
  status: boolean;
}
