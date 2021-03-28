function getItems() {
    fetch(USERS_URL + "/getall")
        .then(response => response.json())
        .then(data => console.log(data))
        .catch(error => console.error('Unable to get items.', error));
}

function addItem() {
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
                alert(Message);
            })
            .catch(error => console.error('Unable to add item.', error));
    }
    else {
        alert("Error!");
    }
}


function closeInput() {
    document.getElementById('editForm').style.display = 'none';
}

function isEmail(email) {
    if (typeof email == "string" && email.indexOf('@') > -1 && email.indexOf('.') > -1)
        return true;
    return false;
}
function isSamePass(pass, confirmPass) {
    if (pass === confirmPass)
        return true;
    return false;
}

function isValidNumber(phoneNumber) {
    if (phoneNumber.length === 10)
        return true;
    return false;
}

function isEmpty(textBoxValue) {
    if (textBoxValue == '')
        return true;
    return false;
}

function isFormFilled(item) {
    for (var i = 1; i < item.length; i++) {
        if (isEmpty(item[i]))
            return false;
    }
    return true;
}

function isValid(item) {
    if (isSamePass(item.password, item.confirm) && isEmail(item.email) && isValidNumber(item.phoneNumber) && isFormFilled(item))
        return true;
    return false;
}