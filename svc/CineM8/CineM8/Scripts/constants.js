const HALLS_URL = 'api/halls';
const USERS_URL = 'api/user';
const MOVIES_URL = 'api/movies';
const RESERVATIONS_URL = 'api/reservation'


//an array to store all the active users
let users = [];
//currently logged user
let loggedInUser;
//an array to store all the movies
let movies = [];
//an array to store all the halls
let halls = [];


window.onload = function init() {
    let userName = window.sessionStorage.getItem('userFirstName');
    let isAdmin = window.sessionStorage.getItem('userIsAdmin');
    if (userName != null && userName != '') {
        document.getElementById("loginBtn").innerHTML = "Hello" + " " + userName;
        document.getElementById("loginBtn").href = "";
        document.getElementById("loginBtn").style.pointerEvents = "none";
        document.getElementById("loginBtn").style.backgroundColor = "blue";
    }
    if (isAdmin === 'true' || isAdmin == true) {
        document.getElementById("admin-tab").style.visibility = "visible";
        let x = document.getElementById("admin-name");
        if (x) x.innerHTML = userName;
        
    }
}
