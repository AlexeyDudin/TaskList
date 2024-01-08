import styles from "./Task.module.css";
import { TaskProps } from "../../../../../models/desk/tasks/task/taskDto";

function Task(prop: TaskProps) {
  return <div className={styles.Task}>Task Component</div>;
}

export default Task;
