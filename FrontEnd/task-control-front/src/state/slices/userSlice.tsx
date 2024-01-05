import { PayloadAction, createSlice } from "@reduxjs/toolkit";
import { UserDto } from "../../models/users/userDto";
import {
  getUserFromStorage,
  setUserToStorage,
} from "../../modules/CacheStorage";
import { TaskManagerAPI } from "../../modules/TaskManagerAPI/TaskManagerAPI";

let userInitialState: UserDto = {
  login: "",
  password: "",
  fullName: "",
  role: undefined,
};
const stateFromMemory: UserDto | undefined = getUserFromStorage();
if (stateFromMemory !== undefined) {
  userInitialState = stateFromMemory;
}

export const UserSlice = createSlice({
  name: "user",
  initialState: userInitialState,
  reducers: {
    loginUser: (state, action: PayloadAction<{ user: UserDto }>) => {
      TaskManagerAPI.login(
        action.payload.user.login,
        action.payload.user.password
      )
        .then((user: UserDto | Response) => {
          if (user instanceof Response) {
            alert(user.status + " " + user.text());
          } else {
            state.login = user.login;
            state.fullName = user.fullName;
            state.password = user.password;
            state.role = user.role;
            setUserToStorage(state);
          }
        })
        .catch((ex) => {
          console.log(ex);
        });
      //setUserToStorage(state);
      //TODO сделать отправку данных на сервер и их обработку
      //setUserToStorage(state.login user);
    },
  },
});

export default UserSlice.reducer;
export const { loginUser } = UserSlice.actions;
