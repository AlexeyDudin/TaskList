import { StatusProps } from "../../../models/desk/statusProps";
import styles from "./Status.module.css";
import StatusHeader from "./StatusHeader/StatusHeader";
import TaskList from "./TaskList/TaskList";

function Status(prop: StatusProps) {
  return (
    <div className={styles.Status}>
      <StatusHeader name={prop.name} />
      <TaskList tasks={prop.tasks}></TaskList>
    </div>
  );
}

export default Status;
