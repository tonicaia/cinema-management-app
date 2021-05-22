function AddPrice() {

    const priceTextBox = document.getElementById('price-amount');
    const descriptionTextBox = document.getElementById('description');
    const weekendCheckBox = document.getElementById('weekend');

    const price = {
        priceAmount: priceTextBox.value.trim(),
        description: descriptionTextBox.value,
        weekend: weekendCheckBox.checked ? '1' : '0'
    };

    if (validPrice(price)) {
        fetch(PRICE_URL + "/PostNewPrice", {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(price),
        })
            .then(response => response.json())
            .then((Message) => {
                priceTextBox.value = '';
                descriptionTextBox.value = '';
                weekendCheckBox.checked = false;
                alert(Message);
                getAllPrices();
            })
            .catch(error => console.error('Unable to insert price!', error));
    }
    document.getElementById("price-error").innerHTML = "input is wrong!!";
}

function validPrice(price) {
    var x;
    return isNaN(price.priceAmount) ? !1 : (x = parseFloat(price.priceAmount), (0 | x) === x);
}

function resetPriceErrorText() {
    document.getElementById("price-error").innerHTML = "";
}