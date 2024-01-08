import { TasksDto } from "./tasks/tasksDto";

export type DeskDto = {
  tasks: TasksDto;
  statuses: string[];
};

export function isStatuses(obj: Array<string>): obj is Array<string> {
  if (!Array.isArray(obj)) return false;
  else {
    obj.forEach((elem) => {
      if (typeof elem !== "string") return false;
    });
    return true;
  }
  // return (
  //   Array.isArray(obj)? {
  //     let result : Boolean = true;
  //     obj.forEach(element => {
  //       if(typeof element !== 'string'){
  //        somethingIsNotString = true;
  //     }
  //     })
  //   } : false
  // );
}
