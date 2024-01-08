import styles from "./TaskList.module.css";
import { TasksDto } from "../../../../models/desk/tasks/tasksDto";
import Task from "./Task/Task";

function TaskList(prop: TasksDto) {
  const tasks = prop.tasks.map((currElem, id) => {
    return <Task task={currElem} id={id} />;
  });
  return <div className={styles.TaskList}>{tasks}</div>;
}

export default TaskList;
