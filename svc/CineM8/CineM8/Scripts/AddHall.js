function AddHall() {

    const capacityTextBox = document.getElementById('hall-capacity');

    const hall = {
        capacity: capacityTextBox.value.trim(),
    };

    if (validHall(hall.capacity)) {
            fetch(HALLS_URL + "/PostNewHall", {
                method: 'POST',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(hall),
            })
                .then(response => response.json())
                .then((Message) => {
                    capacityTextBox.value = '';
                    alert(Message);
                    getAllHalls();
                })
                .catch(error => console.error('Unable to insert hall!', error));

    }
    else alert("Capacity input is wrong!!")
}

function validHall(capacity) {
    var x;
    return isNaN(capacity) ? !1 : (x = parseFloat(capacity), (0 | x) === x);
}