var ApiUrl = "https://localhost:7299/api/";
$(document).ready(function () {
    LoadOrders();
})
function LoadOrders() {
    debugger;
    $.ajax({
        url: ApiUrl + "Order/GetOrders/",
        type: "Get",
        contentType: "application/json;charset=utf-8",
        dataType: "Json",
        success: function (res) {
            var html = '';
            $.each(res, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.order.orderID + '</td>';
                html += '<td>' + item.customer.customerName + '</td>';
                html += '<td>' + item.customer.customerEmail + '</td>';
                html += '<td>' + item.customer.customerContact + '</td>';
                html += '<td>' + item.customer.customerAddress + '</td>';
                html += '<td>' + item.orderDetail.quantity + '</td>';
                html += '<td>' + item.order.status + '</td>';
                if (item.order.status > 0) {
                    html += '<td><select id="ddl_Status" Disabled class="form-control">';
                    //  html += '<option value="1">' + "--- Select Brand ---" + '</option>';
                    html += '<option value="ChengeStatus(' + item.order.orderID + ',' + 1 + ');"><span style=""><strong>Pending</strong></span></a></option>';
                    html += '<option value="ChangeStatus(' + item.order.orderID + ',' + 2 + ');"><span style=""><strong>Accepted</strong></span></a></option>';
                    html += '<option value="ChangeStatus(' + item.order.orderID + ',' + 3 + ');"><span style=""><strong>Rejected</strong></span></a></option>';
                    html += '<option value="ChangeStatus(' + item.order.orderID + ',' + 4 + ');"><span style=""><strong>Completed</strong></span></a></option>';
                    html += '</select></td>';
                }
                else {
                    html += '<td><select id="ddl_Status" class="form-control">';
                    //  html += '<option value="1">' + "--- Select Brand ---" + '</option>';
                    html += '<option value="ChengeStatus(' + item.order.orderID + ',' + 1 + ');"><span style=""><strong>Pending</strong></span></a></option>';
                    html += '<option value="ChangeStatus(' + item.order.orderID + ',' + 2 + ');"><span style=""><strong>Accepted</strong></span></a></option>';
                    html += '<option value="ChangeStatus(' + item.order.orderID + ',' + 3 + ');"><span style=""><strong>Rejected</strong></span></a></option>';
                    html += '<option value="ChangeStatus(' + item.order.orderID + ',' + 4 + ');"><span style=""><strong>Completed</strong></span></a></option>';
                    html += '</select></td>';
                }
               
                html += '<td><a href="#" class="btn btn-primary" onclick="ViewInvoice(' + item.order.orderID + ')"><i class="fa fa-edit"></i><span><strong>ViewInvoice</strong></span></a>';
                html += '</tr>';
                
            });
            $(".tbl_Order").html(html);
        }, error: function (err) {
            alert(err.responseText);
        }
    })
}
function ChangeStatus(OrderID, ID) {
    var orderObj = {
        OrderID: OrderID,
        Status: ID
    };
    $.ajax({
        url: ApiUrl + "Order/UpdateOrder/",
        type: "Post",
        data: JSON.stringify(orderObj),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (res) {
            alert("status is updated");
        }, error: function (err) {
            alert(err.responseText);
        }
    });
}