const HALLS_URL = 'api/halls';
const USERS_URL = 'api/user';
const MOVIES_URL = 'api/movies';
const RESERVATIONS_URL = 'api/reservation';
const PRICE_URL = 'api/price';


//an array to store all the active users
let users = [];
//currently logged user
let loggedInUser;
//an array to store all the movies
let movies = [];
//an array to store all the halls
let halls = [];
//an array to store all the prices
let prices = [];

window.onload = function init() {
    // make state for UI persistent
    let userName = window.sessionStorage.getItem('userFirstName');
    let isAdmin = window.sessionStorage.getItem('userIsAdmin');

    if (userName != null && userName != '') {
        document.getElementById("loginBtn").innerHTML = "Hello" + " " + userName;
        document.getElementById("loginBtn").href = "";
        document.getElementById("loginBtn").style.pointerEvents = "none";
        document.getElementById("loginBtn").style.backgroundColor = "blue";
        const logout = document.getElementById('logout');
        const myReservationsTab = document.getElementById('myReservationsTab');
        myReservationsTab.style = "visibility:visible";
        logout.style = "visibility:visible";
    }
    if (isAdmin === 'true' || isAdmin == true) {
        document.getElementById("admin-tab").style.visibility = "visible";
        const x = document.getElementById("admin-name");
        if (x) x.innerHTML = userName;

    }
}
