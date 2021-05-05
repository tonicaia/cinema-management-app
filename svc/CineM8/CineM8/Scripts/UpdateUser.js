var check = 0;
function UpdateUser() {

    check = 0 ;
    const firstnameTextBox = document.getElementById('user-firstname');
    const lastnameTextBox = document.getElementById('user-lastname');
    const emailTextBox = document.getElementById('user-email');

    const user = {
        firstname: firstnameTextBox.value.trim(),
        lastname: lastnameTextBox.value.trim(),
        email: emailTextBox.value.trim(),

    };

    if (validUser(user)) {
        fetch(USERS_URL + "/update/" + idOfUser, {
                method: 'PUT',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(user),
            })
                .then(response => response.json())
                .then((Message) => {
                    firstnameTextBox.value = '';
                    lastnameTextBox.value = '';
                    emailTextBox.value = '';
                    alert(Message);
                    getAllUsers();
                })
                .catch(error => console.error('Unable to update users!', error));
        }
}

function isEmailValid(email) {
    const re = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(String(email).toLowerCase());
}

function isFirstName(firstName) {
    if (!isEmpty(firstName)) {
        document.getElementById('user-firstname-error').innerHTML = " ";
        return true;
    }
    document.getElementById('user-firstname-error').innerHTML = "The firstname box should not be empty!!";
    return false;
}

function isLastName(lastName) {
    if (!isEmpty(lastName)) {
        document.getElementById('user-lastname-error').innerHTML = " ";
        return true;
    }
    document.getElementById('user-lastname-error').innerHTML = "The lastname box should not be empty!!";
    return false;
}

function validUser(user) {
    if (isEmailValid(user.email)) {
        document.getElementById('user-email-error').innerHTML = " ";
        check++;
    }
    else {
        document.getElementById('user-email-error').innerHTML = "The email address is unavailable!!";
    }


    if (isFirstNamey(user.firstname)) {
        check++;
    }


    if (isLastName(user.lastname)) {
        check++;
    }

    if (check === 3) {
        return true;
    }

    return false;

}

function resetUserErrorText() {
    document.getElementById("user-firstname-error").innerHTML = "";
    document.getElementById("user-lastname-error").innerHTML = "";
    document.getElementById("user-email-error").innerHTML = "";
}