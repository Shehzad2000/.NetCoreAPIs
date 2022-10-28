

var ApiUrl = "https://localhost:7299/api/Company/";



$(document).ready(function () {

    LoadCompany();

});
function LoadCompany() {

    $.ajax({
        url: ApiUrl + "GetAllCompaniesDetails/",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",

        success: function (res) {

            var html = '';
            $.each(res, function (key, item) {
                html += '<tr>';
               
                html += '<td>' + item.companyName + '</td>';
                html += '<td>' + item.status + '</td>';
                html += '<td><a href="#" class="btn btn-primary" onclick="GetByID(' + item.companyID + ')"><i class="fa fa-edit"></i><span><strong> Edit</strong></span></a>&nbsp;&nbsp;<a href="#" class="btn btn-danger" onclick="DeleteCategory(' + item.companyID + ')">  <i class="fa fa-trash"></i><span><strong> Delete</strong></span> </a></td>';
                html += '</tr>'

            });
            $(".tbl_CompanyDetails").html(html);
        },
        error: function (err) {
            alert(err.responseText);
        }

    });
}

function ClearTextBoxes() {
   
    $('#hdnCompanyID').val("");
    $('#txt_CompanyName').val("");
    $('#ddlStatus').val(-1);
}

function AddCompany() {
    debugger;
    ID = document.getElementById("hdnCompanyID").value;
    if (ID>0)
        UpdateCompany();
    else {
        var companyObj = {
            Status: $('#ddlStatus option:selected').val(),
            companyName: $('#txt_CompanyName').val(),
        };
        $.ajax({
            url: ApiUrl + "RegisterCompany/",
            type: "Post",
            data: JSON.stringify(companyObj),
            contentType: "application/json;charset:utf-8",
            dataType: "Json",
            success: function (res) {
                LoadCompany();
                ClearTextBoxes();
            },
            error: function (err) {
                alert(err.responseText);
            }
        });
    }


}

function GetByID(ID) {
    debugger;
    var companyObj = {
        CompanyID: ID,
    };
    $.ajax({
        url: ApiUrl + "GetCompany/",
        type: "Post",
        contentType: "application/json;charset=utf-8",
        data: JSON.stringify(companyObj),
        Datatype: "Json",
        success: function (res) {
            $("#MyModal").modal('show');
            $('#hdnCompanyID').val(res.companyID);
            $('#txt_CompanyName').val(res.companyName);
            $('#ddlStatus option:selected').val(res.status);
        },
        error: function (err) {
            alert(err.responseText);
        }

    });
}

function UpdateCompany() {
    var companyObj = {
        CompanyID: $('#hdnCompanyID').val(),
        Status: $('#ddlStatus option:selected').val(),
        CompanyName: $('#txt_CompanyName').val(),
    };
    $.ajax({
        url: ApiUrl + "UpdateCompanyDetails/",
        data: JSON.stringify(companyObj),
        type: "Post",
        contentType: "application/json;charset=utf-8",
        dataType: "Json",
        success: function (res) {
            $("#MyModal").modal('hide');
            LoadCompany();
         
        },
        error: function (err) {
            alert(err.responseText);
        }
    });
}

function DeleteCompanyDetails(ID) {
    if (confirm("Do you want to delete this item?")) {
        debugger;
        var companyObj = {
            CompanyID: ID,
        };
        $.ajax({
            url: ApiUrl + "RemoveCompany/",
            type: "Post",
            contentType: "application/json;charset=utf-8",
            data: JSON.stringify(companyObj),
            dataType: "Json",
            success: function (res) {
                LoadCompany();
            },
            error: function (err) {
                alert(err.responseText);
            }
        });
    }

}