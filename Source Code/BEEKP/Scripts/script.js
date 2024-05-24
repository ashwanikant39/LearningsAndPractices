(function($) { 
	 //new WOW().init();
$('[data-toggle="offcanvas"]').on('click', function () {
    $('.navbar-collapse').toggleClass('show');
    });


/* ================ Revolution Slider. ================ */
  if($('.tp-banner').length > 0){
    $('.tp-banner').show().revolution({
      delay:6000,
          startheight: 340,
          startwidth: 1170,
          hideThumbs: 1000,
          navigationType: 'none',
          touchenabled: 'on',
          onHoverStop: 'on',
          navOffsetHorizontal: 0,
          navOffsetVertical: 0,
          dottedOverlay: 'none',
          fullWidth: 'on',
    });
  }
  if($('.tp-banner-full').length > 0){
    $('.tp-banner-full').show().revolution({
      delay:6000,
          hideThumbs: 1000,
          navigationType: 'none',
          touchenabled: 'on',
          onHoverStop: 'on',
          navOffsetHorizontal: 0,
          navOffsetVertical: 0,
          dottedOverlay: 'none',
          fullScreen: 'on',
		  
    });
  } 
  


    /*==== Nav ====*/
    $('.navbar-collapse a').on('click',function(){
        $(".navbar-collapse").collapse('hide');
    });

/* ================ Nav ================ */
    $('.fa-caret-down').on("click", function(e) {
        e.preventDefault();
        $(this).next().slideToggle('');
    });
    

/* ================ Nice Select ================ */
	$(document).ready(function () {
  //$('select').niceSelect();
});



  // The slider being synced must be initialized first
  $('#carousel').flexslider({
    animation: "slide",
    controlNav: false,
    animationLoop: false,
    slideshow: false,
    itemWidth: 210,
    itemMargin: 5,
    asNavFor: '#slider'
  });
 
  $('#slider').flexslider({
    animation: "slide",
    controlNav: false,
    animationLoop: false,
    slideshow: false,
    sync: "#carousel"
  });


})(jQuery);

if ($('.strnix-carousel').length) {
			$(".strnix-carousel").each(function (index) {
			var $owlAttr = {navText: [ '<span class="icon fa fa-angle-left"></span>', '<span class="icon fa fa-angle-right"></span>' ]},
			$extraAttr = $(this).data("options");
			$.extend($owlAttr, $extraAttr);
			$(this).owlCarousel($owlAttr);
		});
	}



  /****************Data Counter*************** */

  $(document).ready(function(){
    $('.counter-value').each(function(){
        $(this).prop('Counter',0).animate({
            Counter: $(this).text()
        },{
            duration: 3500,
            easing: 'swing',
            step: function (now){
               // $(this).text(Math.ceil(now));
            }
        });
    });
});




 $(".welcome-box").hover(function(){
		 if($(this).hasClass("active")){
			 $(this).removeClass("active");
		 }else{
		   $(this).addClass("active");
	     }
	});
	
	$('#useful-links').easyTicker({
		direction: 'up',
		easing: 'easeInOutSine',
		speed: 'slow',
		interval: 12000,
		height: 'auto',
		visible: 4,
		mousePause: 1,
		controls: {
			up: '.links-up',
			down: '.links-down'
		}
	}).data('easyTicker');
	
	$('.news-events').easyTicker({
		direction: 'up',
		easing: 'easeInOutSine',
		speed: 'slow',
		interval: 16000,
		height: 'auto',
		visible: 3,
		mousePause: 1,
		controls: {
			up: '.news-up',
			down: '.news-down'
		}
	}).data('easyTicker');
	


  $(document).ready(function() {

    $('.pgwSlider').pgwSlider({

		transitionEffect:"sliding",	

		displayControls:true,

		touchControls:true,

		verticalCentering:true,

		adaptiveHeight:true,

		maxHeight:410,

		intervalDuration:4000

	});

});

var num = 200; //number of pixels before modifying styles

$(window).bind('scroll', function () {
    if ($(window).scrollTop() > num) {
        $('.navbar-bg').addClass('sticky-nav');
    } else {
        $('.navbar-bg').removeClass('sticky-nav');
    }
});


$("body").append('<a href="javascript:" id="back-to-top"><i class="fa fa-chevron-up"></i></a>'), 
$(document).ready(function() {
	$(window).scroll(function() {
		$(this).scrollTop() > 50 ? $("#back-to-top").fadeIn() : $("#back-to-top").fadeOut()
	}), $("#back-to-top").click(function() {
		return $("body,html").animate({
			scrollTop: 0
		}, 1500, "easeInOutExpo"), !1
	})
})

