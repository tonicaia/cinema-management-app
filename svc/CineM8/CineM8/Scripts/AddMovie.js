const { checked } = require("modernizr");

function AddMovie() {
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

    console.log(isRunningCheckBox.value);
    if (validMovie(movie)) {
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
function nullImageURL(imageURL)
{
    if (!isEmpty(imageURL))
    {
        return true;
    }
    else
    {
        return false;
    }

}

function validMovie(movie)
{
    if (isNumber(movie.length)) {
        if (nullName(movie.name))
        {
            if (nullDescription(movie.description)) {
                if (nullImageURL(movie.imageURL)) {
                    return true;
                }
                else
                {
                    alert("ImageURL field should not be empty!!");
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