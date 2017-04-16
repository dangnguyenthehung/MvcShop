/// <reference path="main.js" />
/*price range*/

 $('#sl2').slider();

	var RGBChange = function() {
        $('#RGB').css('background', 'rgb('+r.getValue()+','+g.getValue()+','+b.getValue()+')')
	};	
		
/*scroll to top*/

$(document).ready(function(){
    zoom_similar_product();

	$(function () {
		$.scrollUp({
	        scrollName: 'scrollUp', // Element ID
	        scrollDistance: 300, // Distance from top/bottom before showing element (px)
	        scrollFrom: 'top', // 'top' or 'bottom'
	        scrollSpeed: 300, // Speed back to top (ms)
	        easingType: 'linear', // Scroll to top easing (see http://easings.net/)
	        animation: 'fade', // Fade, slide, none
	        animationSpeed: 200, // Animation in speed (ms)
	        scrollTrigger: false, // Set a custom triggering element. Can be an HTML string or jQuery object
					//scrollTarget: false, // Set a custom target element for scrolling to the top
	        scrollText: '<i class="fa fa-angle-up"></i>', // Text for element, can contain HTML
	        scrollTitle: false, // Set a custom <a> title if required.
	        scrollImg: false, // Set true to use image
	        activeOverlay: false, // Set CSS color to display scrollUp active point, e.g '#00FFFF'
	        zIndex: 2147483647 // Z-Index for the overlay
		});
	});

	function zoom_similar_product() {
		// body...
		$(".product-similar-img").click(function(){
			var source =  $(this).find("img").attr("src");
			source = source.replace("similar","");
			$(".view-product img").attr("src",source);
		});
	}

	
	    function numberWithCommas(x) {
	        var parts = x.toString().split(".");
	        parts[0] = parts[0].replace(/\B(?=(\d{3})+(?!\d))/g, ",");
	        return parts.join(".");
	    }

	    function pagination()
	    {

	    }

	    $( '.demo' ).WMZoom( {
	        config: {

	            // stage size
	            stageW: 400,
                

	            // disable inner zoom
                inner: false,

                position: 'right',
                margin: 10

	        }
	    } );

	    $( function ()
	    {
	        $( ".add-to-cart" ).click( function ()
	        {
	            //var url = '@Url.Action("LoadName","ChooseType")';
	            var url = AppUrlSettings.AddToCartUrl;
	            var ID = $( this ).attr( "data-productID" );
	            var quantity = 1;
	            // edit selected element row id
	            
	            var request = $( function ()
	            {
	                $.ajax( {
	                    type: "POST",
	                    url: url,
	                    data: { ProductId: ID, Quantity: quantity },
	                    success: function ( data )
	                    {
	                        alert( data );
	                    }
	                } );
	            } );

	        } );
        });

        $(function () {
            $(".cart_quantity_delete").click(function () {
                //var url = '@Url.Action("LoadName","ChooseType")';
                var url = AppUrlSettings.RemoveFromCartUrl;
                var ID = $(this).attr("data-productID");
                // edit selected element row id

                var request = $(function () {
                    $.ajax({
                        type: "POST",
                        url: url,
                        data: { ProductId: ID },
                        success: function (data) {
                            alert(data);
                        }
                    });
                });
                location.reload();
            });
        });

	    $( function ()
	    {
	        $( ".cart" ).click( function ()
	        {
	            //var url = '@Url.Action("LoadName","ChooseType")';
	            var url = AppUrlSettings.AddToCartUrl;
	            var ID = $( this ).attr( "data-productID" );
	            var quantity = $( "input[name='quantity']" ).val();;
	            // edit selected element row id

	            var request = $( function ()
	            {
	                $.ajax( {
	                    type: "POST",
	                    url: url,
	                    data: { ProductId: ID, Quantity: quantity },
	                    success: function ( data )
	                    {
	                        alert( data );
	                    }
	                } );
	            } );

	        } );
	    } );
	
	    

} );
$( function quantity_changed()
{
    $( ".cart_quantity_input" ).change( function ()
    {
        var quantity = $( this ).val();
        var price = $( this ).parents( ".item_cell" ).find( ".cart_price" ).attr( "data-price" );

        var total_price = quantity * price;
        total = $(this).parents(".item_cell").find(".cart_total_price > .value").html(total_price);
         cart_bill();
    } )
    

})


function cart_bill() {
    var total_bill = 0;

    var arr = $(".item_cell .cart_total_price > .value").each(function () {
        var money = parseInt($(this).html());
        total_bill += money;
    })

    $(".cart_bill .cart_bill_total span").html(total_bill);
};


$(function () {
    cart_bill();
})    
