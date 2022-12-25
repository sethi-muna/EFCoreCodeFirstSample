
import Urls from '../Config/Urls.json';

/**
 * Authetication happens here
 */
export const Autheticate = () => {
    let credential = {
        username: "Ram",
        password: "xyz"
    };

    if (document.cookie === '') {
        fetch(Urls.AutheticateServer, {
            method: "post",
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },

            //make sure to serialize your JSON body
            body: JSON.stringify(credential)
        })  //
            .then(response => response.json())
            .then(data => {
                if (data.status === "Success")
                    document.cookie = "Ram=" + data.token;
            })
    }
};