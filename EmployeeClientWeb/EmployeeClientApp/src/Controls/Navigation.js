import { Link } from "react-router-dom";

function Navigation() {

    const AlterCss = (id) => {
        if (id === "Link1") {
            document.getElementById("Link2").style.backgroundColor = "lightyellow";
        }
        else {
            document.getElementById("Link1").style.backgroundColor = "lightyellow";
        }
        document.getElementById(id).style.backgroundColor = "lightblue"
    }
    return (
        <>
            <div className="container">
                <div className="jumbotron">
                    <h1 class="display-4" style={{color:"greenyellow", backgroundColor:"GrayText", textAlign:"center"}}>Employee</h1>
                </div>
            </div>
            <nav class="navbar navbar-expand-lg navbar-light" style={{ backgroundColor: "lightyellow" }}>
                <div class="collapse navbar-collapse" id="navbarNavAltMarkup">
                    <div class="navbar-nav">
                        <Link id="Link1" class="nav-item nav-link" style={{ borderRadius: "10px" }} to="/EmployeeData" onClick={() => { AlterCss("Link1") }}>ViewEmployeeData</Link>
                        <Link id="Link2" class="nav-item nav-link" style={{ borderRadius: "10px" }} to="/Registration" onClick={() => { AlterCss("Link2") }}>AddEmployee</Link>
                    </div>
                </div>
            </nav>

        </>
    )
}

export default Navigation;