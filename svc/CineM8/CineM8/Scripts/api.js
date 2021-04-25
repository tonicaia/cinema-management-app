function getAllUsers() {
    fetch(USERS_URL + "/getall")
        .then(response => response.json())
        .then(data => {
            users = data;
            fillUsersTable();
        })
        .catch(error => console.error("Unable to get users", error));
}

function getAllMovies() {
    fetch(MOVIES_URL + "/GetMovie")
        .then(response => response.json())
        .then(data => {
            movies = data;
            console.log(movies)
          fillMoviesTable();
          fillMoviesList();
        })
        .catch(error => console.error("Unable to get movies", error));
}

function getAllHalls() {
    fetch(HALLS_URL + "/GetHall")
        .then(response => response.json())
        .then(data => {
            halls = data;
            console.log(movies)
            fillHallsTable();
        })
        .catch(error => console.error("Unable to get halls", error));
}

function sleep(milliseconds) {
    const date = Date.now();
    let currentDate = null;
    do {
        currentDate = Date.now();
    } while (currentDate - date < milliseconds);
}

// INIT CALLS
$(document).ready(function () {

    getAllUsers();
    getAllMovies();
    getAllHalls();
});
