import { UserDto } from "../models/users/userDto";

enum STORAGE_KEY 
{
    user = "USER"
}

function getUser(): UserDto|undefined
{
    const user = window.localStorage.getItem(STORAGE_KEY.user)
    let result: UserDto = user ? JSON.parse(user) : undefined
    return result
}

function setUser(user: UserDto): void
{
    window.localStorage.setItem(STORAGE_KEY.user, JSON.stringify(user));
}

export {
    getUser,
    setUser
}