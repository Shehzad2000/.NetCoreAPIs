var ApiUrl = "https://localhost:7299/api/";
$(document).ready(function () {
    LoadCartProducts();
    LoadCarts();
});
function LoadCartProducts() {
    debugger;
    $.ajax({
        url: ApiUrl +"Cart/LoadCartProducts/",
        type: "Get",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (res) {
            debugger;
            var html = '';
            //html += '<div class="container">';
            //html += ' <div class="row">';
            //html += '<div class="col-md-8">';
            html += '<table class="table cart-table">';
            html += '<thead>';
            html += '<tr>';
            html += '<th>Item</th>';
            html += '<th>Name</th>';
            html += '<th>QTY</th>';
            html += '<th>Price</th>';
            html += '<th>Remove</th>';
            html += '</tr>';
            html += '</thead>';
            html += ' <tbody>';
            $.each(res,function (key, item) {
                
                html += '<tr>';
                html += ' <td class="cart-item-image">';
                html += '<a href="#">';
                html += '<img src="../img/amaze_70x70.jpg" alt="Image Alternative text" title="AMaze" />';
                html += '</a>';
                html += '</td>';
                html += '<td><a href="#">'+item.product.productName+'</a> </td>';
                html += '<td class="cart-item-quantity"><i onclick="AddNegativeOne(' + item.cart.cartID + ')" class="fa fa-minus cart-item-minus"></i>';
                html += '<input type="text" name="cart-quantity" class="cart-quantity" value="'+item.cart.quantity+'" /><i onclick="AddPlusOne('+item.cart.cartID+')" class="fa fa-plus cart-item-plus"></i>';
                html += '</td>';
                html += '<td>$' + (item.cart.pricePerUnit * item.cart.quantity) + '</td>';
                html += '<td class="cart-item-remove">';
                html += '<a onclick="RemoveCart(' + item.cart.cartID + ')" class="fa fa-times" href="#"></a>';
                html += '</td>';
                html += '</tr>';;
               
                
            });
            html += ' </tbody>';
            html += '</table>';
            $(".CartDetails").html(html);
        }, error: function (err) {
            alert("Oops,Something went wrong");
        }
    })
}
function LoadCarts() {
    debugger;
    $.ajax({
        url: ApiUrl + "Cart/LoadCartProducts/",
        type: "Get",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (res) {
            var html = '';
            $.each(res, function (key, item) {
                html += '<li>';
                html += '<a href="product-shop-sidebar.html">';
                html += '<img src="../images/' + item.product.mainImage + '" alt="Image Alternative text" title="AMaze" />';
                html += '<h5>' + item.product.productName + '</h5><span class="shopping-cart-item-price">$' + item.cart.pricePerUnit + '</span>';
                html += '</a>';
                html += '</li>';
            });
            $('.cartlist').html(html);
        }, error: function (err) {
            alert("Mama is on fire");
        }
    })
    
}
function AddPlusOne(ID) {
    debugger;
    var cartObj = {
        CartID: ID
    };
    $.ajax({
        url: ApiUrl + "Cart/AddPlusOneToQuantity/",
        type: "Post",
        data: JSON.stringify(cartObj),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (res) {
            LoadCartProducts();
            alert("Quantity has been updated");
        }, error: function (err) {
            alert("Oops,Something went wrong");
        }
    });
}
function AddNegativeOne(ID) {
    debugger;
    var cartObj = {
        CartID: ID
    };
    $.ajax({
        url: ApiUrl + "Cart/RemoveOneItemFromCart/",
        type: "Post",
        data: JSON.stringify(cartObj),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (res) {
            LoadCartProducts();
            alert("Quantity has been updated");
        }, error: function (err) {
            alert("Oops,Something went wrong");
        }
    });
}

function RemoveCart(ID) {
    var cartObj = {
        CartID: ID
    };
    $.ajax({
        url: ApiUrl + "Cart/RemoveCart/",
        type: "Post",
        data: JSON.stringify(cartObj),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (res) {
            LoadCartProducts();
            alert("Item has been removed successfully");
        }, error: function (err) {
            alert("Oops,Something went wrong");
        }
    })
}        
            
               
                
                
                
                              
                
                
            
            
        
    
    
