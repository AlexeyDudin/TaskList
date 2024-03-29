import { StatusDto } from "../../models/desk/statusDto";
import { UserDto } from "../../models/users/userDto";
import { fetchData, RequestMethod } from "../handleRequest";
import { ROUTES } from "./routes";

const ipAddress: string = "https://localhost:7084";

export const TaskManagerAPI = {
  login(iLogin: string, iPassword: string) {
    const params: UserDto = {
      login: iLogin,
      password: iPassword,
      fullName: "1",
      role: 0,
    };
    return fetchData(ipAddress + ROUTES.LOGIN, RequestMethod.GET, params);
  },
  getStatus() {
    return fetchData(ipAddress + ROUTES.GET_STATUS, RequestMethod.GET);
  },
  getAllTasks() {
    return fetchData(ipAddress + ROUTES.GET_ALL_TASKS, RequestMethod.GET);
  },
  getTasksByStatus(status: StatusDto) {
    return fetchData(
      ipAddress + ROUTES.GET_TASKS_BY_STATUS,
      RequestMethod.POST,
      status
    );
  },
};
