var grid, editDialog, deleteDialog, el;

function Edit(e) {
    cretedOn.value(e.data.record.CreatedOn);
    $('#Email').val(e.data.record.Email);
    $('#UserName').val(e.data.record.UserName);
    $('#FirstName').val(e.data.record.FirstName);
    $('#LastName').val(e.data.record.LastName);
    editDialog.open('Edit User');
}

function Save() {
    var record = {
        CreatedOn: gj.core.parseDate(cretedOn.value(), 'mm/dd/yyyy').toISOString(),
        Email: $('#Email').val(),
        UserName: $('#UserName').val(),
        LastName: $('#LastName').val(),
        Firstname: $('#FirstName').val(),
    };

    $.ajax({ url: '/Administration/Home/UserSave', data: { record: record }, method: 'POST' })
        .done(function () {
            grid.reload();
        })
        .fail(function () {
            alert('Failed to save.');
        });
}

function Delete(e) {
    $.ajax({ url: '/Administration/Home/UserDelete', data: { id: e.data.id }, method: 'POST' })
        .done(function () {
            grid.reload();
        })
        .fail(function () {
            alert('Failed to delete.');
        });
}

function Confirm(e) {
    el = e;
    deleteDialog.open();
}

$(document).ready(function () {

    grid = $('#grid').grid({
        title: 'Users',
        responsive: true,
        primaryKey: 'UserName',
        dataSource: '/Administration/Home/GetUsers',
        selectionMethod: 'checkbox',
        columns: [
            { field: 'UserName', title: 'Username', sortable: true },
            { field: 'FirstName', title: 'First name', sortable: true },
            { field: 'LastName', title: 'Last name', sortable: true },
            { field: 'Email', title: 'Email', sortable: true },
            { field: 'CreatedOn', title: 'Registration date', sortable: true, type: 'date' },
            { width: 64, tmpl: '<span class="material-icons gj-cursor-pointer">edit</span>', align: 'center', events: { 'click': Edit } },
            { width: 64, tmpl: '<span class="material-icons gj-cursor-pointer">delete</span>', align: 'center', events: { 'click': Confirm } }
        ],
        pager: { limit: 5 }
    });

    editDialog = $('#edit-dialog').dialog({
        uiLibrary: 'materialdesign',
        autoOpen: false,
        resizable: false,
        modal: true,
    });

    deleteDialog = $("#delete-dialog").dialog({
        uiLibrary: 'materialdesign',
        autoOpen: false,
        resizable: true,
        modal: true
    });

    cretedOn = $('#CreatedOn').datepicker();

    $('#btnSave').on('click', function () {
        Save();
        editDialog.close();
    });

    $('#btnCancel').on('click', function () {
        $('[role=calendar]').hide();
        editDialog.close();
    });

    $("#btnYes").on('click', function () {
        Delete(el);
        deleteDialog.close();
    })
});
