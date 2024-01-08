import React, { FC } from "react";
import styles from "./Header.module.css";
import { Button } from "react-bootstrap";
import { setUserToStorage } from "../../../modules/CacheStorage";
import { UserDto } from "../../../models/users/userDto";
import { useAppDispatch, useAppSelector } from "../../../state/store";
import { loginUser } from "../../../state/slices/userSlice";

interface HeaderProps {}

function Header() {
  const dispatch = useAppDispatch();
  const userName: string | undefined = useAppSelector((state) => state.users)
    .user?.fullName;
  function UpdateHook(user: UserDto): void {
    dispatch(loginUser({ user: user }));
  }

  function unlogin() {
    setUserToStorage(undefined);
    UpdateHook(loginUser(undefined));
  }
  return (
    <div className={styles.Header}>
      <span></span>
      <div className={styles.UserName}>
        <div className={styles.HeaderElement}>{userName}</div>
        <Button className={styles.HeaderElement} onClick={() => unlogin()}>
          Выйти
        </Button>
      </div>
    </div>
  );
}

export default Header;
