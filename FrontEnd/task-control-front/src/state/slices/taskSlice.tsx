import { PayloadAction, createSlice } from "@reduxjs/toolkit";
import { TasksDto } from "../../models/desk/tasks/tasksDto";
import { DeskDto } from "../../models/desk/deskDto";

interface DeskState {
  desk: DeskDto;
}

const deskInitialState: DeskState = {
  desk: {
    tasks: {
      tasks: [],
    },
    statuses: [],
  },
};

export const DeskSlice = createSlice({
  name: "desk",
  initialState: deskInitialState,
  reducers: {
    updateTasks: (state, action: PayloadAction<{ desk: TasksDto }>) => {
      const tmp: TasksDto = action.payload.desk;
      state.desk.tasks = tmp;
    },
    updateStatuses: (state, action: PayloadAction<{ statuses: string[] }>) => {
      const tmp: string[] = action.payload.statuses;
      state.desk.statuses = tmp;
    },
  },
});

export default DeskSlice.reducer;
export const { updateTasks: updateTasks, updateStatuses: updateStatuses } =
  DeskSlice.actions;
