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
    
});
