function loginUser() {
    const emailTextbox = document.getElementById('username-login-form');
    const passwordTextbox = document.getElementById('password-login-form'); 

    const item = {
        email: emailTextbox.value.trim(),
        password: passwordTextbox.value.trim()
    };

    fetch(USERS_URL + "/login", {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body:JSON.stringify(item),
    })
        .then(response => response.json())
        .then((Message) => {
            emailTextbox.value = '';
            passwordTextbox.value = '';
            alert(Message);
            if (Message == "Login Succesfully!") {
                localStorage.setItem('loggedInUser',true);
                changeLoginButton(item);
            }
        })
        .catch(error => console.error('Unable to login!', error));

   /* loggedInUser = {
        "name": "Toni",
        "admin": true
    };
    localStorage.setItem('loggedInUser', loggedInUser.name);
    localStorage.setItem('admin', loggedInUser.admin);
    if (localStorage.getItem('admin') == true) {
        let adminButton = document.getElementsByClassName("adminButton");
        adminButton[0].style.visibility = "visible";
    }
    if (loggedInUser.admin === true) {
        let adminButton = document.getElementsByClassName("adminButton");
        adminButton[0].style.visibility = "visible";
    }
    */
}

function changeLoginButton(item) {
    let loginButton = document.getElementsByClassName("loginButton");
    loginButton[0].href = "";
    loginButton[0].innerHTML = "Hello" + " " + item.email;
    loginButton[0].style.backgroundColor = "blue";
    loginButton[0].style.pointerEvents = "none";
}