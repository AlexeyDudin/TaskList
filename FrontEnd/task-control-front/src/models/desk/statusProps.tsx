import { TaskDto } from "./tasks/task/taskDto";

export type StatusProps = {
  key: number;
  name: string;
  tasks: TaskDto[];
};

export type StatusNameProps = {
  name: string;
};
