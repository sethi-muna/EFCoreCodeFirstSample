import React, { useState, useEffect } from 'react';

const EditEmployee = (props) => {

  let [firstName, setfirstName] = useState("");
  let [lastName, setlastName] = useState("");
  let [dateOfBirth, setdateOfBirth] = useState("");
  let [phoneNumber, setphoneNumber] = useState("");
  let [email, setemail] = useState("");

  useEffect(() => {
    setfirstName(props.Data.firstName);
    setlastName(props.Data.lastName);
    setdateOfBirth(props.Data.dateOfBirth);
    setemail(props.Data.email);
    setphoneNumber(props.Data.phoneNumber);
  }, [props.Data])


  const ChangeText = (e) => {
    let id = e.target.id;
    let value = e.target.value;
    switch (id) {
      case "inputEmail":
        setemail(value);
        break;
      case "inputPhoneNumber":
        if (value.length > 10) {
          value = value.substr(0, 10);
        }
        setphoneNumber(value);
        break;
      case "inputfirstName":
        setfirstName(value);
        break;
      case "inputlastName":
        setlastName(value);
        break;
      case "DateOfBirth":
        setdateOfBirth(value);
        break;
      default:
        break;
    }
  }

  const UpdateEmployee = () =>
  {
    if(firstName !== "" &&lastName !== "" &&phoneNumber !== "" &&email !== "" &&dateOfBirth !== "")
    {
      try{
      fetch("http://localhost/employeeApp/api/employee/"+props.Data.employeeId, {
        method: "put",
        headers: {
          //'Accept': 'application/json',
          'Content-Type': 'application/json'
        },

        body: JSON.stringify({
          employeeId:props.Data.employeeId,
          firstName: firstName,
          lastName: lastName,
          phoneNumber: phoneNumber,
          email: email,
          dateOfBirth: dateOfBirth
        })
      })
        .then((response) => {
          console.log(response);
          if(response.status === 204)
          {
            document.getElementById("success").style.display = 'block';
             document.getElementById("success").innerHTML = "update done successfully!";
          }
        })
        .catch((ex)=>{
          document.getElementById("error").style.display = 'block';
          document.getElementById("error").innerHTML = "There is some error please check!";
        })
      }
      catch(ex)
      {
        document.getElementById("error").style.display = 'block';
        document.getElementById("error").innerHTML = "There is some error please check!";
      }
    }
  }

 const CloseModel = () =>{
  document.getElementById("error").style.display="none";
  document.getElementById("success").style.display="none";
  document.getElementById("exampleModal").style.display = "none";
 }

  return (
    <>
      <div class="container-md border border-dark rounded-3 bg-success">
        <form class="row g-3">
          <div class="col-md-6">
            <label class="form-label">Email</label>
            <input type="email" class="form-control" id="inputEmail" value={email} onChange={(e) => { ChangeText(e) }} />
          </div>
          <div class="col-md-6">
            <label class="form-label">Phone Number</label>
            <input type="text" class="form-control" id="inputPhoneNumber" value={phoneNumber} onChange={(e) => { ChangeText(e) }} />
          </div>
          <div class="col-md-6">
            <label class="form-label">FirstName</label>
            <input type="text" class="form-control" id="inputfirstName" value={firstName} onChange={(e) => { ChangeText(e) }} />
          </div>
          <div class="col-md-6">
            <label class="form-label">LastName</label>
            <input type="text" class="form-control" id="inputlastName" value={lastName} onChange={(e) => { ChangeText(e) }} />
          </div>
          <div class="col-12">
            <label class="form-label">DateOfBirth</label>
            <input type="date" class="form-control" id="DateOfBirth" value={dateOfBirth?dateOfBirth.split('T')[0]:dateOfBirth} onChange={(e) => { ChangeText(e) }} />
          </div>
          <div class="col-md-6">
              <button type="button" class="btn btn-secondary" data-bs-dismiss="modal" onClick={()=>{CloseModel()}}>Close</button>              
          </div>
          <div class="col-md-6">
              <button type="button" class="btn btn-primary" onClick={()=>{UpdateEmployee();}}>Save changes</button>
          </div>
        </form>
      </div>
    </>
  );
}

export default EditEmployee;