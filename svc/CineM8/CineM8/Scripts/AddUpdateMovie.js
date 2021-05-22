const { checked } = require("modernizr");

var check = 0;
function AddUpdateMovie() {
    check = 0;
    const nameTextBox = document.getElementById('movie-name');
    const descriptionTextArea = document.getElementById('movie-description');
    const lengthTextBox = document.getElementById('movie-length');
    const isRunningCheckBox = document.getElementById('movie-isRunning');
    const imageURLTextBox = document.getElementById('movie-imageURL');

    const movie = {
        name: nameTextBox.value.trim(),
        description: descriptionTextArea.value.trim(),
        length: lengthTextBox.value.trim(),
        isRunning: isRunningCheck(isRunningCheckBox),
        imageURL: imageURLTextBox.value.trim()
    };

    //Add movie if doUpdate is false and update movie if doUpdate is true
    if (validMovie(movie)) {
        if (doUpdate == false) {
            fetch(MOVIES_URL + "/PostNewMovie", {
                method: 'POST',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(movie),
            })
                .then(response => response.json())
                .then((Message) => {
                    nameTextBox.value = '';
                    descriptionTextArea.value = '';
                    lengthTextBox.value = '';
                    imageURLTextBox.value = '';
                    alert(Message);
                    getAllMovies();
                })
                .catch(error => console.error('Unable to insert movie!', error));

        }
        else {
            fetch(MOVIES_URL + "/UpdateMovie/" + idOfMovie, {
                method: 'PUT',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(movie),
            })
                .then(response => response.json())
                .then((Message) => {
                    nameTextBox.value = '';
                    descriptionTextArea.value = '';
                    lengthTextBox.value = '';
                    imageURLTextBox.value = '';
                    const closeButton = document.querySelector('#close-button-movie-movie');
                    closeButton.click();
                    alert(Message);
                    getAllMovies();
                })
                .catch(error => console.error('Unable to update movie!', error));
        }
    }
    
}

//make doUpdate false in order to add movies
function changedoUpdate() {
    doUpdate = false
}

function isNumber(length) {
    if ($.isNumeric(length))
    {
        document.getElementById("movie-length-error").innerHTML = "";
        return true;
    }
    document.getElementById("movie-length-error").innerHTML = "Length input should be only a number!!";
    return false;
}

function nullName(name)
{
    if (!isEmpty(name))
    {
        document.getElementById("movie-name-error").innerHTML = "";
        return true;
    }
    document.getElementById("movie-name-error").innerHTML = "Name field should not be empty!!";
    return false;
}
function nullDescription(description)
{
    if (!isEmpty(description))
    {
        document.getElementById("movie-description-error").innerHTML = "";
        return true;
    }
    document.getElementById("movie-description-error").innerHTML = "Description field should not be empty!!";
    return false;

}

function validURL(imageURL) {
        let url;

        try {
            url = new URL(imageURL);
        } catch (_) {
            return false;
        }

        return url.protocol === "http:" || url.protocol === "https:";
}

function validMovie(movie)
{
    if (isNumber(movie.length)) {
        check++;
    }
    if (nullName(movie.name)) {
        check++;
    }
    if (nullDescription(movie.description)) {
        check++;
    }
    if (validURL(movie.imageURL)) {
        document.getElementById("movie-url-error").innerHTML = "";
        check++;
    }
    else
    {
        document.getElementById("movie-url-error").innerHTML = "ImageURL is not valid!!";
    }
    if (check === 4) {
        return true;
    }

    return false;
    
}

function isRunningCheck(isRunningCheckBox) {
    if (isRunningCheckBox.checked) {
        return true;
    }
    return false;
}

function resetText() {
    $('#movie-name').val('');
    $('#movie-description').val('');
    $('#movie-length').val('');
    $('#movie-imageURL').val('');
}

function resetMovieErrorText() {
    document.getElementById("movie-url-error").innerHTML = "";
    document.getElementById("movie-length-error").innerHTML = "";
    document.getElementById("movie-name-error").innerHTML = "";
    document.getElementById("movie-description-error").innerHTML = "";
}
