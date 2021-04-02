let moviesList = document.getElementById('movies-list');

function fillMoviesList() {
  let data = movies;

  data.forEach(movie => {
    console.log(movie);
    if (movie.IsRunning === true) {
      moviesList.innerHTML += `
      <div class="col-xs-6 col-md-3">
        <h2 class="title">${movie.Name}</h2>
        <a href="#"><img class="image" style="width:200px;height:300px" src="${movie.ImageURL}" /></a>
       </div>
      `;
    }
  });
}
