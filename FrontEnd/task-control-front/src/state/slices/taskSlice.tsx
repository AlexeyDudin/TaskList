import { PayloadAction, createSlice } from "@reduxjs/toolkit";
import { TasksDto } from "../../models/desk/tasks/tasksDto";
import { DeskDto } from "../../models/desk/deskDto";
import { StatusDto } from "../../models/desk/statusDto";

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
    updateTask: (state, action: PayloadAction<{ desk: TasksDto }>) => {
      const tmp: TasksDto = action.payload.desk;
      state.desk.tasks = tmp;
    },
    updateStatuses: (
      state,
      action: PayloadAction<{ statuses: StatusDto[] }>
    ) => {
      const tmp: StatusDto[] = action.payload.statuses;
      state.desk.statuses = tmp;
    },
    updateTasksByStatus: (
      state,
      action: PayloadAction<{ tasks: TasksDto; status: StatusDto }>
    ) => {
      state.desk.tasks = action.payload.tasks;
    },
    updateTaskList: (state, action: PayloadAction<{ tasks: TasksDto }>) => {
      state.desk.tasks = action.payload.tasks;
    },
  },
});

export default DeskSlice.reducer;
export const {
  updateTask: updateTask,
  updateStatuses: updateStatuses,
  updateTasksByStatus: updateTasksByStatus,
  updateTaskList: updateTaskList,
} = DeskSlice.actions;
