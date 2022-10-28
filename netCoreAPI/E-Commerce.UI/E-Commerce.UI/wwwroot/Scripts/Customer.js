

var ApiUrl = "https://localhost:7299/api/Customer/";
$(document).ready(function () {

});
//RegisterCategory
function RegisterCustomer() {
    debugger;
    var customerObj = {
        CustomerName: $('#txt_CustomerName').val(),
        CustomerEmail: $('#txt_CustomerEmail').val(),
        CustomerContact: $('#txt_CustomerContact').val(),
        CustomerAddress: $('#txt_CustomerAddress').val(),
      
    };
    $.ajax({
        url: ApiUrl + "RegisterCustomer/",
        data: JSON.stringify(customerObj),
        type: "POST",
        headers: {
            "Accept": "application/json",
            "Content-Type":"application/json"
        },
        dataType: "Json",
        success: function (res) {
            LoadCustomerDetails();
        }, error(err) {
            alert(err.responseText);
        }
    });
}
//Update SubCategory
//function UpdateCustomerDetails() {
//    var CustomerObj = {
//        CustomerID: $('#hdnCustomerID').val(),
//        CustomerName: $('#txt_CustomerName').val(),
//        CustomerEmail: $('#txt_CustomerEmail').val(),
//        CustomerContact: $('#txt_CustomerContact').val(),
//        CustomerGender: $('#txt_Gender').val(),
//        CustomerImage: $('#Image').val(),
//        CustomerStatus: $('#ddl_Status option:selected').val(),
//    };
//    $.ajax({
//        url: ApiUrl + "",
//        type: "Post",
//        data: JSON.stringify(CustomerObj),
//        contentType: "application/json;charset=utf-8",
//        dataType: "Json",
//        success: function (res) {
//            LoadCustomerDetails();
//        }, error(err) {
//            alert(err.responseText);
//        }
//    });
//}
//AddAndUpdateSubCategory
function SubmitData() {
    debugger;
    if ($('#hdnCustomerID').val() != "")
        UpdateCustomerDetails();
    else
        RegisterCustomer();
}

//DeleteSubCategory
//function RemoveCustomer(ID) {
//    var CustomerObj = {
//        CustomerID: ID
//    };
//    $.ajax({
//        url: ApiUrl + "",
//        type: "Post",
//        data: JSON.stringify(CustomerObj),
//        contentType: "application/json;charset=utf-8",
//        dataType: "Json",
//        success: function (res) {
//            LoadCustomerDetails();
//        }, error(err) {
//            alert(err.responseText);
//        }
//    })

//}
////GetSubCategoryByID
//function GetCustomerByID(ID) {
//    var CustomerObj = {
//        CustomerID:ID,
//    };
//    $.ajax({
//        url: ApiUrl + "",
//        type: "Post",
//        data: JSON.stringify(CustomerObj),
//        contentType: "application/json;charset=utf-8",
//        dataType: "Json",
//        success: function (res) {
//            $('#hdnCustomerID').val(res.CustomerID),
//                $('#txt_CustomerName').val(res.CustomerImage),
//                $('#txt_CustomerEmail').val(res.CustomerEmail),
//                $('#txt_CustomerContact').val(res.CustomerContact),
//                $('#txt_Gender').val(res.CustomerGender),
//                $('#Image').val(res.CustomerImage),
//                $('#ddl_Status option:selected').val(res.CustomerStatus)
//        },error(err) {
//            alert(err.responseText);
//        }
//    })
//}


//function LoadCustomerDetails() {
//    $.ajax({
//        url: ApiUrl + "",
//        type: "Get",
//        contentType: "application/json;charset=utf-8",
//        dataType: "Json",
//        success: function (res) {
//            var html = '';
//            $.each(res, function (key, item) {
//                html += '<tr>';
//                html += '<td>' + item.CustomerImage + '</td>';
//                html += '<td>' + item.CustomerName + '</td>';
//                html += '<td>' + item.CustomerEmail + '</td>';
//                html += '<td>' + item.CustomerContact + '</td>';
//                html += '<td>' + item.CustomerGender + '</td>';
//                html += '<td>' + item.CustomerEmail + '</td>';
//                html += '<td>' + item.CustomerStatus + '</td>';
//                html += '<td><a href="#" class="btn btn-primary" onclick="GetSubCategoryByID(' + item.subCategoryId + ')"><i class="fa fa-edit"></i><span><strong> Edit</strong></span></a>&nbsp;&nbsp;<a href="#" class="btn btn-danger" onclick="RemoveSubCategory(' + item.subCategoryId + ')">  <i class="fa fa-trash"></i><span><strong> Delete</strong></span> </a></td>';
//                html += '</tr>'

//            });
//            $("#tbl_CustomerDetails").html(html);
//        }, error: function (err) {
//            alert(err.responseText);
//        }

//    })
//}
