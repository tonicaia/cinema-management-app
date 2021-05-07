const container = document.querySelector('.container2');
const seats = document.querySelectorAll('.row .seat:not(.occupied)');
const count = document.getElementById('count');
const submitButton = document.getElementById('submitButton');
submitButton.addEventListener("click", function () {
  console.log(seatsReserved);
});


let seatsReserved = [];

//Update total and count
function updateSelectedCount() {
  const selectedSeats = document.querySelectorAll('.row .seat.selected');
  const selectedSeatsCount = selectedSeats.length;
  count.innerText = selectedSeatsCount;
}

//Movie Select Event
//movieSelect.addEventListener('change', e => {
//  ticketPrice = +e.target.value;
//  updateSelectedCount();
//});

//Seat click event
container.addEventListener('click', e => {
  if (e.target.classList.contains('seat') &&
    !e.target.classList.contains('occupied')) {
    e.target.classList.toggle('selected');
    if (seatsReserved.includes(e.target.innerText)) {
      let indexToRemove = seatsReserved.indexOf(e.target.innerText);
      seatsReserved.splice(indexToRemove, 1);
    } else {
      seatsReserved.push(e.target.innerText);
    }
  }
  updateSelectedCount();
});

