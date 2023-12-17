import { UserRoleDto } from "./userRoleDto";

export type UserDto = {
    login: string;
    password: string;
    fullName: string;
    role: UserRoleDto;
};