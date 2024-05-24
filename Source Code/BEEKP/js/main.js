;(function ( $, window, document, undefined ) {
	
    var name = "easyTicker",
        defaults = {
			direction: 'up',
			easing: 'swing',
			speed: 'slow',
			interval: 2000,
			height: 'auto',
			visible: 0,
			mousePause: 1,
			controls: {
				up: '',
				down: '',
				toggle: '',
				playText: 'Play',
				stopText: 'Stop'
			}
        };

    // Constructor
    function EasyTicker( el, options ) {
		
		var s = this;
		
        s.opts = $.extend( {}, defaults, options );
        s.elem = $(el);
		s.targ = $(el).children(':first-child');
		s.timer = 0;
		s.mHover = 0;
		s.winFocus = 1;
		
		init();
		start();
		
		$([window, document]).off('focus.jqet').on('focus.jqet', function(){
			s.winFocus = 1;
		}).off('blur.jqet').on('blur.jqet', function(){
			s.winFocus = 0;
		});
		
		if( s.opts.mousePause == 1 ){
			s.elem.mouseenter(function(){
				s.timerTemp = s.timer;
				stop();
			}).mouseleave(function(){
				if( s.timerTemp !== 0 )
					start();
			});
		}
		
		$(s.opts.controls.up).on('click', function(e){
			e.preventDefault();
			moveDir('up');
		});
		
		$(s.opts.controls.down).on('click', function(e){
			e.preventDefault();
			moveDir('down');
		});
		
		$(s.opts.controls.toggle).on('click', function(e){
			e.preventDefault();
			if( s.timer == 0 ) start();
			else stop();
		});
		
		function init(){
			
			s.elem.children().css('margin', 0).children().css('margin', 0);
			
			s.elem.css({
				position : 'relative',
				height: s.opts.height,
				overflow : 'hidden'
			});
			
			s.targ.css({
				'position' : 'absolute',
				'margin' : 0
			});
			
			setInterval( function(){
				adjHeight();
			}, 100);
			
		} // Init Method
		
		function start(){
			s.timer = setInterval(function(){
				if( s.winFocus == 1 ){
					move( s.opts.direction );
				}
			}, s.opts.interval);

			$(s.opts.controls.toggle).addClass('et-run').html(s.opts.controls.stopText);
			
		} // Start method
		
		
		function stop(){
			clearInterval( s.timer );
			s.timer = 0;
			$(s.opts.controls.toggle).removeClass('et-run').html(s.opts.controls.playText);
		}// Stop
		
		
		function move( dir ){
			var sel, eq, appType;
			
			if( !s.elem.is(':visible') ) return;

			if( dir == 'up' ){
				sel = ':first-child';
				eq = '-=';
				appType = 'appendTo';
			}else{
				sel = ':last-child';
				eq = '+=';
				appType = 'prependTo';
			}
		
			var selChild = s.targ.children(sel);
			var height = selChild.outerHeight();
			
			s.targ.stop(true, true).animate({
				'top': eq + height + "px"
			}, s.opts.speed, s.opts.easing, function(){
				
				selChild.hide()[appType]( s.targ ).fadeIn();
				s.targ.css('top', 0);
				
				adjHeight();
				
			});
		}// Move
		
		function moveDir( dir ){
			stop();
			if( dir == 'up' ) move('up'); else move('down'); 
			// start();
		}
		
		function fullHeight(){
			var height = 0;
			var tempDisp = s.elem.css('display'); // Get the current el display value
			
			s.elem.css('display', 'block');
					
			s.targ.children().each(function(){
				height += $(this).outerHeight();
			});
		
			s.elem.css({
				'display' : tempDisp,
				'height' : height
			});
		}
		
		function visHeight( anim ){
			var wrapHeight = 0;
			s.targ.children(':lt(' + s.opts.visible + ')').each(function(){
				wrapHeight += $(this).outerHeight();
			});
			
			if( anim == 1 ){
				s.elem.stop(true, true).animate({height: wrapHeight}, s.opts.speed);
			}else{
				s.elem.css( 'height', wrapHeight);
			}
		}
		
		function adjHeight(){
			if( s.opts.height == 'auto' && s.opts.visible != 0 ){
				anim = arguments.callee.caller.name == 'init' ? 0 : 1;
				visHeight( anim );
			}else if( s.opts.height == 'auto' ){
				fullHeight();
			}
		}
		
		return {
			up: function(){ moveDir('up'); },
			down: function(){ moveDir('down'); },
			start: start,
			stop: stop,
			options: s.opts
		};
		
    }

    // Attach the object to the DOM
    $.fn[name] = function ( options ) {
        return this.each(function () {
            if (!$.data(this, name)) {
                $.data(this, name, new EasyTicker( this, options ));
            }
        });
    };

})( jQuery, window, document );




/*********************************************************************** owl carousel **************** */



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