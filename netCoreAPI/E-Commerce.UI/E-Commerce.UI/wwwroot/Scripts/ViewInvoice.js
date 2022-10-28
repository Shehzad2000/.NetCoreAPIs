var ApiUrl = "https://localhost:7299/api/";
$(document).ready(function () {
    ShowOrderProducts();
    CustomerOrderDetails();
})
function ShowOrderProducts() {
    debugger;
    $.ajax({
        url: ApiUrl + "Order/GetDetailsByCustomerID?ID="+1,
        type: "Post",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (res) {
            var html = '';
            html += '<div class="content">';
            html += '<div class="m-b-3">';
            html += '<div class="callout callout-info" style="margin-bottom: 0!important;">';
            html += '< h4 > <i class="fa fa-info"></i> Note:</h4 >';
            html += 'This page has been enhanced for printing.Click the print button at the bottom of the invoice to test. </div >';
            html += '</div >';
            html += '<div class="card">';
            html += '<div class="card-body">';
            html += '<!-- Main content -->';
            html += '<div class="invoice">';
            html += '<!-- title row -->';
            html += '<div class="row">';
            html += '<div class="col-lg-12 m-b-3">';
            html += '<h3 class="text-black"> INVOICE <span class="pull-right">#' + res.order.orderID + '</span> </h3>';
            html += '</div>';
            html += '<!-- /.col -->';
            html += '</div>';
            html += '<!-- info row -->';
            html += '<div class="row invoice-info m-b-3">';
            html += '<div class="col-sm-4 invoice-col"> From';
            html += '<address>';
            html += '<strong>Niche Admin</strong><br>';
            html += '795 Folsom Ave, Suite 600<br>';
            html += 'San Francisco, CA 94107<br>';
            html += 'Phone: (804) 123-5432<br>';
            html += 'Email: info@almasaeedstudio.com';
            html += '</address>';
            html += '</div>';
            html += '<!-- /.col -->';
            html += '<div class="col-sm-4 invoice-col"> To';
            html += '<address>';
            html += '<strong>'+res.customer.customerName+'</strong><br>';
            html += '795 Folsom Ave, Suite 600<br>';
            html += 'San Francisco, CA 94107<br>';
            html += 'Phone: (+92)' + res.customer.customerEmail + '<br>';
            html += 'Email: ' + res.customer.customerEmail + '';
            html += '</address>';
            html += '</div>';
            html += '<!-- /.col -->';
            html += '<div class="col-sm-4 invoice-col"> <b>Invoice #' + res.order.orderID + '</b><br>';
            html += '<br>';
            html += '<b>Order ID:</b> 4F3S8J<br>';
            html += '<b>Payment Due:</b> 2/22/2014<br>';
            html += '<b>Account:</b> 968-34567 </div>';
            html += '<!-- /.col -->';
            html += '</div>';
            html +='<div class="OrderDetail"></div>'
            //html += '<!-- Table row -->';
            //html += '<div class="row ">';
            //html += '<div class="col-xs-12 table-responsive">';
            //html += '<table class="table table-striped">';
            //html += '<thead>';
            //html += '<tr>';
            //html += '<th>Image</th>';
            //html += '<th>Product</th>';
            //html += '<th>UnitPrice</th>';
            //html += '<th>QTY</th>';
            //html += '<th>Serial #</th>';
            //html += '<th>Description</th>';
            //html += '<th>Subtotal</th>';
            //html += '</tr>';
            //html += '</thead>';
            //html += '<tbody>';
            //html +='<span class="OrderDetail"></span>'
            ////$.each(res, function (key, item) {
            ////    html += '<tr>';
            ////    html += '<td><img style="width:80px;border-radius:50%" src="../images/' + item.product.mainImage + '"/></td>';
            ////    html += '<td>' + item.product.productName + '</td>';
            ////    html += '<td>' + item.orderDetail.unitPrice + '</td>';
            ////    html += '<td>' + item.orderDetail.quantity + '</td>';
            ////    html += '<td>' + item.order.orderID + '</td>';
            ////    html += '<td>' + item.product.description + '</td>';
                
            ////    html += '<td>' + (item.orderDetail.unitPrice * item.orderDetail.quantity) + '</td>';
            ////  //  html += '<td><a href="#" class="btn btn-primary" onclick="LoadProductByID(' + item.product.ProductID + ')"><i class="fa fa-edit"></i><span><strong> Edit</strong></span></a>&nbsp;&nbsp;<a href="#" class="btn btn-danger" onclick="RemoveProduct(' + item.product.ProductID + ')">  <i class="fa fa-trash"></i><span><strong> Delete</strong></span> </a></td>';
            ////    html += '</tr>'

            ////});
            //html += '</tbody>';
            //html += '</table>';
            //html += '</div>';
            //html += '<!-- /.col -->';
            //html += '</div>';
            html += '<!-- this row will not appear when printing -->';
            html += '<div class="row no-print">';
            html += '<div class="col-lg-12">';
            html += '<button type="button" class="btn btn-success pull-right"><i class="fa fa-credit-card"></i> Submit Payment </button>';
            html += '<button type="button" class="btn btn-primary pull-right" style="margin-right: 5px;"> <i class="fa fa-download"></i> Generate PDF </button>';
            html += '</div>';
            html += '</div>';
            html += '</div>';
            html += '</div></div>';
            html += '</div>';
            $('.invoice').html(html);
        }, error: function (err) {

        }
    })
}
function CustomerOrderDetails() {
    debugger;
    $.ajax({
        url: ApiUrl + "Order/GetOrdersByCustomerID?ID=" + 1,
        type: "Post",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (res) {
            var html = '';
            html += '<!-- Table row -->';
            html += '<div class="row ">';
            html += '<div class="col-xs-12 table-responsive">';
            html += '<table class="table table-striped">';
            html += '<thead>';
            html += '<tr>';
            html += '<th>Image</th>';
            html += '<th>Product</th>';
            html += '<th>UnitPrice</th>';
            html += '<th>QTY</th>';
            html += '<th>Serial #</th>';
            html += '<th>Description</th>';
            html += '<th>Subtotal</th>';
            html += '</tr>';
            html += '</thead>';
            html += '<tbody>';
            html += '<span class="OrderDetail"></span>'
            $.each(res, function (key, item) {
                html += '<tr>';
                html += '<td><img style="width:80px;border-radius:50%" src="../images/' + item.product.mainImage + '"/></td>';
                html += '<td>' + item.product.productName + '</td>';
                html += '<td>' + item.orderDetail.unitPrice + '</td>';
                html += '<td>' + item.orderDetail.quantity + '</td>';
                html += '<td>' + item.order.orderID + '</td>';
                html += '<td>' + item.product.description + '</td>';

                html += '<td>' + (item.orderDetail.unitPrice * item.orderDetail.quantity) + '</td>';
               // html += '<td><a href="#" class="btn btn-primary" onclick="LoadProductByID(' + item.product.ProductID + ')"><i class="fa fa-edit"></i><span><strong> Edit</strong></span></a>&nbsp;&nbsp;<a href="#" class="btn btn-danger" onclick="RemoveProduct(' + item.product.ProductID + ')">  <i class="fa fa-trash"></i><span><strong> Delete</strong></span> </a></td>';
                html += '</tr>';
            });
            html += '</tbody>';
            html += '</table>';
            html += '</div>';
            html += '<!-- /.col -->';
            html += '</div>';
            $('.OrderDetail').html(html);
        }, error: function (err) {
            alert("Blah blah")
        }
    });
}