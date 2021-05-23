const container = document.querySelector('.container2');
const seats = document.querySelectorAll('.row .seat:not(.occupied)');
const count = document.getElementById('count');
const submitButton = document.getElementById('submitButton');
const dateDropdown = document.getElementById('dropdown-content');
const video = document.getElementById('iframe-d');

let allSeats = [];
let seatsBits = [];
let selectedDate = '';
let endTimeInObj = '';

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
  if (sessionStorage.currentUserId && selectedDate !== '') {
    console.log(seatsReserved);

    seatsReserved.forEach(seat => seatsBits[seat - 1] = 1);

    console.log(seatsBits);
    let userId = sessionStorage.currentUserId;
    let movieId = document.getElementById('id-number').innerHTML;
    console.log(userId);
    console.log(movieId);

    let reservation = {
      userId: userId,
      movieId: movieId,
      cinemaHallId: 3,
      numberOfSeats: seatsReserved.length,
      seatsNumbers: seatsBits.toString(),
      startTime: selectedDate,
      endTime: endTimeInObj
    };

    console.log(reservation);

    fetch('https://localhost:44300/api/reservation/PostNewReservation', {
      method: 'POST',
      headers: {
        'Accept': 'application/json',
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(reservation)
    }).then(response => response.json())
      .catch(error => console.error('Unable to insert reservation!', error));

    alert('Success! See you at the cinema!');
    for (let i = 0; i < allSeats; i++) {
      seatsBits[i] = 0;
    }
  } else if (!sessionStorage.currentUserId) {
    alert('You must be logged in for creating a reservation');
  } else if (!selectedDate) {
    alert('You must select an date and time for the movie');
  }
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

dateDropdown.addEventListener('click', e => {
  console.log(e.target.innerHTML);
  selectedDate = e.target.innerHTML;

  let hour = selectedDate.slice(11, 13);
  let newHour = +hour + 2;
  let endTime = selectedDate.slice(0, 11);
  endTime = endTime + newHour.toString() + ':00:00';
  endTimeInObj = endTime;

  let dateElement = document.getElementById('movie-date');
  let date = selectedDate.slice(0, 10);
  dateElement.innerHTML = `Movie date: ${date}`;

  let timeElement = document.getElementById('movie-time');
  let startTime = selectedDate.slice(11, 19);
  let endTimeInFct = endTime.slice(11, 19);
  timeElement.innerHTML = `from ${startTime} to ${endTimeInFct}`;
});
