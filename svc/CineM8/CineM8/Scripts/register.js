$(document).ready(function () {
    $("#show_hide_password a").on('click', function (event) {
        event.preventDefault();
        if ($('#show_hide_password input').attr("type") === "text") {
            $('#show_hide_password input').attr('type', 'password');
            $('#show_hide_password div').addClass("eyeSlashIcon");
            $('#show_hide_password div').removeClass("eyeIcon");
        } else if ($('#show_hide_password input').attr("type") === "password") {
            $('#show_hide_password input').attr('type', 'text');
            $('#show_hide_password div').removeClass("eyeSlashIcon");
            $('#show_hide_password div').addClass("eyeIcon");
        }
    });
});

var check = 0;

function getItems() {
    fetch(USERS_URL + "/getall")
        .then(response => response.json())
        .then(data => console.log(data))
        .catch(error => console.error('Unable to get items.', error));
}

function addItem() {
    check = 0;
    const addFirstNameTextbox = document.getElementById('first-name');
    const addLastNameTextBox = document.getElementById('last-name');
    const addEmailTextbox = document.getElementById('email');
    const addPasswordTextbox = document.getElementById('password');
    const confirmPasswordTextbox = document.getElementById('password_confirm');
    const phoneNumberTextbox = document.getElementById('phone-number');
    const cardNumberTextbox = document.getElementById('card-number');

    const item = {
        firstName: addFirstNameTextbox.value.trim(),
        lastName: addLastNameTextBox.value.trim(),
        email: addEmailTextbox.value.trim(),
        password: addPasswordTextbox.value.trim(),
        confirm: confirmPasswordTextbox.value.trim(),
        phoneNb: phoneNumberTextbox.value.trim(),
        cardNb: cardNumberTextbox.value.trim()
    };
    if (isValidRegister(item)) {
        fetch(USERS_URL + "/create", {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(item)
        })
            .then(response => response.json())
            .then((Message) => {
                addFirstNameTextbox.value = '';
                addLastNameTextBox.value = '';
                addEmailTextbox.value = '';
                addPasswordTextbox.value = '';
                confirmPasswordTextbox.value = '';
                phoneNumberTextbox.value = '';
                cardNumberTextbox.value = '';
                document.location.href = '../';
            })
            .catch(error => console.error('Unable to add item.', error));
    }
}

function closeInput() {
    document.getElementById('editForm').style.display = 'none';
}

function isEmailRegister(email) {
    const re = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(String(email).toLowerCase());
}

function isSamePassRegister(pass, confirmPass) {
    if (pass === confirmPass) {
        document.getElementById('password-confirm-error').innerHTML = "";
        return true;
    }
    document.getElementById('password-confirm-error').innerHTML = "The password doesn't match!!";
    return false;
}

function isValidPhoneNumberRegister(phoneNumber) {
    if (phoneNumber.length === 10) {
        document.getElementById('phoneNb-error').innerHTML = "";
        return true;
    }
    document.getElementById('phoneNb-error').innerHTML = "The phone number is not valid!!";
    return false;
}

function FirstNameisEmptyRegister(firstName) {
    if (!isEmpty(firstName)) {
        document.getElementById('firstname-error').innerHTML = "";
        return true;
    }
    document.getElementById('firstname-error').innerHTML = "The firstname box should not be empty!!";
    return false;
}

function PasswordNotValidRegister(password) {
    if (password.length >= 4) {
        document.getElementById('password-error').innerHTML = "";
        return true;
    }
    document.getElementById('password-error').innerHTML = "The password has less than 4 characters!!";
    return false;
}

function LastNameisEmptyRegister(lastName) {
    if (!isEmpty(lastName)) {
        document.getElementById('lastname-error').innerHTML = "";
        return true;
    }
    document.getElementById('lastname-error').innerHTML = "The lastname box should not be empty!!";
    return false;
}

function validateCardNumberRegister(number) {
    var regex = new RegExp("^[0-9]{16}$");
    if (!regex.test(number)) {
        document.getElementById('cardNb-error').innerHTML = "The card number is not valid!!";
        return false;
    }
    if (luhnCheck(number) === true)
        document.getElementById('cardNb-error').innerHTML = "";
    else
        document.getElementById('cardNb-error').innerHTML = "The card number is not valid!!";
    return luhnCheck(number);
}

function luhnCheckRegister(val) {
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

function isValidRegister(item) {
    if (isEmailRegister(item.email)) {
        document.getElementById('email-error').innerHTML = "";
        check++;
    }
    else {
        document.getElementById('email-error').innerHTML = "The email address is unavailable!!";
    }

    if (isValidPhoneNumberRegister(item.phoneNb)) {
        check++;
    }

    if (FirstNameisEmptyRegister(item.firstName)) {
        check++;
    }

    if (PasswordNotValidRegister(item.password)) {
        check++;
    }

    if (LastNameisEmptyRegister(item.lastName)) {
        check++;
    }

    if (isSamePassRegister(item.password, item.confirm)) {
        check++;
    }

    if (validateCardNumberRegister(item.cardNb)) {
        check++;
    }

    if (check === 7) {
        return true;
    }
    return false;

}

function isEmpty(strIn) {
    if (strIn === undefined) {
        return true;
    }
    else if (strIn == null) {
        return true;
    }
    else if (strIn == "") {
        return true;
    }
    else {
        return false;
    }
}