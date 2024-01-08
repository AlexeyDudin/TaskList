import React, { FC } from "react";
import styles from "./TaskBoard.module.css";
import Header from "./Header/Header";

interface TaskBoardProps {}

function TaskBoard() {
  return (
    <div className={styles.TaskBoard}>
      <Header></Header>
      TaskBoard Component
    </div>
  );
}

export default TaskBoard;
