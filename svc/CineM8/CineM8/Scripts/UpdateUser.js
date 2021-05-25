var check = 0;
function UpdateUser() {

    check = 0;
    const firstnameTextBox = document.getElementById('user-firstname');
    const lastnameTextBox = document.getElementById('user-lastname');
    const emailTextBox = document.getElementById('user-email');
    const phoneNbTextBox = document.getElementById('user-phoneNb');
    const cardNbTextBox = document.getElementById('user-cardNb');
    const isAdminCheckBox = document.getElementById('user-isAdmin');

    const user = {
        firstname: firstnameTextBox.value.trim(),
        lastname: lastnameTextBox.value.trim(),
        email: emailTextBox.value.trim(),
        phoneNb: phoneNbTextBox.value.trim(),
        cardNb: cardNbTextBox.value.trim(),
        isAdmin: isAdminCheck(isAdminCheckBox)
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
                $("#close-button-user-modal").click();
                getAllUsers();
            })
            .catch(error => console.error('Unable to update users!', error));
    }
}

function isAdminCheck(isAdminCheckBox) {
    if (isAdminCheckBox.checked) {
        return true;
    }
    return false;
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


    if (isFirstName(user.firstname)) {
        check++;
    }


    if (isLastName(user.lastname)) {
        check++;
    }

    if (validateCardNumber(user.cardNb)) {
        check++;
    }

    if (isValidNumber(user.phoneNb)) {
        check++;
    }
    if (check === 5) {
        return true;
    }

    return false;

}

function validateCardNumber(number) {
    var regex = new RegExp("^[0-9]{16}$");
    if (!regex.test(number)) {
        document.getElementById('user-cardNb-error').innerHTML = "The card number is not valid!!";
        return false;
    }
    if (luhnCheck(number) === true)
        document.getElementById('user-cardNb-error').innerHTML = "";
    else
        document.getElementById('user-cardNb-error').innerHTML = "The card number is not valid!!";
    return luhnCheck(number);
}

function luhnCheck(val) {
    var sum = 0;
    for (var i = 0; i < val.length; i++) {
        var intVal = parseInt(val.substr(i, 1));
        if (i % 2 == 0) {
            intVal *= 2;
            if (intVal > 9) {
                intVal = 1 + (intVal % 10);
            }
        }
        sum += intVal;
    }
    return (sum % 10) == 0;
}

function isValidNumber(phoneNumber) {
    if (phoneNumber.length === 10) {
        document.getElementById('user-phoneNb-error').innerHTML = "";
        return true;
    }
    document.getElementById('user-phoneNb-error').innerHTML = "The phone number is not valid!!";
    return false;
}

function resetUserErrorText() {
    document.getElementById("user-firstname-error").innerHTML = "";
    document.getElementById("user-lastname-error").innerHTML = "";
    document.getElementById("user-email-error").innerHTML = "";
    document.getElementById("user-phoneNb-error").innerHTML = "";
    document.getElementById("user-cardNb-error").innerHTML = "";
}