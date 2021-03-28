function login() {
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
        })
        .catch(error => console.error('Unable to login!', error));
}