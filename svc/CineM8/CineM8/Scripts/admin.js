
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
            title: 'Edit',
            align: 'center',
            valign: 'middle',
            clickToSelect: false,
            formatter: function (value, row, index) {
                //return '<input name="elementname"  value="'+value+'"/>';
                return '<button class=\'btn btn-primary \' pageName="' + row.name + '" pageDetails="' + row.price + '"  > Edit </button> ';
            }
        }
        ]
    });
    //$('#users-table').bootstrapTable('load', users);
}

$(".btn").click(function () {
    alert("LIK");
    var pageDetails = $(this).attr('pageDetails');
    var pageName = $(this).attr('pageName');
    $(".modal .modal-title").html(pageName);
    $(".modal .modal-body").html(pageDetails);
    $(".modal").modal("show");

});