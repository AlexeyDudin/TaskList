import { subtaskDto } from "./subtasks";
import { taskState } from "./taskState";

export type TaskDto = {
  text: string;
  state: taskState;
  creationDate: Date;
  estimateTime?: Date;
  userIssueName: string;
  userWorkerName: string;
  subtasks: Array<subtaskDto>;
};
