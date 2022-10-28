

var ApiUrl = "https://localhost:7299/api/SubCategory/";
$(document).ready(function () {

});
//RegisterCategory
function RegisterAdmin() {
    var adminObj = {
        AdminID: $('#hdnAdminID').val(),
        AdminName: $('#txt_AdminName').val(),
        AdminEmail: $('#txt_AdminEmail').val(),
        AdminContact: $('#txt_AdminContact').val(),
        AdminGender: $('#txt_Gender').val(),
        AdminImage: $('#Image').val(),
        AdminStatus: $('#ddl_Status option:selected').val(),
    };
    $.ajax({
        url: ApiUrl + "",
        type="Post",
        data: JSON.stringify(adminObj),
        contentType: "application/json;charset=utf-8",
        dataType: "Json",
        success: function (res) {
            LoadAdminDetails();
        }, error(err) {
            alert(err.responseText);
        }
    });
}
//Update SubCategory
function UpdateAdminDetails() {
    var adminObj = {
        AdminID: $('#hdnAdminID').val(),
        AdminName: $('#txt_AdminName').val(),
        AdminEmail: $('#txt_AdminEmail').val(),
        AdminContact: $('#txt_AdminContact').val(),
        AdminGender: $('#txt_Gender').val(),
        AdminImage: $('#Image').val(),
        AdminStatus: $('#ddl_Status option:selected').val(),
    };
    $.ajax({
        url: ApiUrl + "",
        type: "Post",
        data: JSON.stringify(adminObj),
        contentType: "application/json;charset=utf-8",
        dataType: "Json",
        success: function (res) {
            LoadAdminDetails();
        }, error(err) {
            alert(err.responseText);
        }
    });
}
//AddAndUpdateSubCategory
function SubmitData() {
    if ($('#hdnAdminID').val() != null)
        UpdateAdminDetails();
    else
        RegisterAdmin();
}

//DeleteSubCategory
function RemoveAdmin(ID) {
    var adminObj = {
        AdminID: ID
    };
    $.ajax({
        url: ApiUrl + "",
        type: "Post",
        data: JSON.stringify(adminObj),
        contentType: "application/json;charset=utf-8",
        dataType: "Json",
        success: function (res) {
            LoadAdminDetails();
        }, error(err) {
            alert(err.responseText);
        }
    })

}
//GetSubCategoryByID
function GetAdminByID(ID) {
    var adminObj = {
        AdminID=ID,
    };
    $.ajax({
        url: ApiUrl + "",
        type: "Post",
        data: JSON.stringify(adminObj),
        contentType: "application/json;charset=utf-8",
        dataType: "Json",
        success: function (res) {
                $('#hdnAdminID').val(res.adminID),
                $('#txt_AdminName').val(res.adminImage),
                $('#txt_AdminEmail').val(res.adminEmail),
                $('#txt_AdminContact').val(res.adminContact),
                $('#txt_Gender').val(res.adminGender),
                $('#Image').val(res.adminImage),
                $('#ddl_Status option:selected').val(res.adminStatus),
        }, error(err) {
            alert(err.responseText);
        }
    })
}


function LoadAdminDetails() {
    $.ajax({
        url: ApiUrl + "",
        type: "Get",
        contentType: "application/json;charset=utf-8",
        dataType: "Json",
        success: function (res) {
            var html = '';
            $.each(res, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.adminImage + '</td>';
                html += '<td>' + item.adminName + '</td>';
                html += '<td>' + item.adminEmail + '</td>';
                html += '<td>' + item.adminContact + '</td>';
                html += '<td>' + item.adminGender + '</td>';
                html += '<td>' + item.adminEmail + '</td>';
                html += '<td>' + item.adminStatus + '</td>';
                html += '<td><a href="#" class="btn btn-primary" onclick="GetSubCategoryByID(' + item.subCategoryId + ')"><i class="fa fa-edit"></i><span><strong> Edit</strong></span></a>&nbsp;&nbsp;<a href="#" class="btn btn-danger" onclick="RemoveSubCategory(' + item.subCategoryId + ')">  <i class="fa fa-trash"></i><span><strong> Delete</strong></span> </a></td>';
                html += '</tr>'

            });
            $("#tbl_AdminDetails").html(html);
        }, error: function (err) {
            alert(err.responseText);
        }

    })
}
