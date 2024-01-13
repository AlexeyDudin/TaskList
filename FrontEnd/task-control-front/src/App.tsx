import "./App.css";
import Authorize from "./components/Authorize/Authorize";
import TaskBoard from "./components/TaskBoard/TaskBoard";
import { StatusDto, isStatusDtoArray } from "./models/desk/statusDto";
import { TasksDto } from "./models/desk/tasks/tasksDto";
import { responseDto } from "./models/responseDto";
import { TaskManagerAPI } from "./modules/TaskManagerAPI/TaskManagerAPI";
import {
  updateStatuses,
  updateTask,
  updateTaskList,
  updateTasksByStatus,
} from "./state/slices/taskSlice";
import { useAppDispatch, useAppSelector } from "./state/store";

function App() {
  const dispatch = useAppDispatch();

  function UpdateHook(desk: TasksDto): void {
    dispatch(updateTask({ desk: desk }));
  }

  function UpdateStatusesHook(tasks: StatusDto[]): void {
    dispatch(updateStatuses({ statuses: tasks }));
  }

  function UpdateTasksByStatus(tasks: TasksDto, status: StatusDto): void {
    dispatch(updateTasksByStatus({ tasks: tasks, status: status }));
  }

  function UpdateTasks(tasks: TasksDto): void {
    dispatch(updateTaskList({ tasks: tasks }));
  }

  async function GetStatusesFromServer(): Promise<StatusDto[] | undefined> {
    return await TaskManagerAPI.getStatus().then(
      (response: responseDto | Response) => {
        if (response instanceof Response) {
          alert(response.status + " " + response.text());
        } else {
          if (isStatusDtoArray(response.content)) {
            TaskManagerAPI.getAllTasks().then(
              (response: responseDto | Response) => {
                if (response instanceof Response) {
                  alert(response.status + " " + response.text());
                } else {
                  updateTaskList(response.content);
                }
              }
            );
            // const statuses: StatusDto[] = response.content;
            // statuses.forEach((status) => {
            //   TaskManagerAPI.getTasksByStatus(status);
            // });
            return response.content;
          }
        }
      }
    );
  } // UpdateHook(statuses);

  GetStatusesFromServer().then((statuses: StatusDto[] | undefined) => {
    if (statuses !== undefined) UpdateStatusesHook(statuses);
    else UpdateStatusesHook([]);
  });
  const userLogin: string | undefined = useAppSelector((state) => state.users)
    .user?.login;
  console.log(userLogin);
  return userLogin === undefined ? <Authorize /> : <TaskBoard />;
}

export default App;
