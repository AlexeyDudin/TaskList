import Form from "react-bootstrap/Form";
import styles from "./Authorize.module.css";
import Button from "react-bootstrap/Button";
import { FloatingLabel } from "react-bootstrap";
import { UserDto } from "../../models/users/userDto";
import { useAppDispatch } from "../../state/store";
import { loginUser } from "../../state/slices/userSlice";

function Authorize() {
  let user: UserDto = {
    login: "",
    password: "",
    fullName: "",
    role: undefined,
  };

  const dispatch = useAppDispatch();
  return (
    <div className={styles.background}>
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
          onClick={() => dispatch(loginUser({ user: user }))}
        >
          Login
        </Button>
      </div>
    </div>
  );
}

export default Authorize;
