let moviesList = document.getElementById('movies-list');

console.log(moviesList);

movies.forEach(movie => {

  moviesList.innerHTML += `
    <div id="movie">
        <h2 id="title" class="title">${movie.name}</h2>
        <img src="${movie.image}">
    </div>
        `;
});

