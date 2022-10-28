var ApiUrl = "https://localhost:7299/api/";
$(document).ready(function () {
    ShowWishListProducts();
});
function ShowWishListProducts() {
    $.ajax({
        url: ApiUrl+"WishList/GetWishListProducts/",
        type: "Get",
        contentType: "application/json;charset=utf-8",
        dataType: "Json",
        success: function (res) {
            var html = '';
            $.each(res, function (key, item) {
                html += '<a class="product-thumb product-thumb-horizontal" href="#">';
                html += '<header class="product-header">';
                html += '<img src="img/hot_mixer_800x600.jpg" alt="Image Alternative text" title="Hot mixer" />';
                html += '</header>';
                html += ' <div class="product-desciption">Fames adipiscing rutrum quisque ullamcorper accumsan leo condimentum pretium augue justo</div>';
                html += '<h5 class="product-title">Modern DJ Set</h5>';
                html += '  <div class="product-meta"><span class="product-time"><i class="fa fa-clock-o"></i> 4 days 20 h remaining</span>';
                html += ' <ul class="product-price-list">';
                html += ' <li><span class="product-price">$150</span></li>';
                html += '<li><span class="product-old-price">$221</span> </li>';
                html += ' <li><span class="product-save">Save 68%</span> </li>';
                html += ' </ul>';
                html += ' </div>';
                html += '<p class="product-location"><i class="fa fa-map-marker"></i> Boston</p>';
                html += ' </div></a >';
            });
            $(".WishListProduct").html(html);
        }, error: function (err) {
            alert("Oops,something went wrong");
        }

    })
}

   
       
   
   
        
       
      
           
               
                
                
               
               
               
           
       
        
   