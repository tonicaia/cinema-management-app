let moviesList = document.getElementById('movies-list');

function fillMoviesList() {
  let data = movies;

  data.forEach(movie => {
    console.log(movie);
    if (movie.IsRunning === true) {
      moviesList.innerHTML += `
      <div class="card col-xs-6 col-md-3">
        <div class="image">
          <img src="${movie.ImageURL}" class="movie-image" style="width:200px;height:300px" />
        </div>
            <a class="btn btn-primary" id="rezerva-button${movie.Id}" href="https://localhost:44300/movies/show/${movie.Id}">Rezerva</a>
       </div>
      `;
    }
  });

  //if (!sessionStorage.currentUserId) {
  //  movies.forEach(movie => {
  //    document.getElementById('rezerva-button' + movie.Id).style.display = "none";
  //  }
  //  )
  //}
  
}
