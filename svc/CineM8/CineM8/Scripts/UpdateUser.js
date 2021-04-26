
function UpdateUser() {

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

function isEmail(email) {
    if (typeof email == "string" && email.indexOf('@') > -1 && email.indexOf('.') > -1)
        return true;
    return false;
}

function nullFirstname(firstname) {
    if (!isEmpty(firstname)) {
        return true;
    }
    else {
        return false;
    }
}

function nullLastname(lastname) {
    if (!isEmpty(lastname)) {
        return true;
    }
    else {
        return false;
    }
}

function validUser(user) {
    if (isEmail(user.email)) {
        if (nullFirstname(user.firstname)) {
            if (nullLastname(user.lastname)) {
                return true;
            }
            else {
                alert("Lastname field should not be empty!!");
            }
        }
        else {
            alert("Firstname should not be empty!!");
        }
    }
    else {
        alert("The email adress doesn't exist!!");
    }
}