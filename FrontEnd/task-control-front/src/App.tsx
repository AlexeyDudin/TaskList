import "./App.css";
import Authorize from "./components/Authorize/Authorize";
import TaskBoard from "./components/TaskBoard/TaskBoard";
import { UserDto } from "./models/users/userDto";
import { useAppSelector } from "./state/store";

function App() {
  const userLogin: string | undefined = useAppSelector((state) => state.users)
    .user?.login;
  console.log(userLogin);
  return userLogin === undefined ? <Authorize /> : <TaskBoard />;
  // return (
  //   <div className="App">
  //     {/* <header className="App-header">
  //       <img src={logo} className="App-logo" alt="logo" />
  //       <p>
  //         Edit <code>src/App.tsx</code> and save to reload.
  //       </p>
  //       <a
  //         className="App-link"
  //         href="https://reactjs.org"
  //         target="_blank"
  //         rel="noopener noreferrer"
  //       >
  //         Learn React
  //       </a>
  //     </header> */}
  //   </div>
  // );
}

export default App;
