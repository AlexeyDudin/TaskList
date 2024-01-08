import styles from "./TaskBoard.module.css";
import Header from "./Header/Header";
import { useAppSelector } from "../../state/store";
import Status from "./Status/Status";

interface TaskBoardProps {}

function TaskBoard() {
  const statuses: string[] = useAppSelector((state) => state.tasks).desk
    .statuses;

  const renderedStatuses = statuses.map((currentElem, identifyer) => {
    return <Status key={identifyer} name={currentElem} tasks={[]} />;
  });

  return (
    <div className={styles.TaskBoard}>
      <Header></Header>
      <div className={styles.content}>{renderedStatuses}</div>
    </div>
  );
}

export default TaskBoard;
