import { UserRoleDto } from "./userRoleDto";

export type UserDto = {
  fullName: string;
  login: string;
  password: string;
  role: UserRoleDto | number | undefined;
};

export function isUserDto(obj: UserDto): obj is UserDto {
  return (
    "fullName" in obj && "login" in obj && "password" in obj && "role" in obj
  );
}
