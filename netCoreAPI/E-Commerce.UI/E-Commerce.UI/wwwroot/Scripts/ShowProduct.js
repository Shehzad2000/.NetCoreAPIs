
var ApiUrl = "https://localhost:7299/api/";
$(document).ready(function () {
    debugger;
    ShowAllProducts();
    ShowCatList();
    ShowCompanyList();
    ShowBrandList();
});
function ShowAllProducts() {
    debugger;
    $.ajax({
        url: ApiUrl + "Product/GetProducts/",
        type: "Get",
        contentType: "application/json;charset=utf-8",
        dataType: "Json",
        success: function (res) {
            Product(res);
             },error: function (err) {
            alert(err.responseText);
        }
    })
}
function Product(res) {
    var html = '';
    $.each(res, function (key, item) {
        html += '<div class="col-md-4">';
        html += '<div class="product-thumb">';
        html += '<header class="product-header">';
        html += '<img src="../assets/img/iphone_5_ipad_mini_ipad_3_800x600.jpg" alt="Image Alternative text" title="iPhone 5 iPad mini iPad 3" />';
        html += '</header>';
        html += '<div class="product-inner">';
        html += '<ul class="icon-group icon-list-rating" title="4/5 rating">';
        html += '<li><i class="fa fa-star"></i></li>';
        html += '<li><i class="fa fa-star"></i></li >';
        html += '<li><i class="fa fa-star"></i></li >';
        html += '<li><i class="fa fa-star"></i></li >';
        html += '<li><i class="fa fa-star-o"></i></li >';
        html += '</ul>';
        html += '<h5 class="product-title">Electronics Big Deal</h5>';
        html += '<p class="product-desciption">Volutpat torquent orci luctus pharetra volutpat nisl dis</p>';
        html += '<div class="product-meta">';
        html += '<ul class="product-price-list">';
        html += '<li><span class="product-price">' + item.product.price + ' </span></li >';
        html += '</ul>';
        html += '<ul class="product-actions-list" >';
        html += '<li><a class="btn btn-sm" onclick="AddToCart(' + item.product.productID + ')" href="#"><i class="fa fa-shopping-cart"></i> To Cart</a></li >';
        html += '<li><a class="btn btn-sm" onclick="ShowProductDetail(' + item.product.productID + ')"><i class="fa fa-bars"></i> Details</a>';
        html += '<li><a class="btn btn-sm " onclick="AddToWishList(' + item.product.productID + ')"><i class="fa fa-heart" style="color:red;"></i> Wishlist</a>';
        html += '</li>';
        html += '</ul>';
        html += '</div>';
        html += '</div>';
        html += '</div>';
        html += '</div>';
    });
    $(".ProductDetails").html(html);
}
function ShowCatList() {
    debugger;
    $.ajax({
        url: ApiUrl + "Category/GetCategories/",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (res) {
            var html = '';
            html += '<ul class="nav nav-tabs nav-stacked nav-coupon-category">';
            html += '<li class="active"><a href="#"><i class="fa fa-ticket"></i>All</a></li>';
            $.each(res, function (key, item) {
                html += '<li><a href="#" onclick="ShowProductByCatID(' + item.categoryID + ')"><i class="fa fa-cutlery"></i>' + item.categoryName + '</a></li>';
            });
            html += '</ul >';
            $(".CategoryDetails").html(html);
        },
        error: function (err) {
            alert(err.responseText);
        }
    });
}
function ShowCompanyList() {
    debugger;
    $.ajax({
        url: ApiUrl + "Company/GetAllCompaniesDetails/",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (res) {
            var html = '';
            html += '<ul class="nav nav-tabs nav-stacked nav-coupon-category">';
            html += '<li class="active"><a href="#"><i class="fa fa-ticket"></i>All</a></li>';
            $.each(res, function (key, item) {
                html += '<li><a href="#" onclick="ShowProductByCompanyID(' + item.companyID + ')"><i class="fa fa-cutlery"></i>' + item.companyName + '</a></li>';
            });
            html += '</ul >';
            $(".CompanyDetails").html(html);
        },
        error: function (err) {
            alert(err.responseText);

        }

    });
}
function ShowBrandList() {
    debugger;
    $.ajax({
        url: ApiUrl + "Brand/GetBrands/",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (res) {
            var html = '';
            html += '<ul class="nav nav-tabs nav-stacked nav-coupon-category">';
            html += '<li class="active"><a href="#"><i class="fa fa-ticket"></i>All</a></li>';
            $.each(res, function (key, item) {
                html += '<li><a href="#" onclick="ShowProductByBrandID(' + item.brandID + ')"><i class="fa fa-cutlery"></i>' + item.brandName + '</a></li>';
            });
            html += '</ul >';
            $(".BrandDetails").html(html);
        },
        error: function (err) {
            alert(err.responseText);

        }

    })
}
function AddToWishList(productID) {
    debugger;
    //var formData = new FormData();
    //formData.append("CustomerID", 1);
    //formData.append("ProductID", productID);
    //formData.append("Date", new Date($.now()));
    var wishlistObj = {
        WishListID:0,
        customerID:1,
        productID: productID,
        Date: new Date($.now())
    };
    $.ajax({
        url: ApiUrl + "WishList/AddProductToWishList/",
        type: "POST",
        data: JSON.stringify(wishlistObj),
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json"
        },
        dataType: "Json",
        //contentType: false,
        //processData: false,
        //async: false,
        success: function (res) {
            debugger;
            alert("Product is added to wishlist successfully");
        }, error: function (err) {
            debugger;
            alert("Oops,something went wrong");
        }
    })
}
function ShowProductDetail(ID) {
    debugger;
    var productObj = {
        ProductID: ID
    };
    $.ajax({
        url: ApiUrl + "Product/GetProduct/",
        type: "Post",
        data: JSON.stringify(productObj),
        contentType: "application/json;charset=utf-8",
        dataType: "Json",
        success: function (res) {
            var html = '';

            html += '<div class="row">';
            html += '<div class="col-md-7">';
            html += ' <div class="fotorama--hidden"></div><div class="fotorama fotorama1649841607722" data-nav="thumbs" data-allowfullscreen="1" data-thumbheight="150" data-thumbwidth="150"><div class="fotorama__wrap fotorama__wrap--css3 fotorama__wrap--slide fotorama__wrap--toggle-arrows fotorama__wrap--no-controls" style="width: 800px; min-width: 0px; max-width: 100%;"><div class="fotorama__stage" style="width: 482px; height: 362px;"><div class="fotorama__stage__shaft fotorama__grab" style="transition-duration: 0ms; transform: translate3d(0.001px, 0px, 0px); width: 482px; margin-left: 0px;"><div class="fotorama__stage__frame fotorama__loaded fotorama__loaded--img fotorama__active" style="left: 0px;"><img src="../assets/img/gamer_chick_800x600.jpg" class="fotorama__img" style="width: 482px; height: 362px; margin-left: -241px; margin-top: -181px;"></div><div class="fotorama__stage__frame fotorama__loaded fotorama__loaded--img" style="left: 484px;"><img src="../assets/img/amaze_800x600.jpg" class="fotorama__img" style="width: 482px; height: 362px; margin-left: -241px; margin-top: -181px;"></div></div><div class="fotorama__arr fotorama__arr--prev fotorama__arr--disabled"></div><div class="fotorama__arr fotorama__arr--next"></div><div class="fotorama__video-close"></div><div class="fotorama__fullscreen-icon"></div></div><div class="fotorama__nav-wrap"><div class="fotorama__nav fotorama__nav--thumbs fotorama__shadows--right" style="width: 482px;"><div class="fotorama__nav__shaft fotorama__grab" style="transition-duration: 0ms; transform: translate3d(0px, 0px, 0px);"><div class="fotorama__thumb-border" style="transition-duration: 0ms; transform: translate3d(0px, 0px, 0px); width: 146px;"></div><div class="fotorama__nav__frame fotorama__nav__frame--thumb fotorama__active" style="width: 150px;"><div class="fotorama__thumb fotorama__loaded fotorama__loaded--img"><img src="../assets/img/gamer_chick_800x600.jpg" class="fotorama__img" style="width: 200px; height: 150px; margin-left: -100px; margin-top: -75px;"></div></div><div class="fotorama__nav__frame fotorama__nav__frame--thumb" style="width: 150px;"><div class="fotorama__thumb fotorama__loaded fotorama__loaded--img"><img src="../assets/img/amaze_800x600.jpg" class="fotorama__img" style="width: 200px; height: 150px; margin-left: -100px; margin-top: -75px;"></div></div><div class="fotorama__nav__frame fotorama__nav__frame--thumb" style="width: 150px;"><div class="fotorama__thumb fotorama__loaded fotorama__loaded--img"><img src="../assets/img/urbex_esch_lux_with_laney_and_laaaaag_800x600.jpg" class="fotorama__img" style="width: 200px; height: 150px; margin-left: -100px; margin-top: -75px;"></div></div><div class="fotorama__nav__frame fotorama__nav__frame--thumb" style="width: 150px;"><div class="fotorama__thumb fotorama__loaded fotorama__loaded--img"><img src="../assets/img/food_is_pride_800x600.jpg" class="fotorama__img" style="width: 200px; height: 150px; margin-left: -100px; margin-top: -75px;"></div></div></div></div></div></div></div>';
            html += '</div>';
            html += '  <div class="col-md-5">';
            html += '        <div class="product-info box">';
            html += '            <ul class="icon-group icon-list-rating text-color" title="4.5/5 rating">';
            html += '                <li><i class="fa fa-star"></i>';
            html += '                </li>';
            html += '                <li><i class="fa fa-star"></i>';
            html += '                </li>';
            html += '                <li><i class="fa fa-star"></i>';
            html += '                </li>';
            html += '                <li><i class="fa fa-star"></i>';
            html += '                </li>';
            html += '                <li><i class="fa fa-star-half-empty"></i>';
            html += '                </li>';
            html += '            </ul>	<small><a href="#" class="text-muted">based on 8 reviews</a></small>';
            html += '            <h3>New Glass Collection</h3>';
            html += '            <p class="product-info-price">$150</p>';
            html += '            <p class="text-smaller text-muted">Tempor nibh vestibulum libero aliquam imperdiet quam dignissim erat risus tortor tincidunt a taciti nostra imperdiet enim elementum nunc aliquam litora volutpat curae per non praesent ultrices orci cursus mauris</p>';
            html += '            <ul class="icon-list list-space product-info-list">';
            html += '                <li><i class="fa fa-check"></i>Pulvinar nulla</li>';
            html += '                <li><i class="fa fa-check"></i>Vitae aliquet</li>';
            html += '                <li><i class="fa fa-check"></i>Metus praesent</li>';
            html += '                <li><i class="fa fa-check"></i>Nec himenaeos</li>';
            html += '                <li><i class="fa fa-check"></i>At aptent</li>';
            html += '            </ul>';
            html += '            <ul class="list-inline">';
            html += '                <li><a href="#" class="btn btn-primary"><i class="fa fa-shopping-cart"></i> Add to cart</a>';
            html += '                </li>';
            html += '                <li><a href="#" class="btn"><i class="fa fa-star"></i> To Wishlist</a>';
            html += '                </li>';
            html += '            </ul>';
            html += '        </div>';
            html += '    </div>';
            html += '</div>';


            $(".ProductDetails").html(html);
        }, error: function (err) {
            alert("Oops,Something went wrong");
        }
       
    })
}
function GoToProductDetailController() {
    $.ajax({
        url:"https://localhost:7062/ProductDetails/ProductDetail/",
        type: "Post",
        data:"{ID:'"+ID+"'}",
        contentType: "application/json;charset=utf-8",
        dataType: "JSON",
        success: function (res) {
            GoToProductDetailController(res.iD);
        }, error: function (err) {
            alert("Oops there is something wrong")
        }

    })
}
function AddToCart(ID) {
    debugger

    var cartObj = {
        ProductID: ID,
        CustomerID: 1,
        Quantity:1,
    }
    $.ajax({
        url: ApiUrl + "Cart/AddProductToCart/",
        type: "Post",
        data: JSON.stringify(cartObj),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (res) {
            alert("Data has been saved successfully submitted");
        }, error: function (err) {
            alert("Oops,something is wrong");
        }
    });
}
function ShowProductByCatID(ID) {
    debugger;
    var obj = {
        CategoryID: ID
    }
    $.ajax({
        url: ApiUrl + "Product/GetProductsByID/",
        type: "Post",
        data: JSON.stringify(obj),
        contentType: "application/json;charset=utf-8",
        dataType: "Json",
        success: function (res) {
            Product(res);
        }, error: function (res) {
            alert(res.responseText);
        }

    })
}
function ShowProductByCompanyID(ID) {
    var obj = {
        CompanyID: ID
    }
    $.ajax({
        url: ApiUrl + "Product/GetProductsByID/",
        type: "Post",
        data: JSON.stringify(obj),
        contentType: "application/json;charset=utf-8",
        dataType: "Json",
        success: function (res) {
            Product(res);
        }, error: function (res) {
            alert(res.responseText);
        }

    })
}
function ShowProductByBrandID(ID) {
    var obj = {
        BrandID: ID
    }
    $.ajax({
        url: ApiUrl + "Product/GetProductsByID/",
        type: "Post",
        data: JSON.stringify(obj),
        contentType: "application/json;charset=utf-8",
        dataType: "Json",
        success: function (res) {
            Product(res);
        }, error: function (res) {
            alert(res.responseText);
        }

    })
}
