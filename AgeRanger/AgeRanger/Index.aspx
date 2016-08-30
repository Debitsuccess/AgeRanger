<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="AgeRanger.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AgeRanger</title>
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>

    <link rel="stylesheet" href="/Content/bootstrap.min.css"/>
    <link rel="stylesheet" href="/Content/bootstrap-theme.min.css"/>
    <link rel="stylesheet" href="/Content/DataTables/css/jquery.dataTables.min.css"/>

    <script src="/Scripts/jquery-1.9.1.min.js"></script>
    <script src="/Scripts/jquery.validate.js"></script>
    <script src="/Scripts/bootstrap.min.js"></script>
    <script src="/Scripts/knockout-3.4.0.js"></script>
    <script src="/Scripts/knockout.mapping-latest.js"></script>
    <script src="/Scripts/DataTables/jquery.dataTables.js"></script>
    <script src="/Scripts/DataTables/dataTables.bootstrap.min.js"></script>
    
    <script src="/Scripts/ageRanger.js"></script>

    <style type="text/css">
        .error {
            color: Red;           
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">Age Ranger</div>
        <div class="panel-body">
            <table id="people" class="table table-striped table-bordered" cellspacing="0" width="100%">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>First Name</th>
                        <th>Last Name</th>
                        <th>Age</th>
                        <th>Age Group</th>
                        <th>Action</th>
                    </tr>
                </thead>
                <tbody></tbody>
            </table>
        </div>
        <div class="panel-footer">
            <button class="btn btn-primary pull-right" id = "buttonAddNew" >Add New</button>
            <div class="clearfix"></div>
        </div>
    </div>
    </form>

    <!-- ko with: currentRow -->
    <div class="modal fade" id="editModal" tabindex="-1" role="dialog" aria-labelledby="editModalLabel">
      <div class="modal-dialog" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
            <h4 class="modal-title" id="editModalLabel">Edit Person details</h4>
          </div>
          <div class="modal-body">
            <form id="editForm">
              <div class="form-group">
                <label for="first-name" class="control-label">First Name:</label>
                <input type="text" class="form-control" name="firstname" id="first-name" data-bind="value: FirstName">
              </div>
              <div class="form-group">
                <label for="last-name" class="control-label">Last Name:</label>
                <input type="text" class="form-control" name="lastname" id="last-name" data-bind="value: LastName">
              </div>
               <div class="form-group">
                <label for="age" class="control-label">Age:</label>
                <input type="text" class="form-control" name="age" id="age" data-bind="value: Age">
              </div>
            </form>
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
            <button type="button" class="btn btn-primary" id = "buttonUpdate" >Save changes</button>
            <%--<button type="button" class="btn btn-primary" id = "buttonUpdate" data-bind="click: function(data, event){ $parent.update() }">Save changes</button>--%>
          </div>
        </div>
      </div>
    </div>

    <div class="modal fade" id="newModal" tabindex="-1" role="dialog" aria-labelledby="newModalLabel">
      <div class="modal-dialog" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
            <h4 class="modal-title" id="newModalLabel">Add new Person</h4>
          </div>
          <div class="modal-body">
            <form id="addNewForm">
              <div class="form-group">
                <label for="first-name" class="control-label">First Name:</label>
                <input type="text" class="form-control" name="firstnamen" id="firstnamen" data-bind="value: FirstName">
              </div>
              <div class="form-group">
                <label for="last-name" class="control-label">Last Name:</label>
                <input type="text" class="form-control" name="lastnamen" id="lastnamen" data-bind="value: LastName">
              </div>
               <div class="form-group">
                <label for="age" class="control-label">Age:</label>
                <input type="text" class="form-control" name="agen" id="agen" data-bind="value: Age">
              </div>
            </form>
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
            <button type="button" class="btn btn-primary" id = "buttonAdd" >Save changes</button>
          </div>
        </div>
      </div>
    </div>
    <!-- /ko -->
</body>
</html>
