let currentUserId;
const loginModalError = document.querySelector('#login-modal-error');
const loginBtn = document.querySelector('#loginBtn');

function loginUser() {
    const emailTextbox = document.getElementById('username-login-form');
    const passwordTextbox = document.getElementById('password-login-form');

    const item = {
        email: emailTextbox.value.trim(),
        password: passwordTextbox.value.trim()
    };

    fetch(window.location.origin +"/" + USERS_URL + "/login", {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(item),
    })
        .then(response => response.json())
        .then((user) => {
            // clear inputs values
            emailTextbox.value = '';
            passwordTextbox.value = '';
            if (user) {
                // set SessionStorage for data to be persistent
                sessionStorage.setItem('userFirstName', user.FirstName);
                sessionStorage.setItem('userIsAdmin', user.IsAdmin);
                sessionStorage.setItem('currentUserId', user.Id);
                // if user logged in set buttons for myReservation and logout visible
                const myReservationsTab = document.getElementById('myReservationsTab');
                const logout = document.getElementById('logout');
                myReservationsTab.style = "visibility:visible";
                logout.style = "visibility:visible";
                //loggedInUser gets user data
                loggedInUser = user;
                // change the button to a hello message according to user data
                changeLoginButton(loggedInUser);
                currentUserId = sessionStorage.getItem(currentUserId);
                if (user.IsAdmin) {
                    document.getElementById("admin-tab").style.visibility = "visible";
                }
                $("#close-button").click();
            }
            else {
                loginModalError.innerHTML = "Email and password don't match";
            }

        })
        .catch(error => console.error('Unable to login!', error));

}
let loginButton = document.getElementsByClassName("loginButton");
const logoutButton = document.getElementById('logoutButton');


function changeLoginButton(loggedInUser) {
    // change style for login button to a hello message
    loginButton[0].href = "";
    loginButton[0].innerHTML = "Hello" + " " + loggedInUser.FirstName;
    loginButton[0].style.backgroundColor = "blue";
    loginButton[0].style.pointerEvents = "none";
    logoutButton.style = "display:block";
    const myReservations = document.getElementById('myReservations');
    myReservations.href = `/reservations/show/?userId=${loggedInUser.Id}`;
}


logoutButton.addEventListener(
    'click', () => {
        // clear session storage and reload page
        sessionStorage.clear();
        location.reload();
    }
)

loginBtn.addEventListener('click', () => loginModalError.innerHTML = "")



