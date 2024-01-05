import { UserRoleDto } from "./userRoleDto";

type UserDto = {
  login: string;
  password: string;
  fullName: string;
  role: UserRoleDto | undefined;
};

type UserProps = {
  login: string;
};

export { type UserDto, type UserProps };
