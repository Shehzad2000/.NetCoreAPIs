var OtherImagesName = '';
var MainImageName = '';

var ApiUrl = "https://localhost:7299/api/";
$(document).ready(function () {
    LoadProducts();
    LoadCategory();
    LoadSubCategory();
    LoadCompany();
    LoadBrands();
});




//RegisterCategory
function RegisterProduct() {
    debugger;
    var formData = new FormData();
    formData.append("otherimages", OtherImagesName);
    formData.append("CategoryID", $('#ddl_Category option:selected').val());
    formData.append("SubCategoryID", $('#ddl_SubCategory option:selected').push());
    formData.append("CompanyID", $('#ddl_Company option:selected').val());
    formData.append("ProductName", $('#txt_ProductName').val());
    formData.append("MainImage", MainImageName);
    formData.append("Description", $('#txt_Description').val());
    formData.append("Price", $('#txt_Price').val());
    formData.append("Status", $('#ddl_Status option:selected').val());
    $.ajax({
        url: ApiUrl + "Product/AddProduct/",
        type: "POST",
        data: formData,
        contentType: false,
        processData: false,
        async: false,
         success: function (res) {
             alert(res.statusText);
        }, error(err) {
             alert(err.statusText);
         }
    });
}
function LoadProductByID(ID) {
    var productObj = {
        ProductID: ID,
    };
    $.ajax({
        url: ApiUrl + "Product/",
        type: "Post",
        data: JSON.stringify(productObj),
        contentType: "application/json;charset=utf-8",
        dataType: "Json",
        success: function (res) {
            $('#hdnProductID').val(res.ProductID),
                $('#ddl_Category option:selected').val(res.categoryID),
                $('#ddl_SubCategory option:selected').val(res.subCategoryID),
                $('#ddl_Company option:selected').val(res.companyID),
                $('#txt_ProductName').val(res.productName),
                $('#hdnMainImage').val(res.mainImage),
                $('#hdnOtherImages').val(res.otherImages),
                $('#ddl_Status option:selected').val(res.status),
                $('#txt_Description').val(res.Description),
                $('#txt_Price').val(res.Price)
        }, error(err) {
            alert(err.responseText);
        }
    })
}
//Update SubCategory
function UpdateProduct() {
    var productObj = {
        ProductID:$('#hdnProductID').val(),
        CategoryID: $('#ddl_Category option:selected').val(),
        SubCategoryID: $('#ddl_SubCategory option:selected').val(),
        CompanyID: $('#ddl_Company option:selected').val(),
        ProductName: $('#txt_ProductName').val(),
        Status: $('#ddl_Status option:selected').val(),
        Description: $('#txt_Description').val(),
        Price: $('#txt_Price').val(),
    };
    $.ajax({
        url: ApiUrl + "Product/",
        type: "Post",
        data: JSON.stringify(productObj),
        contentType: "application/json;charset=utf-8",
        dataType: "Json",
        success: function (res) {
            LoadProducts();
        }, error(err) {
            alert(err.responseText);
        }
    });
}
//AddAndUpdateSubCategory
function SubmitData() {
    ID = document.getElementById("hdnProductID").value;
    if (ID > 0)
        UpdateProduct();
    else
        UploadImage();

}

//DeleteSubCategory
function RemoveProduct(ID) {
    var productObj = {
        ProductID: ID
    };
    $.ajax({
        url: ApiUrl + "Product/",
        type: "Post",
        data: JSON.stringify(productObj),
        contentType: "application/json;charset=utf-8",
        dataType: "Json",
        success: function (res) {
            LoadProducts();
        }, error(err) {
            alert(err.responseText);
        }
    })

}
//GetSubCategoryByID
function GetSubCategoryByID(ID) {
    var subCat = {
        SubCategoryId: ID,
    };
    $.ajax({
        url: ApiUrl + "GetSubCategoryByID/",
        type: "Post",
        data: JSON.stringify(subCat),
        contentType: "application/json;charset=utf-8",
        dataType: "Json",
        success: function (res) {
            ('#hdnSubCatID').val(res.subCategoryId);
            ('#txt_SubCatName').val(res.subCategoryName);
            ('#ddl_Category option:selected').val(res.categoryID);
            ('#ddl_Status option:selected').val(res.status);
        }, error(err) {
            alert(err.responseText);
        }
    })
}
//LoadProductByID

