const USERS_URL = 'api/user';

let users;


$(document).ready(function () {
    getAllUsers();
  
});

function getAllUsers() {
    fetch(USERS_URL +"/getusers")
        .then(response => response.json())
        .then(data => {
            users = data;
            fillUsersTable();
        })
        .catch(error => console.error("Unable to get users", error));
}
function fillUsersTable() {
    $('#users-table').bootstrapTable({ data: users });
    $('#users-table').bootstrapTable('load', users);
}