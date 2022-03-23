import { UserTypeEnum } from "./user-type-enum";

export interface UserModel {
  id: string;
  name: string;
  cpf: string;
  email: string;
  type: UserTypeEnum;
  status: boolean;
  password: string;
}
