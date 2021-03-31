
//Users
var $table = $('#table')
var $add = $('#add')

﻿$(document).ready(function () {

    getAllUsers();

});

function getAllUsers() {
    fetch(USERS_URL + "/getall")
        .then(response => response.json())
        .then(data => {
            users = data;
            fillUsersTable();
        })
        .catch(error => console.error("Unable to get users", error));
}
function fillUsersTable() {
    $('#users-table').bootstrapTable({
        data: users,
        columns: [{}, {}, {}, {},
        {
            field: 'operate',
            title: 'Manage',
            align: 'center',
            valign: 'middle',
            clickToSelect: false,
            events: window.operateEvents,
            formatter: operateFormatter

        }]
    });
}

function operateFormatter(value, row, index) {
    return [
        '<button class="btn btn-info editUser">',
        '<span class= "glyphicon glyphicon-edit" ></span >',
        '</button > ',
        '<button class="btn btn-outline-danger removeUser">',
        '<span class= "glyphicon glyphicon-trash" ></span >',
        '</button >'
    ].join('')
}

window.operateEvents = {
    'click .editUser': function (e, value, row, index) {
        alert('You are editing row: ' + JSON.stringify(row))
    },
    'click .removeUser': function (e, value, row, index) {
        deleteUser(row.Id);
        $('#users-table').bootstrapTable('remove', {
            field: 'Id',
            values: [row.Id]
        })
    }
}
function deleteUser(id) {
    fetch(USERS_URL + "/delete/" + id, {
        method: 'Delete',
    })
        .then(response => response.json())
    alert("Succes");
}

// Movies


function getAllMovies() {
    fetch(MOVIES_URL + "/GetMovie")
        .then(response => response.json())
        .then(data => {
            movies = data;
            console.log(movies)
            fillMoviesTable();
        })
        .catch(error => console.error("Unable to get movies", error));
}

function fillMoviesTable() {
    $('#movies-table').bootstrapTable({
        data: movies,
        columns: [{}, {}, {}, {},
            {
                title: 'isRunning',
                formatter : isRunningFormatter
            },
            {},
            {
                field: 'operate',
                title: 'Manage',
                align: 'center',
                valign: 'middle',
                clickToSelect: false,
                events: window.operateMovieEvents,
                formatter: operateMovieFormatter
            }
        ]
  
    });
    $('#movies-table').bootstrapTable('refresh')
}

function isRunningFormatter(value, row, index) {
    var isChecked = row.IsRunning;
    if (isChecked) {
        return ['<input onclick="changeIsRunningStatus(\'' + row.Id +'\')" type="checkbox" checked>']
    }
    else {
        return ['<input onclick="changeIsRunningStatus(\'' + row.Id +'\')" type="checkbox">']
    }
}
function operateMovieFormatter(value, row, index) {
    return [
        '<button class="btn btn-info editMovie">',
        '<span class= "glyphicon glyphicon-edit" ></span>',
        '</button> ',
        '<button class="btn btn-outline-danger removeMovie">',
        '<span class= "glyphicon glyphicon-trash" ></span>',
        '</button>'
    ].join('')
}

window.operateMovieEvents = {
    'click .editMovie': function (e, value, row, index) {
        alert('You are editing row: ' + JSON.stringify(row))
    },
    'click .removeMovie': function (e, value, row, index) {
        deleteMovie(row.Id);
        $('#movies-table').bootstrapTable('remove', {
            field: 'Id',
            values: [row.Id],
        })
    }
}

function deleteMovie(id) {
    fetch(MOVIES_URL + "/DeleteMovie/" + id, {
        method: 'Delete',
    })
        .then(response => response.json())
    alert("Succes");
}


function changeIsRunningStatus(id) {
    var movie;
    movies.map(m => {
        if (m.Id == id) {
            movie = m;
        }
    });
    movie.IsRunning = !movie.IsRunning;
    fetch(MOVIES_URL + "/UpdateMovie/" + id, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(movie)
    })
        .then(response => response.json())
        .then((Message) => {
            alert(Message);
        })
        .catch(error => console.error('Unable to add item.', error));
}