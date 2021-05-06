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
        .then((user) => {
            sessionStorage.setItem('userFirstName', user.FirstName);
            sessionStorage.setItem('userIsAdmin', user.IsAdmin);

            emailTextbox.value = '';
            passwordTextbox.value = '';
            console.log(user);
            if (user) {
                loggedInUser = user;
                changeLoginButton(loggedInUser);
                if (user.IsAdmin) {
                    document.getElementById("admin-tab").style.visibility = "visible";
                }
             
            }
        })
        .catch(error => console.error('Unable to login!', error));
  
}

function changeLoginButton(loggedInUser) {
    let loginButton = document.getElementsByClassName("loginButton");
    loginButton[0].href = "";
    loginButton[0].innerHTML = "Hello" + " " + loggedInUser.FirstName;
    loginButton[0].style.backgroundColor = "blue";
    loginButton[0].style.pointerEvents = "none";
}