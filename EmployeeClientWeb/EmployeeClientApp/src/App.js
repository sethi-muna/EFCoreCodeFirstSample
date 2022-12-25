import {
  BrowserRouter,
  Routes,
  Route,
} from "react-router-dom";
import Home from "./Component/Home";
import EmployeeData from './Component/EmployeeData';
import Registration from './Component/Registration';

function App() {

  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Home />} >
          <Route path="EmployeeData" element={<EmployeeData />} />
          <Route path="Registration" element={<Registration />} />
        </Route>
      </Routes>
    </BrowserRouter>
  );
}

export default App;
