
import * as BaseDataCall from '../DataCalls/BaseDataCall';
import Urls from '../Config/Urls.json';

export const AddDataCall = (empObject,EmpCallBack) => {

    BaseDataCall.Autheticate();
    let token = '';
    if (document.cookie !== '') {
        token = document.cookie.split('=')[1];
    }
    if (token !== "") {
        fetch(Urls.EmployeeAddServer, {
            method: "post",
            headers: {
                //'Accept': 'application/json',
                'Content-Type': 'application/json',
                'Authorization': 'Bearer ' + token
            },

            body: JSON.stringify({
                firstName: empObject.firstName,
                lastName: empObject.lastName,
                phoneNumber: empObject.phoneNumber,
                email: empObject.email,
                dateOfBirth: empObject.dateOfBirth
            })
        })
            .then((response) => {
                console.log(response);
                EmpCallBack(response);
            })
            .catch((ex) => {
                console.log()
            })
    }
}