$(document).ready(function () {
    getAllUsers();
  
});

function getAllUsers() {
    fetch(USERS_URL +"/getall")
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
        alert("delete this");
    }
}