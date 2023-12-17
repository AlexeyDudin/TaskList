import React, { FC } from 'react';
import styles from './TaskBoard.module.css';

interface TaskBoardProps {}

const TaskBoard: FC<TaskBoardProps> = () => (
  <div className={styles.TaskBoard}>
    TaskBoard Component
  </div>
);

export default TaskBoard;