function UploadImage() {
    debugger;
    var data = new FormData();
    var image = $('#txt_MainImage').get(0).files;
    var files = $('#txt_OtherImage').get(0).files;
    for (var i = 0; i < files.length; i++) {
        data.append("OtherImages", files[i]);
    }
    data.append("MainImage", image[0]);
    $.ajax({
        type: "Post",
        url:"https://localhost:7062/Product/UploadedFile",
        contentType: false,
        processData:false,
        data: data,
        success: function (res) {
            debugger;
            MainImageName= res.mainImage;
            OtherImagesName= res.otherImages;
            RegisterProduct();
        }, error: function (xhr,status) {
            alert("Oops,something went wrong");
        }
    })
}
function LoadCategory() {

    $.ajax({
        url: ApiUrl + "Category/GetCategories/",
        type: "Get",
        contentType: "application/json;charset=utf-8",
        dataType: "Json",
        success: function (res) {
            var select = '';
            select += '<select id="ddl_Category" class="form-control">';
            select += '<option value="1">' + "--- Select Category ---" + '</option>';
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
function LoadSubCategory() {

    $.ajax({
        url: ApiUrl + "SubCategory/GetSubCategories/",
        type: "Get",
        contentType: "application/json;charset=utf-8",
        dataType: "Json",
        success: function (res) {
            var select = '';
            select += '<select id="ddl_SubCategory" class="form-control">';
            select += '<option value="1">' + "--- Select SubCategory ---" + '</option>';
            $.each(res, function (key, item) {
                select += '<option value="' + item.subCategoryID + '">' + item.subCategoryName + '</option>';
            });
            select += '</select>';
            $(".SubCategoryDetails").html(select);
        },
        error: function (err) {
            alert(err.responseText);
        }
    });
}

function LoadCompany() {
    $.ajax({
        url: ApiUrl + "Company/GetAllCompaniesDetails/",
        type: "Get",
        contentType: "application/json;charset=utf-8",
        dataType: "Json",
        success: function (res) {
            var select = '';
            select += '<select id="ddl_Company" class="form-control">';
            select += '<option value="1">' + "--- Select Company ---" + '</option>';
            $.each(res, function (key, item) {
                select += '<option value="' + item.companyID + '">' + item.companyName + '</option>';
            });
            select += '</select>';
            $(".CompanyDetails").html(select);
        },
        error: function (err) {
            alert(err.responseText);
        }
    });

}

function LoadBrands() {
    $.ajax({
        url: ApiUrl + "Brand/GetBrands/",
        type: "Get",
        contentType: "application/json;charset=utf-8",
        dataType: "Json",
        success: function (res) {
            var select = '';
            select += '<select id="ddl_Brand" class="form-control">';
            select += '<option value="1">' + "--- Select Brand ---" + '</option>';
            $.each(res, function (key, item) {
                select += '<option value="' + item.brandID + '">' + item.brandName + '</option>';
            });
            select += '</select>';
            $(".BrandDetails").html(select);
        },
        error: function (err) {
            alert(err.responseText);
        }
    });

}

function LoadProducts() {
    debugger;
    $.ajax({
        url: ApiUrl + "Product/GetProducts/",
        type: "Get",
    //    Headers:{
    //        "Accept": "application/json;",
    //        "Content-Type": "application/json;"
    //},
        contentType: "application/json;charset=utf-8",
        dataType: "Json",
        success: function (res) {
            var html = '';
            $.each(res, function (key, item) {
                html += '<tr>';
                html += '<td><img style="width:80px;border-radius:50%" src="../images/' + item.product.mainImage + '"/></td>';
                html += '<td>' + item.product.productName + '</td>';
                html += '<td>' + item.product.categoryID + '</td>';
                html += '<td>' + item.product.subCategoryID + '</td>';
                html += '<td>' + item.product.companyID + '</td>';
                html += '<td>' + item.product.description + '</td>';
                html += '<td>' + item.product.price + '</td>';
                html += '<td>' + item.product.status + '</td>';
                html += '<td><a href="#" class="btn btn-primary" onclick="LoadProductByID(' + item.product.ProductID + ')"><i class="fa fa-edit"></i><span><strong> Edit</strong></span></a>&nbsp;&nbsp;<a href="#" class="btn btn-danger" onclick="RemoveProduct(' + item.product.ProductID + ')">  <i class="fa fa-trash"></i><span><strong> Delete</strong></span> </a></td>';
                html += '</tr>'
            });
            $(".tbl_Product").html(html);
        }, error: function (err) {
            alert(err.responseText);
        }
    })
}
