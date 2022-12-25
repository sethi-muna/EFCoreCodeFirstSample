import { Outlet } from "react-router-dom";
import Navigation from "../Controls/Navigation";

function Home() {
    return (
        <div>
            <Navigation/>
            <Outlet />
        </div>
    );
  }
  
  export default Home;
  