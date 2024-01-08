import { PayloadAction, createSlice } from "@reduxjs/toolkit";
import { TasksDto } from "../../models/desk/tasks/tasksDto";

interface DeskState {
  desk: TasksDto;
}

const deskInitialState: DeskState = {
  desk: {
    tasks: [],
  },
};

export const DeskSlice = createSlice({
  name: "desk",
  initialState: deskInitialState,
  reducers: {
    updateDesk: (state, action: PayloadAction<{ user: TasksDto }>) => {
      const tmp: TasksDto = action.payload.user;
      state.desk = tmp;
    },
  },
});

export default DeskSlice.reducer;
export const { updateDesk } = DeskSlice.actions;
