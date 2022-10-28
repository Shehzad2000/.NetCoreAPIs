var ApiUrl = "https://localhost:7299/api/User/";
$(document).ready(function () {

});
function UploadImage(image) {
    debugger;
    var url = window.location.origin;
    $.ajax({
        url: url + "/User/UploadedFile/",
        type: "POST",
        data: '{img:"' + image + '"}',
        contentType: false,
        processData: false,
        success: function (res) {
            return res.uniqueFileName;
        }, error(err) {
            alert(err.statusText);
        }
    });
}
//RegisterCategory
function RegisterUser() {
    debugger;
    var UserObj = {
        UserID: $('#hdnUserID').val(),
        UserName: $('#txt_UserName').val(),
        UserEmail: $('#txt_UserEmail').val(),
        UserContact: $('#txt_UserContact').val(),
        UserGender: $('#txt_Gender').val(),
        UserImage: UploadImage($('#Image').val()),
        UserCNIC: $('#UserCNIC').val(),
        UserAddress: $('#UserAddress').val(),
        UserStatus: $('#ddl_Status option:selected').val(),
    };
    $.ajax({
        url: ApiUrl + "UserRegisteration/",
        type:"Post",
        data: JSON.stringify(UserObj),
        contentType: "application/json;charset=utf-8",
        dataType: "Json",
        success: function (res) {
            alert("Data has been submitted successfully");
        }, error(err) {
            alert(err.responseText);
        }
    });
}
//Update SubCategory
function UpdateUserDetails() {
    var UserObj = {
        UserID: $('#hdnUserID').val(),
        UserName: $('#txt_UserName').val(),
        UserEmail: $('#txt_UserEmail').val(),
        UserContact: $('#txt_UserContact').val(),
        UserGender: $('#txt_Gender').val(),
        UserImage: $('#Image').val(),
        UserCNIC: $('#UserCNIC').val(),
        UserAddress: $('#UserAddress').val(),
        UserStatus: $('#ddl_Status option:selected').val(),
    };
    $.ajax({
        url: ApiUrl + "UserUpdate/",
        type: "Post",
        data: JSON.stringify(UserObj),
        contentType: "application/json;charset=utf-8",
        dataType: "Json",
        success: function (res) {
            alert("Data has been submitted successfully");
        }, error(err) {
            alert(err.responseText);
        }
    });
}
//AddAndUpdateSubCategory
function SubmitData() {
    debugger;
    if ($('#hdnUserID').val() != null)
        UpdateUserDetails();
    else
        RegisterUser();
}

//DeleteSubCategory
//function RemoveUser(ID) {
//    var userObj = {
//        UserID: ID
//    };
//    $.ajax({
//        url: ApiUrl + "",
//        type: "Post",
//        data: JSON.stringify(userObj),
//        contentType: "application/json;charset=utf-8",
//        dataType: "Json",
//        success: function (res) {
          
//        }, error(err) {
//            alert(err.responseText);
//        }
//    })

//}
//GetSubCategoryByID
//function GetAdminByID(ID) {
//    var adminObj = {
//        AdminID=ID,
//    };
//    $.ajax({
//        url: ApiUrl + "",
//        type: "Post",
//        data: JSON.stringify(adminObj),
//        contentType: "application/json;charset=utf-8",
//        dataType: "Json",
//        success: function (res) {
//            $('#hdnAdminID').val(res.adminID),
//                $('#txt_AdminName').val(res.adminImage),
//                $('#txt_AdminEmail').val(res.adminEmail),
//                $('#txt_AdminContact').val(res.adminContact),
//                $('#txt_Gender').val(res.adminGender),
//                $('#Image').val(res.adminImage),
//                $('#ddl_Status option:selected').val(res.adminStatus),
//        }, error(err) {
//            alert(err.responseText);
//        }
//    })
//}


//function LoadAdminDetails() {
//    $.ajax({
//        url: ApiUrl + "",
//        type: "Get",
//        contentType: "application/json;charset=utf-8",
//        dataType: "Json",
//        success: function (res) {
//            var html = '';
//            $.each(res, function (key, item) {
//                html += '<tr>';
//                html += '<td>' + item.adminImage + '</td>';
//                html += '<td>' + item.adminName + '</td>';
//                html += '<td>' + item.adminEmail + '</td>';
//                html += '<td>' + item.adminContact + '</td>';
//                html += '<td>' + item.adminGender + '</td>';
//                html += '<td>' + item.adminEmail + '</td>';
//                html += '<td>' + item.adminStatus + '</td>';
//                html += '<td><a href="#" class="btn btn-primary" onclick="GetSubCategoryByID(' + item.subCategoryId + ')"><i class="fa fa-edit"></i><span><strong> Edit</strong></span></a>&nbsp;&nbsp;<a href="#" class="btn btn-danger" onclick="RemoveSubCategory(' + item.subCategoryId + ')">  <i class="fa fa-trash"></i><span><strong> Delete</strong></span> </a></td>';
//                html += '</tr>'

//            });
//            $("#tbl_AdminDetails").html(html);
//        }, error: function (err) {
//            alert(err.responseText);
//        }

//    })
//}
