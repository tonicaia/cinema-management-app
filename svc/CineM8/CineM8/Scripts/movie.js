const container = document.querySelector('.container2');
const seats = document.querySelectorAll('.row .seat:not(.occupied)');
const count = document.getElementById('count');
const submitButton = document.getElementById('submitButton');

let allSeats = [];
let seatsBits = [];

const places = document.getElementById('places');

function getHall() {
  fetch('https://localhost:44300/api/halls/GetHall', {
    method: 'Get',
  })
    .then(response => response.json())
    .then(data => allSeats = data[1].Capacity)
    .then(() => {
      for (let i = 0; i < allSeats; i++) {
        seatsBits.push(0);
      }
    })
    .then(() => {
      let seatIndex = 1;
      let stopIndex = 11;
      for (let i = 1; i <= 8; i++) {
        places.innerHTML += `
          <div class="row" id="row${i}">
        `;
        let row = document.getElementById('row' + i);

        for (let i = seatIndex; i <= stopIndex; i++) {
          row.innerHTML += `
          <div class="seat">${i}</div>
        `;
          seatIndex++;
        }
        places.innerHTML += `
          </div>
        `;
        stopIndex += 11;
      }
    })
}

getHall();

submitButton.addEventListener("click", function () {
  console.log(seatsReserved);

  seatsReserved.forEach(seat => seatsBits[seat - 1] = 1);

  console.log(seatsBits);

  const reservation = {
    userId: 4,
    movieId: 2,
    cinemaHallId: 3,
    numberOfSeats: seatsReserved.length,
    seatsNumbers: seatsBits.toString(),
    startTime: "2021-01-01 12:00:00",
    endTime: "2021-01-01 12:00:00"
  };

  fetch('https://localhost:44300/api/reservation/PostNewReservation', {
    method: 'POST',
    headers: {
      'Accept': 'application/json',
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(reservation),
  }).then(response => response.json())
    .catch(error => console.error('Unable to insert reservation!', error));
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
