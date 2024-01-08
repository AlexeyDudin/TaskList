import { UserDto } from "../models/users/userDto";

enum STORAGE_KEY {
  user = "USER",
}

function getUserFromStorage(): UserDto | undefined {
  const user = window.localStorage.getItem(STORAGE_KEY.user);
  let result: UserDto = user ? JSON.parse(user) : undefined;
  return result;
}

function setUserToStorage(user: UserDto | undefined): void {
  if (user === undefined) window.localStorage.removeItem(STORAGE_KEY.user);
  else window.localStorage.setItem(STORAGE_KEY.user, JSON.stringify(user));
}

export { getUserFromStorage, setUserToStorage };
