

var ApiUrl = "https://localhost:7299/api/Category/";



$(document).ready(function () {

    LoadCategory();

});

function LoadCategory() {
    $.ajax({
        url: ApiUrl+"GetCategories/",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",

        success: function (res) {

            var html = '';
            $.each(res, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.categoryID + '</td>';
                html += '<td>' + item.categoryName + '</td>';
                html += '<td>' + item.status + '</td>';
                html += '<td><a href="#" class="btn btn-primary" onclick="GetByID(' + item.categoryID + ')"><i class="fa fa-edit"></i><span><strong> Edit</strong></span></a>&nbsp;&nbsp;<a href="#" class="btn btn-danger" onclick="DeleteCategory(' + item.categoryID + ')">  <i class="fa fa-trash"></i><span><strong> Delete</strong></span> </a></td>';
                html += '</tr>'

            });
            $("#tbl_catList").html(html);
        },
        error: function (err) {
            alert(err.responseText);
        }

    });
}

function ClearTextBoxes() {
    $('#ddlCatStatus').val(-1);
    $('#hdnCatID').val("");
    $('#txtCatName').val("");
}

function AddCategory() {
    debugger;
    if ($('#hdnCatID').val() != null)
        UpdateCategory();
    else {
        var CatObj = {
            Status: $('#ddlCatStatus option:selected').val(),
            CategoryName: $('#txtCatName').val(),
        };
        $.ajax({
            url: ApiUrl + "AddCategory/",
            type: "Post",
            data: JSON.stringify(CatObj),
            contentType: "application/json;charset:utf-8",
            dataType: "Json",
            success: function (res) {
                LoadCategory();
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
    var CatObj = {
        CategoryID: ID,
    };
    $.ajax({
        url: ApiUrl+"GetCategoryByID/",
        type: "Post",
        contentType: "application/json;charset=utf-8",
        data: JSON.stringify(CatObj),
        Datatype: "Json",
        success: function (res) {
            $('#hdnCatID').val(res.categoryID);
            $('#txtCatName').val(res.categoryName);
            $('#ddlCatStatus').val(res.status);
        },
        error: function (err) {
            alert(err.responseText);
        }

    });
}

function UpdateCategory() {
    var CatObj = {
        CategoryID: $('#hdnCatID').val(),
        Status: $('#ddlCatStatus option:selected').val(),
        CategoryName: $('#txtCatName').val(),
    };
    $.ajax({
        url: ApiUrl +"UpdateCategory/",
        data: JSON.stringify(CatObj),
        type: "Post",
        contentType: "application/json;charset=utf-8",
        dataType: "JSON",
        success: function (res) {
            LoadCategory();
            ClearTextBoxes();
        },
        error: function (err) {
            alert(err.responseText);
        }
    });
}

function DeleteCategory(ID) {
    if (confirm("Do you want to delete this item?")) {
        debugger;
        var CatObj = {
            CategoryID: ID,
        };
        $.ajax({
            url: ApiUrl +"DeleteCategory/",
            type: "Post",
            contentType: "application/json;charset=utf-8",
               data: JSON.stringify(CatObj),
            dataType: "Json",
            success: function (res) {
                LoadCategory();
            },
            error: function (err) {
                alert(err.responseText);
            }
        });
    }

}