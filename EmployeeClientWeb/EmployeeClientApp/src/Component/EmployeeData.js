import React, { useState, useEffect } from 'react';
import Modal from '../Controls/Modal';
import '../css/main.css'
import * as DataCalls from '../DataCalls/GetCalls';

function EmployeeData() {

    let [employees, setEmployees] = useState(null);
    let [modal, setModal] = useState("");
    let [employeetoUpdate, setEmployeeToUpdate] = useState({});

    useEffect(() => {

        DataCalls.EmployeeGetCall((data)=>{
            setEmployees(data);
            console.log(data[0]);
        })
        
    }, [])

    const onEdit = (item) =>{
        setEmployeeToUpdate(item);
        setModal("modal");
    }

    return (
        <div>

            <table class="table">
                <thead>
                    <tr className='table-active'>
                        <th scope="col">firstName</th>
                        <th scope="col">lastName</th>
                        <th scope="col">dateOfBirth</th>
                        <th scope="col">phoneNumber</th>
                        <th scope="col">email</th>
                        <th scope="col"></th>
                    </tr>
                </thead>
                <tbody>
                    {
                        employees ?
                            employees.map(item => {
                                return (<tr>
                                    <td>{item.firstName}</td>
                                    <td>{item.lastName}</td>
                                    <td>{item.dateOfBirth}</td>
                                    <td>{item.phoneNumber}</td>
                                    <td>{item.email}</td>
                                    <td>
                                        <button type="button" className='btn btn-light' data-bs-toggle={modal} data-bs-target="#exampleModal" onClick={()=>{onEdit(item)}}>
                                            <i class='fa fa-edit' style={{color: "blue"}}></i>
                                        </button>
                                    </td>
                                </tr>)
                            })
                            : <>
                            <div className='loader center'></div>
                            </>
                    }
                </tbody>
            </table>

            <Modal ModalTitle="EmployeeData" Data={employeetoUpdate}/>
        </div>
    );
}

export default EmployeeData;
