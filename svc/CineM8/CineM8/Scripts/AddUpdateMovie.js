const { checked } = require("modernizr");

function AddUpdateMovie() {

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
                    imageURL.value = '';
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
                    imageURL.value = '';
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
        return true;
    }
    else {
        return false;
    }
}

function nullName(name)
{
    if (!isEmpty(name))
    {
        return true;
    }
    else {
        return false;
    }
}
function nullDescription(description)
{
    if (!isEmpty(description))
    {
        return true;
    }
    else
    {
        return false;
    }

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
        if (nullName(movie.name))
        {
            if (nullDescription(movie.description)) {
               if (validURL(movie.imageURL)) {
                    return true;
                }
                else
                {
                    alert("ImageURL is not valid!!");
                }
            }
            else {
                alert("Description field should not be empty!!");
            }
        }
        else
        {
            alert("Name field should not be empty!!");
        }
    }
    else
    {
        alert("Length input should be only a number!!");
    }
}

function isRunningCheck(isRunningCheckBox) {
    if (isRunningCheckBox.checked) {
        return true;
    }
    else return false;
}

function resetText() {
    $('#movie-name').val('');
    $('#movie-description').val('');
    $('#movie-length').val('');
    $('#movie-imageURL').val('');
}