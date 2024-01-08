import { PayloadAction, createSlice } from "@reduxjs/toolkit";
import { UserDto } from "../../models/users/userDto";
import {
  getUserFromStorage,
  setUserToStorage,
} from "../../modules/CacheStorage";

interface UserState {
  user: UserDto | undefined;
}

const userInitialState: UserState = {
  user:
    getUserFromStorage() === undefined
      ? { login: "", password: "", fullName: "", role: undefined }
      : getUserFromStorage(),
};

export const UserSlice = createSlice({
  name: "user",
  initialState: userInitialState,
  reducers: {
    loginUser: (
      state,
      action: PayloadAction<{ user: UserDto | undefined }>
    ) => {
      const tmp: UserDto | undefined = action.payload.user;
      state.user = tmp;
      setUserToStorage(tmp);
    },
  },
});

export default UserSlice.reducer;
export const { loginUser } = UserSlice.actions;
