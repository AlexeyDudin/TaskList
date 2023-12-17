import {getUser} from './modules/CacheStorage';
import './App.css';
import Authorize from './components/Authorize/Authorize';
import TaskBoard from './components/TaskBoard/TaskBoard';

function App() {
  return <div className='FullScreen'>
  ({getUser() === undefined ? 
    <Authorize/>
    :
    <TaskBoard/>
  }
  )
  </div>
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
