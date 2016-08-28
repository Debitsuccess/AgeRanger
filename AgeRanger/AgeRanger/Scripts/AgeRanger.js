$(document).ready(function () {
    setup();
});

var editor;

function setup() {

    $.validator.addMethod('positiveNumber',
            function (value) {
                return Number(value) > 0;
            }, 'Please enter a positive number.');

    var validator = $("#addNewForm").validate({
        rules: {
            firstnamen: {
                required: true
            },
            lastnamen: {
                required: true
            },
            agen: {
                required: true,
                positiveNumber: true
            }
        }
    });

    var validator = $("#editForm").validate({
        rules: {
            firstname: {
                required: true
            },
            lastname: {
                required: true
            },
            age: {
                required: true,
                positiveNumber: true
            }
        }
    });
    
    console.log("creating model");
    var model = new Model();
    console.log("calling setup");
    model.setup();
}

var personViewModel = function () {
    console.log("in personViewModel");
    var self = this;
    self.Id = ko.observable();
    self.FirstName = ko.observable();
    self.LastName = ko.observable();
    self.Age = ko.observable();
    self.AgeGroup = ko.observable();
    
    console.log("in personViewModel-done");
};

function Model() {

    var self = this;
    console.log("1");
    self.currentRow = ko.observable();
    console.log("3");

    self.setup = function() {
        console.log("2");

        self.currentRow(new personViewModel());
        ko.applyBindings(self.currentRow, $('#editModal').get(0));
        ko.applyBindings(self.currentRow, $('#newModal').get(0));

        self.table = $('#people').dataTable({
            "bJQueryUI": true,
            "bProcessing": true,
            "bServerSide": true,
            "sAjaxSource": "api/People/GetPeople",
            "paging": true,
            "bInfo": false,
            "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "All"]],
            "aoColumns": [
                { "data": "Id" },
                { "data": "FirstName" },
                { "data": "LastName" },
                { "data": "Age" },
                { "data": "AgeGroup" },
                {
                    data: null,
                    className: "center",
                    defaultContent: '<a href="">Edit</a>'
                }
            ],
            "columnDefs": [
                {
                    "targets": [ 0 ],
                    "visible": false,
                    "searchable": false
                }
            ]
        });

        // Edit record
        $('#people').on('click', 'tr', function (e) {
            e.preventDefault();

            var table = $('#people').DataTable();
            console.log(table.row(this).data());

            if (table.row(this).data() === undefined) {
                console.log('not a data row');
            }
            else {
                self.currentRow(ko.mapping.fromJS(table.row(this).data()));
                console.log(self.currentRow().FirstName());
                $('#editModal').modal('show');
            }
        });

        // Add new
        $('#buttonAddNew').on('click', function (e) {
            e.preventDefault();

            self.currentRow(ko.mapping.fromJS(new personViewModel()));
            console.log("Add : '" + self.currentRow().FirstName()+"'");

            $('#newModal').modal('show');
        });
    }

    // Update
    $('#buttonUpdate').on('click', function (e) {

        e.preventDefault();
        console.log("row 2 update: " + self.currentRow().FirstName() + ", " + self.currentRow().Id());
        
        if (!$('#editForm').valid()) {
            return;
        }

        $('#editModal').modal('hide');

        var data = ko.toJSON(self.currentRow);
        console.log("Update: " + data);
        console.log("update: " + data.FirstName + ", " + data.Id);

        $.ajax({
            method: "PUT",
            url: "api/People/PutPerson/" + self.currentRow().Id(),
            contentType: "application/json",
            data: data,
        }).done(function () {
            console.log('Update person details - done');
            self.table.api().ajax.reload();
            console.log('reloaded');
        }).fail(function () {
            alert("error");
        });
        console.log("ajax called");
    });

    // Add
    $('#buttonAdd').on('click', function (e) {

        e.preventDefault();
        console.log("row 2 add: " + self.currentRow().FirstName() + ", " + self.currentRow().Id());
        console.log("valid: " + $('#addNewForm').valid());

        if (!$('#addNewForm').valid()) {
            return;
        }

        $('#newModal').modal('hide');

        var data = ko.toJSON(self.currentRow);
        console.log("Add new: " + data.FirstName + ", " + data.Id);

        $.ajax({
            method: "POST",
            url: "api/People/PostPerson",
            contentType: "application/json",
            data: data,
        }).done(function () {
            console.log('Add new person - done');
            self.table.api().ajax.reload();
            console.log('reloaded');
        }).fail(function () {
            alert("error");
        });
        console.log("ajax called");
    });
}