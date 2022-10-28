var ApiUrl = "https://localhost:7299/api/";
$(document).ready(function () {
    LoadCheckOutDetail();
});
function LoadCheckOutDetail() {
    debugger;
    var html = '';
    $.ajax({
        url: ApiUrl + "Cart/LoadCartProducts/",
        type: "Get",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (res) {
            html += '<div class="gap"></div>';
            html += '<div class="container">';
            html += '<div class="row">';
            html += '<div class="col-md-4">';
            html += '<aside class="sidebar-left">';
            html += '<div class="box clearfix">';
            html += '<table class="table">';
            html += '<thead>';
            html += '<tr>';
            html += '<th>Product</th>';
            html += '<th>QTY</th>';
            html += '<th>Price</th>';
            html += '</tr>';
            html += '</thead>';
            html += '<tbody>';
            
            $.each(res, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.product.productName + '</td>';
                html += '<td>' + item.cart.quantity + '</td>';
                html += '<td>$' + item.cart.pricePerUnit + '</td>';
                html += '</tr>';
            })
         
            html += '</tbody>';
            html += '</table>';
            html += '<ul class="cart-total-list text-center mb0">';
            html += '<li><span>Sub Total</span><span>$500.00</span>';
            html += '</li>';
            html += '<li><span>Shipping</span><span>$0.00</span>';
            html += '</li>';
            html += '<li><span>Taxes</span><span>$0.00</span>';
            html += '</li>';
            html += '<li><span>Total</span><span>$500.00</span>';
            html += '</li>';
            html += '</ul>';
            html += '</div>';
            html += '</aside>';
            html += '</div>';
            html += '<div class="col-md-8">';
            html += '<div class="row">';
            html += '<div class="col-md-6">';
            html += '<form action="#">';
            html += '<!-- <legend>Personal Information</legend> -->';
            html += '<div class="form-group">';
            html += '<label for="">Phone1:</label>';
            html += '<input type="text" id="txt_Phone1" class="form-control">';
            html += '</div>';
            html += '<div class="form-group">';
            html += '<label for="">Phone2:</label>';
            html += '<input type="text"  id="txt_Phone2" class="form-control">';
            html += '</div>';
            html += '<legend>Address</legend>';
            html += '<div class="form-group">';
            html += '<label for="">Address:</label>';
            html += '<input type="text" multiple  id="txt_Address" class="form-control">';
            html += '</div>';
            html += '<div class="form-group">';
            html += '<label for="">City:</label>';
            html += '<input type="text" id="txt_City" class="form-control">';
            html += '</div>';
            html += '<div class="form-group">';
            html += '<label for="">ZIP Code:</label>';
            html += '<input type="text" id="txt_ZipCode" class="form-control">';
            html += '</div>';
            html += '<div class="form-group">';
            html += '<label for="">Postal Code:</label>';
            html += '<input type="text" id="txt_PostalCode" class="form-control">';
            html += '</div>';
            html += '<input type="submit" onclick="SubmitOrderData();" class="btn btn-primary" value="Submit Order">';
            html += '</form>';
            html += '</div>';
            html += '</div>';
            html += '</div>';
            html += '</div>';
            html += '<div class="gap"></div>';
            html += '</div>';
            $(".CheckOut").html(html);
        }, error: function (err) {
            alert("abc");
        }
    });
}
function SubmitOrderData() {
    debugger;
    var orderObj = {
        Phone1: $('#txt_Phone1').val(),
        Phone2: $('#txt_Phone2').val(),
        Address: $('#txt_Address').val(),
        City: $('#txt_City').val(),
        ZipCode: $('#txt_ZipCode').val(),
        PostalCode: $('#txt_PostalCode').val(),
        Date: new Date($.now())
    };
    $.ajax({
        url: ApiUrl + "Order/SubmitOrder/",
        type: "Post",
        data: JSON.stringify(orderObj),
        headers: {
            'Accept': 'application/json;',
            'Content-Type':'application/json;'
        },
       // contentType: "application/json;charset=utf-8",
        dataType: "json",
        cache: false,
        contentType: false, // this one will turn your data into something like fooKey=fooData&barKey=barData
        processData: false, // and this one will make it [object Object]:""
        success: function (res) {
            LoadCheckOutDetail();
            alert("Quantity has been updated");
        }, error: function (xhr, status, error) {
            alert(status);
        }
    });
}
