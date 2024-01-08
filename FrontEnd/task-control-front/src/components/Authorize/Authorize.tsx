import Form from "react-bootstrap/Form";
import styles from "./Authorize.module.css";
import Button from "react-bootstrap/Button";
import { FloatingLabel } from "react-bootstrap";
import { UserDto, isUserDto } from "../../models/users/userDto";
import { useAppDispatch } from "../../state/store";
import { loginUser } from "../../state/slices/userSlice";
import { TaskManagerAPI } from "../../modules/TaskManagerAPI/TaskManagerAPI";
import { responseDto } from "../../models/responseDto";
import { setUserToStorage } from "../../modules/CacheStorage";

function Authorize() {
  const dispatch = useAppDispatch();

  function UpdateHook(user: UserDto): void {
    dispatch(loginUser({ user: user }));
  }

  async function GetDataFromServer(
    user: UserDto
  ): Promise<UserDto | undefined> {
    return await TaskManagerAPI.login(user.login, user.password)
      .then((response: responseDto | Response) => {
        if (response instanceof Response) {
          alert(response.status + " " + response.text());
        } else {
          if (isUserDto(response.content)) {
            return response.content;
          }
        }
        return undefined;
      })
      .catch((ex) => {
        console.log(ex);
        return undefined;
      });
  }

  async function GetUserFromServer(
    user: UserDto
  ): Promise<UserDto | undefined> {
    const tmp = await GetDataFromServer(user);
    if (tmp !== undefined) UpdateHook(tmp);
    setUserToStorage(tmp);
    return undefined;
  }

  let user: UserDto = {
    login: "",
    password: "",
    fullName: "",
    role: undefined,
  };

  return (
    <div className={styles.background}>
      <div className={styles.emptyContainer}></div>
      <div className={styles.mainContainer}>
        <div className={styles.emptyContainer}></div>
        <div className={styles.container}>
          <FloatingLabel label="Login" className="mb-3">
            <Form.Control
              type="text"
              placeholder="name@example.com"
              onChange={(event) => (user.login = event.target.value)}
            />
          </FloatingLabel>
          <FloatingLabel controlId="floatingPassword" label="Password">
            <Form.Control
              type="password"
              placeholder="Password"
              onChange={(event) => (user.password = event.target.value)}
            />
          </FloatingLabel>
          <Button
            type="submit"
            className={styles.login_button}
            onClick={() => GetUserFromServer(user)}
          >
            Login
          </Button>
        </div>
        <div className={styles.emptyContainer}></div>
      </div>
      <div className={styles.emptyContainer}></div>
    </div>
  );
}

export default Authorize;
