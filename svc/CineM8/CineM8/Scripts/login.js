let currentUserId = -1;

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
                currentUserId = loggedInUser.Id;
                if (user.IsAdmin) {
                    document.getElementById("admin-tab").style.visibility = "visible";
                }
                $("#close-button").click();
            }
            
        })
        .catch(error => console.error('Unable to login!', error));
  
}
let loginButton = document.getElementsByClassName("loginButton");

function changeLoginButton(loggedInUser) {
    loginButton[0].href = "";
    loginButton[0].innerHTML = "Hello" + " " + loggedInUser.FirstName;
    loginButton[0].style.backgroundColor = "blue";
    loginButton[0].style.pointerEvents = "none";
    const myReservationsTab = document.getElementById('myReservationsTab');
    const myReservations = document.getElementById('myReservations');
    myReservationsTab.style = "display:block";
    myReservations.href = RESERVATIONS_URL + '/GetAllReservationForUser/' + currentUserId;
    
}


