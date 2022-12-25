import { useState } from 'react';
import { useNavigate } from "react-router-dom";
import * as DataCall from '../DataCalls/AddCalls';

function Registration() {

  let [firstName, setfirstName] = useState("");
  let [lastName, setlastName] = useState("");
  let [dateOfBirth, setdateOfBirth] = useState("");
  let [phoneNumber, setphoneNumber] = useState("");
  let [email, setemail] = useState("");
  let navigate = useNavigate();

  const ChangeText = (e) => {
    let id = e.target.id;
    let value = e.target.value;
    switch (id) {
      case "inputEmail":
        setemail(value);
        break;
      case "inputPhoneNumber":
        if(value.length>10)
        {
          value = value.substr(0,10);
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

  const SubmitEmployee = () =>
  {
    if(firstName !== "" &&lastName !== "" &&phoneNumber !== "" &&email !== "" &&dateOfBirth !== "")
    {
      try{

        let empObject = {
                firstName: firstName,
                lastName: lastName,
                phoneNumber: phoneNumber,
                email: email,
                dateOfBirth: dateOfBirth
        };

         DataCall.AddDataCall(empObject,(response)=>{
          if (response.statusText === "Created" && response.status === 201) {
            navigate.push("/EmployeeData");
        }
         })
      }
      catch(ex)
      {
        console.log(ex);
      }
    }
  }

  return (
    <>
      <div class="container-md border border-dark rounded-3 bg-info">
        <form class="row g-3">
          <div class="col-md-6">
            <label class="form-label">Email</label>
            <input type="email" class="form-control" id="inputEmail" value={email} onChange={(e) => {ChangeText(e) }}/>
          </div>
          <div class="col-md-6">
            <label class="form-label">Phone Number</label>
            <input type="text" class="form-control" id="inputPhoneNumber" value={phoneNumber} onChange={(e) => {ChangeText(e) }} />
          </div>
          <div class="col-md-6">
            <label class="form-label">FirstName</label>
            <input type="text" class="form-control" id="inputfirstName" value={firstName} onChange={(e) => {ChangeText(e) }}/>
          </div>
          <div class="col-md-6">
            <label class="form-label">LastName</label>
            <input type="text" class="form-control" id="inputlastName" value={lastName} onChange={(e) => {ChangeText(e) }}/>
          </div>
          <div class="col-12">
            <label class="form-label">DateOfBirth</label>
            <input type="date" class="form-control" id="DateOfBirth" value={dateOfBirth} onChange={(e) => {ChangeText(e) }}/>
          </div>
          <div class="col-12">
            <button type="submit" class="btn btn-primary" onClick={()=>{SubmitEmployee()}}>Register</button>
          </div>
        </form>
      </div>
    </>
  );
}

export default Registration;
