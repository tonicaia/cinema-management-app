
//Users
var $table = $('#table')
var $add = $('#add')
var $idOfUser


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
        '<button class="btn btn-info editUser" data-toggle="modal" data-target="#updateUserModal">',
        '<span class= "glyphicon glyphicon-edit" ></span >',
        '</button > ',
        '<button class="btn btn-outline-danger removeUser">',
        '<span class= "glyphicon glyphicon-trash" ></span >',
        '</button >'
    ].join('')
}

window.operateEvents = {
    'click .editUser': function (e, value, row, index) {
        idOfUser = row.Id;
        $('#user-firstname').val(row.FirstName);
        $('#user-lastname').val(row.LastName);
        $('#user-email').val(row.Email);
        resetUserErrorText();
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

var $doUpdate = false
var $idOfMovie
var $nameOfMovie
var $descriptionOfMovie
var $lengthOfMovie
var $imageURLOfMovie

function fillMoviesTable() {
    $('#movies-table').bootstrapTable({
        data: movies,
        columns: [{}, {}, {}, {},
            {
                title: 'isRunning',
                formatter : isRunningFormatter
            },
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
        '<button class="btn btn-info editMovie" data-toggle="modal" data-target="#addUpdateMovieModal">',
        '<span class= "glyphicon glyphicon-edit" ></span>',
        '</button> ',
        '<button class="btn btn-outline-danger removeMovie">',
        '<span class= "glyphicon glyphicon-trash" ></span>',
        '</button>'
    ].join('')
}

window.operateMovieEvents = {
    'click .editMovie': function (e, value, row, index) {
        doUpdate = true,

        idOfMovie = row.Id;
        $('#movie-name').val(row.Name);
        $('#movie-description').val(row.Description);
        $('#movie-length').val(row.Length);
        $('#movie-imageURL').val(row.ImageURL);
        resetMovieErrorText();
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

//Halls

function fillHallsTable() {
    $('#halls-table').bootstrapTable({
        data: halls,
        columns: [{}, {},
        {
            field: 'operate',
            title: 'Manage',
            align: 'center',
            valign: 'middle',
            clickToSelect: false,
            events: window.operateHallsEvents,
            formatter: operateHallsFormatter
        }
        ]

    });
    $('#halls-table').bootstrapTable('refresh')
}

function operateHallsFormatter(value, row, index) {
    return [
        '<button class="btn btn-outline-danger removeHall">',
        '<span class= "glyphicon glyphicon-trash" ></span>',
        '</button>'
    ].join('')
}

window.operateHallsEvents = {
    'click .removeHall': function (e, value, row, index) {
        deleteHall(row.Id);
        $('#halls-table').bootstrapTable('remove', {
            field: 'Id',
            values: [row.Id],
        })
    }
}

function deleteHall(id) {
    fetch(HALLS_URL + "/DeleteHall/" + id, {
        method: 'Delete',
    })
        .then(response => response.json())
    alert("Succes");
}

//Prices

function fillPriceTable() {
    $('#prices-table').bootstrapTable({
        data: prices,
        columns: [{}, {}, {}, {}]

    });
    $('#prices-table').bootstrapTable('refresh')
}