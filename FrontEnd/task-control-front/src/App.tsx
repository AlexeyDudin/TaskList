import "./App.css";
import Authorize from "./components/Authorize/Authorize";
import TaskBoard from "./components/TaskBoard/TaskBoard";
import { isStatuses } from "./models/desk/deskDto";
import { TasksDto } from "./models/desk/tasks/tasksDto";
import { responseDto } from "./models/responseDto";
import { TaskManagerAPI } from "./modules/TaskManagerAPI/TaskManagerAPI";
import { updateStatuses, updateTasks } from "./state/slices/taskSlice";
import { useAppDispatch, useAppSelector } from "./state/store";

function App() {
  const dispatch = useAppDispatch();

  function UpdateHook(desk: TasksDto): void {
    dispatch(updateTasks({ desk: desk }));
  }

  function UpdateStatusesHook(tasks: string[]): void {
    dispatch(updateStatuses({ statuses: tasks }));
  }
  async function GetStatusesFromServer(): Promise<Array<string> | undefined> {
    return await TaskManagerAPI.getStatus().then(
      (response: responseDto | Response) => {
        if (response instanceof Response) {
          alert(response.status + " " + response.text());
        } else {
          if (isStatuses(response.content)) {
            return response.content;
          }
        }
      }
    );
  } // UpdateHook(statuses);

  GetStatusesFromServer().then((statuses: string[] | undefined) => {
    if (statuses !== undefined) UpdateStatusesHook(statuses);
    else UpdateStatusesHook([]);
  });
  const userLogin: string | undefined = useAppSelector((state) => state.users)
    .user?.login;
  console.log(userLogin);
  return userLogin === undefined ? <Authorize /> : <TaskBoard />;
  // return (
  //   <div className="App">
  //     {/* <header className="App-header">
  //       <img src={logo} className="App-logo" alt="logo" />
  //       <p>
  //         Edit <code>src/App.tsx</code> and save to reload.
  //       </p>
  //       <a
  //         className="App-link"
  //         href="https://reactjs.org"
  //         target="_blank"
  //         rel="noopener noreferrer"
  //       >
  //         Learn React
  //       </a>
  //     </header> */}
  //   </div>
  // );
}

export default App;
