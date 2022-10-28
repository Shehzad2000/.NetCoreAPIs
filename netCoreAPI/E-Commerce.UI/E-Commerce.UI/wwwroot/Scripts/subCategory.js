var ApiUrl = "https://localhost:7299/api/SubCategory/";
$(document).ready(function () {
    LoadSubCategory();
    LoadCategory();
});
//RegisterCategory
function RegisterSubCategory() {
    debugger;
    var subCat = {
        SubCategoryId: $('#hdnSubCatID').val() == "" ? 0 : $('#hdnSubCatID').val(),
        CategoryID:$('#ddl_Category option:selected').val(),
        SubCategoryName: $('#txt_SubCatName').val(),
        Status:$('#ddl_Status option:selected').val(),
    };
    $.ajax({
        url: ApiUrl + "AddSubcategory/",
        type: "Post",
        data: JSON.stringify(subCat),
        contentType: "application/json;charset=utf-8",
        dataType: "Json",
        success: function (res) {
            debugger;
            LoadSubCategory();
        }, error(err) {
            alert(err.responseText);
        }
    });
}
function LoadCategory() {
    
    $.ajax({
        url: ApiUrl +"GetCategories/",
        type: "Get",
        contentType: "application/json;charset=utf-8",
        dataType: "Json",
        success: function (res) {
            var select = '';
            select += '<select id="ddl_Category" class="form-control">';
            select += '<option value="1">'+ "--- Select Category ---" +'</option>';
            $.each(res, function (key, item) {
                select += '<option value="' + item.categoryID + '">' + item.categoryName + '</option>';
            });
            select += '</select>';
            $(".CategoryDetails").html(select);
        },
        error: function (err) {
            alert(err.responseText);
        }
    });
}
//Update SubCategory
function UpdateSubCategory() {
    var subCat = {
        SubCategoryId: $('#hdnSubCatID').val() == "" ? 0 : $('#hdnSubCatID').val(),
        CategoryID: $('#ddl_Category option:selected').val(),
        SubCategoryName: $('#txt_SubCatName').val(),
        Status: $('#ddl_Status option:selected').val(),
    };
    $.ajax({
        url: ApiUrl + "UpdateSubCategory/",
        type:"Post",
        data: JSON.stringify(subCat),
        contentType: "application/json;charset=utf-8",
        dataType: "Json",
        success: function (res) {
            $("#MyModal").modal('hide');
            LoadSubCategory();
        }, error(err) {
            alert(err.responseText);
        }
    });
}
//AddAndUpdateSubCategory
function SubmitData() {
    debugger;
    ID = document.getElementById("hdnSubCatID").value;
    if (ID > 0)
        UpdateSubCategory();
    else
        RegisterSubCategory();
        
}

//DeleteSubCategory
function RemoveSubCategory(ID) {
    var subCat = {
        SubCategoryId: ID
    };
    $.ajax({
        url: ApiUrl + "DeleteSubCategory/",
        type: "Post",
        data: JSON.stringify(subCat),
        contentType: "application/json;charset=utf-8",
        dataType: "Json",
        success: function (res) {
            LoadSubCategory();
        }, error(err) {
            alert(err.responseText);
        }
    })

}
//GetSubCategoryByID
function GetSubCategoryByID(ID) {
    var subCat = {
        SubCategoryId:ID,
    };
    $.ajax({
        url: ApiUrl + "GetSubCategoryByID/",
        type: "Post",
        data: JSON.stringify(subCat),
        contentType: "application/json;charset=utf-8",
        dataType: "Json",
        success: function (res) {
            $("#MyModal").modal('show');
            $('#hdnSubCatID').val(res.subCategoryId);
            $('#txt_SubCatName').val(res.subCategoryName);
            $('#ddl_Category ').val(res.categoryID),
            $('#ddl_Status').val(res.status);
        }, error(err) {
            alert(err.responseText);
        }
    })
}


   
function LoadSubCategory() {

    $.ajax({
        url: ApiUrl +"GetSubCategories/",
        type: "Get",
        contentType: "application/json;charset=utf-8",
        dataType: "Json",
        success: function (res) {
            var html = '';
            $.each(res, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.categoryID + '</td>';
                html += '<td>' + item.subCategoryName + '</td>';
                html += '<td>' + item.status + '</td>';
                html += '<td><a href="#" class="btn btn-primary" onclick="GetSubCategoryByID(' + item.subCategoryId + ')"><i class="fa fa-edit"></i><span><strong> Edit</strong></span></a>&nbsp;&nbsp;<a href="#" class="btn btn-danger" onclick="RemoveSubCategory(' + item.subCategoryId + ')">  <i class="fa fa-trash"></i><span><strong> Delete</strong></span> </a></td>';
                html += '</tr>'

            });
            $(".tbl_SubCategory").html(html);
        },error: function (err) {
            alert(err.responseText);
        }
    })
}
