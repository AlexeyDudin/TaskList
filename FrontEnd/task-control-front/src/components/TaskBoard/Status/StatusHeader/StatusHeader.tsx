import styles from "./StatusHeader.module.css";
import { StatusNameProps } from "../../../../models/desk/statusProps";

function StatusHeader(prop: StatusNameProps) {
  return <div className={styles.StatusHeader}>{prop.name}</div>;
}

export default StatusHeader;
