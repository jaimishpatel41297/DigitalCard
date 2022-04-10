

(function($) {
	
	"use strict";
	
	  $(window).load(function(){
      $('.flexslider').flexslider({
        animation: "slide",
        start: function(slider){
          $('body').removeClass('loading');
        }
      });		 	     			  		     	 	  			 
    });
	
	
	 /*-------------------------------------
    9. Thumbnail Product activation
    --------------------------------------*/
    $('.new_come_slide').owlCarousel({
        loop: false,
        navText: ["<i class='fa fa-angle-left'></i>" , "<i class='fa fa-angle-right'></i>"],
        margin: 15,
        smartSpeed: 1000,
        nav: true,
        dots: false,
        responsive: {
            0: {
                items: 1
            },
            600: {
                items: 1
            },
            1000: {
                items: 3
            }
        }
    })
	
	
	
	$('.client_says').owlCarousel({
        loop: false,
        navText: ["<i class='fa fa-angle-left'></i>" , "<i class='fa fa-angle-right'></i>"],
        margin: 15,
        smartSpeed: 1000,
        nav: true,
        dots: false,
        responsive: {
            0: {
                items: 1
            },
            600: {
                items: 1
            },
            1000: {
                items: 1
            }
        }
    })
	
	
	$('.best_sale_slide').owlCarousel({
        loop: false,
        navText: ["<i class='fa fa-angle-left'></i>" , "<i class='fa fa-angle-right'></i>"],
        margin: 15,
        smartSpeed: 1000,
        nav: true,
        dots: false,
        responsive: {
            0: {
                items: 1
            },
            600: {
                items: 2
            },
            1000: {
                items: 4
            }
        }
    })
	
	
	
	
	
	/*=========== price range slider ============*/
	var ammout = $("#amount");
	var sliderRange = $("#slider-range");
    sliderRange.slider({
        range: true,
        min: 5000,
        max: 600000,
        values: [5500, 595000],
        slide: function(event, ui) {
            ammout.val("₹" + ui.values[0] + " - ₹" + ui.values[1]);
        }
    });
    ammout.val("$" + sliderRange.slider("values", 0) +
        " - $" + sliderRange.slider("values", 1));


		/*============  zoom ===*/
		$("#big-img").elevateZoom({
        constrainType: "width",
        containLensZoom: true,
        gallery: 'small-img',
        cursor: 'pointer',
        galleryActiveClass: "active"
    });
    
	
	 /*-------------------------------------
    9. Thumbnail Product activation
    --------------------------------------*/
    $('.thumb-menu').owlCarousel({
        loop: false,
        navText: ["<i class='fa fa-angle-left'></i>" , "<i class='fa fa-angle-right'></i>"],
        margin: 15,
        smartSpeed: 1000,
        nav: true,
        dots: false,
        responsive: {
            0: {
                items: 4
            },
            600: {
                items: 4
            },
            1000: {
                items: 4
            }
        }
    })

	/*------------------------------
     4.2 Category menu Activation
    ------------------------------*/
    $('#cate-toggle li.has-sub>a,#cate-mobile-toggle li.has-sub>a,#shop-cate-toggle li.has-sub>a').on('click', function () {
        $(this).removeAttr('href');
        var element = $(this).parent('li');
        if (element.hasClass('open')) {
            element.removeClass('open');
            element.find('li').removeClass('open');
            element.find('ul').slideUp();
        } else {
            element.addClass('open');
            element.children('ul').slideDown();
            element.siblings('li').children('ul').slideUp();
            element.siblings('li').removeClass('open');
            element.siblings('li').find('li').removeClass('open');
            element.siblings('li').find('ul').slideUp();
        }
    });
    $('#cate-toggle>ul>li.has-sub>a').append('<span class="holder"></span>');


    /*======= date pickers ======*/
	 $('.dob_pickers').datetimepicker({
        format: 'dd-mm-yyyy',
        autoclose: true,
        minView: 2,
        startDate: '01-01-1950',
        endDate: '+0d',
        todayHighlight: true
      });
	/*$(".dob_pickers").datetimepicker({
        format: "dd MM yyyy - hh:ii"
    });*/
	
	/*=== quantity ====*/
	//quantity-box
/*var unit = $("#cart_qty").val();
var total;
// if user changes value in field
$('.field').change(function() {
  unit = this.value;
});
$('.add').click(function() {
  unit++;
  var $input = $(this).prevUntil('.sub');
  $input.val(unit);
  unit = unit;
});
$('.sub').click(function() {
  if (unit > 0) {
    unit--;
    var $input = $(this).nextUntil('.add');
    $input.val(unit);
  }
});*/




})(window.jQuery);