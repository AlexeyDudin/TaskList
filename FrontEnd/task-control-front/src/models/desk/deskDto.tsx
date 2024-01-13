import { StatusDto } from "./statusDto";
import { TasksDto } from "./tasks/tasksDto";

export type DeskDto = {
  tasks: TasksDto;
  statuses: StatusDto[];
};