$('.rs-carousel').each(function() {
	var owlCarousel = $(this),
	loop = owlCarousel.data('loop'),
	rewind = owlCarousel.data('rewind'),
	items = owlCarousel.data('items'),
	margin = owlCarousel.data('margin'),
	stagePadding = owlCarousel.data('stage-padding'),
	autoplay = owlCarousel.data('autoplay'),
	autoplayTimeout = owlCarousel.data('autoplay-timeout'),
	smartSpeed = owlCarousel.data('smart-speed'),
	dots = owlCarousel.data('dots'),
	nav = owlCarousel.data('nav'),
	navSpeed = owlCarousel.data('nav-speed'),
	xsDevice = owlCarousel.data('mobile-device'),
	xsDeviceNav = owlCarousel.data('mobile-device-nav'),
	xsDeviceDots = owlCarousel.data('mobile-device-dots'),
	smDevice = owlCarousel.data('ipad-device'),
	smDeviceNav = owlCarousel.data('ipad-device-nav'),
	smDeviceDots = owlCarousel.data('ipad-device-dots'),
	smDevice2 = owlCarousel.data('ipad-device2'),
	smDeviceNav2 = owlCarousel.data('ipad-device-nav2'),
	smDeviceDots2 = owlCarousel.data('ipad-device-dots2'),
	mdDevice = owlCarousel.data('md-device'),
	centerMode = owlCarousel.data('center-mode'),
	HoverPause = owlCarousel.data('hoverpause'),
	mdDeviceNav = owlCarousel.data('md-device-nav'),
	mdDeviceDots = owlCarousel.data('md-device-dots');
	owlCarousel.owlCarousel({
		loop: (loop ? true : false),
		rewind: (rewind ? true : false),
		items: (items ? items : 4),
		lazyLoad: true,
		center: (centerMode ? true : false),
		autoplayHoverPause: (HoverPause ? true : false),
		margin: (margin ? margin : 0),
		//stagePadding: (stagePadding ? stagePadding : 0),
		autoplay: (autoplay ? true : false),
		autoplayTimeout: (autoplayTimeout ? autoplayTimeout : 1000),
		smartSpeed: (smartSpeed ? smartSpeed : 250),
		dots: (dots ? true : false),
		nav: (nav ? true : false),
		navText: ["<i class='fa fa-angle-left'></i>", "<i class='fa fa-angle-right'></i>"],
		navSpeed: (navSpeed ? true : false),
		responsiveClass: true,
		responsive: {
			0: {
				items: (xsDevice ? xsDevice : 1),
				nav: (xsDeviceNav ? true : false),
				dots: (xsDeviceDots ? true : false),
				center: false,
			},
			576: {
				items: (smDevice2 ? smDevice2 : 2),
				nav: (smDeviceNav2 ? true : false),
				dots: (smDeviceDots2 ? true : false),
				center: false,
			},
			768: {
				items: (smDevice ? smDevice : 3),
				nav: (smDeviceNav ? true : false),
				dots: (smDeviceDots ? true : false),
				center: false,
			},
			992: {
				items: (mdDevice ? mdDevice : 4),
				nav: (mdDeviceNav ? true : false),
				dots: (mdDeviceDots ? true : false),
			}
		}
	});
});


var timelineSwiper = new Swiper(".timeline .swiper-container", {
  direction: "vertical",
  loop: false,
  speed: 1600,
  autoplay: 15000,/*{
    delay: 10000,
	disableOnInteraction: false,
  },*/
  pagination: ".swiper-pagination",
  paginationBulletRender: function (swiper, index, className) {
    var year = document.querySelectorAll(".swiper-slide")[index].getAttribute("data-year");
    return '<span class="' + className + '">' + year + "</span>";
  },
  //paginationClickable: true,
  
  /*pagination: {
	el: ".swiper-pagination",
	clickable: true,
	renderBullet: function (swiper, index, className) {
	  //return '<span class="' + className + '">' + (index + 1) + "</span>";
	   var year = document.querySelectorAll(".swiper-slide")[index].getAttribute("data-year");
      return '<span class="' + className + '">' + year + "</span>";
	},
  },*/
  nextButton: ".swiper-button-next",
  prevButton: ".swiper-button-prev",
  
  /*navigation: {
	nextEl: ".swiper-button-next",
	prevEl: ".swiper-button-prev",
  },*/
		
  breakpoints: {
    768: {
      direction: "horizontal"
    }
	
  }
});
