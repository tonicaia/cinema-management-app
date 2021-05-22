$(document).ready(function () {
    $("#show_hide_password a").on('click', function (event) {
        event.preventDefault();
        if ($('#show_hide_password input').attr("type") === "text") {
            $('#show_hide_password input').attr('type', 'password');
            $('#show_hide_password i').addClass("fa-eye-slash");
            $('#show_hide_password i').removeClass("fa-eye");
        } else if ($('#show_hide_password input').attr("type") === "password") {
            $('#show_hide_password input').attr('type', 'text');
            $('#show_hide_password i').removeClass("fa-eye-slash");
            $('#show_hide_password i').addClass("fa-eye");
        }
    });
});

var check = 0;
var btn = document.getElementById('register-backbutton-id');
if (btn != null) {
    btn.addEventListener("click", function () {
        document.location.href = '../';
    })
}

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
        isComplete: false,
        firstName: addFirstNameTextbox.value.trim(),
        lastName: addLastNameTextBox.value.trim(),
        email: addEmailTextbox.value.trim(),
        password: addPasswordTextbox.value.trim(),
        confirm: confirmPasswordTextbox.value.trim(),
        phoneNumber: phoneNumberTextbox.value.trim(),
        card: cardNumberTextbox.value.trim()
    };
    if (isValid(item)) {
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
            })
            .catch(error => console.error('Unable to add item.', error));

    }
    document.location.href = 'https://localhost:44300/';
}

function closeInput() {
    document.getElementById('editForm').style.display = 'none';
}

function isEmail(email) {
    const re = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(String(email).toLowerCase());
}

function isSamePass(pass, confirmPass) {
    if (pass == confirmPass) {
        document.getElementById('password-confirm-error').innerHTML = "";
        return true;
    }
    document.getElementById('password-confirm-error').innerHTML = "The password doesn't match!!";
    return false;
}

function isValidNumber(phoneNumber) {
    if (phoneNumber.length === 10) {
        document.getElementById('phoneNb-error').innerHTML = "";
        return true;
    }
    document.getElementById('phoneNb-error').innerHTML = "The phone number is not valid!!";
    return false;
}

function FirstNameisEmpty(firstName) {
    if (!isEmpty(firstName)) {
        document.getElementById('firstname-error').innerHTML = "";
        return true;
    }
    document.getElementById('firstname-error').innerHTML = "The firstname box should not be empty!!";
    return false;
}

function PasswordNotValid(password) {
    if (password.length >= 4) {
        document.getElementById('password-error').innerHTML = "";
        return true;
    }
    document.getElementById('password-error').innerHTML = "The password has less than 4 characters!!";
    return false;
}

function LastNameisEmpty(lastName) {
    if (!isEmpty(lastName)) {
        document.getElementById('lastname-error').innerHTML = "";
        return true;
    }
    document.getElementById('lastname-error').innerHTML = "The lastname box should not be empty!!";
    return false;
}

function validateCardNumber(number) {
    var regex = new RegExp("^[0-9]{16}$");
    if (!regex.test(number)) {
        document.getElementById('cardNb-error').innerHTML = "The card number is not valid!!";
        return false;
    }
    document.getElementById('cardNb-error').innerHTML = "";
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

function isValid(item) {
    if (isEmail(item.email)) {
        document.getElementById('email-error').innerHTML = "";
        check++;
    }
    else {
        document.getElementById('email-error').innerHTML = "The email address is unavailable!!";
    }

    if (isValidNumber(item.phoneNumber)) {
        check++;
    }

    if (FirstNameisEmpty(item.firstName)) {
        check++;
    }

    if (PasswordNotValid(item.password)) {
        check++;
    }

    if (LastNameisEmpty(item.lastName)) {
        check++;
    }

    if (isSamePass(item.password, item.confirm)) {
        check++;
    }

    if (validateCardNumber(item.card)) {
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