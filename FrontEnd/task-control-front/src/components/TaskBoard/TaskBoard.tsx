import styles from "./TaskBoard.module.css";
import Header from "./Header/Header";
import { useAppSelector } from "../../state/store";
import Status from "./Status/Status";
import { StatusDto } from "../../models/desk/statusDto";
import { TasksDto } from "../../models/desk/tasks/tasksDto";

interface TaskBoardProps {}

function TaskBoard() {
  const statuses: StatusDto[] = useAppSelector((state) => state.tasks).desk
    .statuses;
  const tasks: TasksDto = useAppSelector((state) => state.tasks).desk.tasks;

  const renderedStatuses = statuses.map((currentElem) => {
    return (
      <Status
        key={currentElem.id}
        name={currentElem.name}
        tasks={tasks.tasks.filter((t) => t.state === currentElem.id)}
      />
    );
  });

  return (
    <div className={styles.TaskBoard}>
      <Header></Header>
      <div className={styles.content}>{renderedStatuses}</div>
    </div>
  );
}

export default TaskBoard;
