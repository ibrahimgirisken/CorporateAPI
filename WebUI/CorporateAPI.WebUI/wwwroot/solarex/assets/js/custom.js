(function ($) {
	"use strict";

	// Preloader
	// $(window).on('load', function () {
	// 	$('.preloader').fadeOut();
	// }
	// );

	// Animation.
    function scrollAnimation() {
        var shouldAnimate = $('body').data('scroll-animation');
        if (true === shouldAnimate) {
            new WOW({
				animateClass: 'ud-animated',
			}).init();
        }
    }
    scrollAnimation();

	// Sticky Header.
	if ($(".srex-header").length) {
		$(window).scroll(function () {
			if ($(window).scrollTop() >= 200) {
				$(".srex-header")
					.removeClass("sticky-top")
					.addClass("sticky-top");
			} else {
				$(".srex-header").removeClass("sticky-top");
			}
		});
	}

    /**
	 * Mobile Menu
	 */
	$("#mobile-menu").metisMenu();
	$("#side-menu").metisMenu();

    /**
	 * Side Popup
	 */
	$(".ud-hamburger-menu").on("click", function () {
		$(".ud-hamburger-menu__btn").toggleClass(
			"ud-hamburger-menu__btn--active"
		);
		$(".overlay").toggleClass("overlay--active");
		$(".ud-side-popup").toggleClass("ud-side-popup--open");
	});
	$(".side-popup-close").on("click", function () {
		$(".ud-hamburger-menu__btn").removeClass(
			"ud-hamburger-menu__btn--active"
		);
		$(".overlay").removeClass("overlay--active");
		$(".ud-side-popup").removeClass("ud-side-popup--open");
	});

	// Click out side of side popup to close it.
	$(document).on("click", ".overlay", function (e) {
		$(".ud-side-popup").removeClass("ud-side-popup--open");
		$(".ud-hamburger-menu__btn").removeClass(
			"ud-hamburger-menu__btn--active"
		);
		$(".overlay").removeClass("overlay--active");
	});


	/**
	 * Popup Video.
	 */
	$(".popup-video").magnificPopup({
		type: "iframe",
	});

	/**
	 * Testimonial Slider - Home One
	 */
	$(".srex-testimonial-one__slider").slick({
		dots: true,
		arrows: false,
		autoplay: true,
		autoplaySpeed: 2000,
		slidesToShow: 1,
		slidesToScroll: 1,
		fade: true,
	});

	/**
	 * Testimonial Slider - Home Two
	 */
	$(".srex-testimonial-two__slider").slick({
		dots: false,
		arrows: true,
		autoplay: true,
		autoplaySpeed: 2000,
		slidesToShow: 1,
		slidesToScroll: 1,
		fade: true,
	});

	$(".srex-testimonial-two__slider__nav__prev").on("click", function () {
		$(".srex-testimonial-two__slider").slick("slickPrev");
	});

	$(".srex-testimonial-two__slider__nav__next").on("click", function () {
		$(".srex-testimonial-two__slider").slick("slickNext");
	});


	/**
	 * Testimonial Slider - Home Three
	 */
	$(".srex-testimonial-three__slider").slick({
		dots: false,
		arrows: true,
		autoplay: true,
		autoplaySpeed: 2000,
		slidesToShow: 1,
		slidesToScroll: 1,
		fade: true,
	});

	$(".srex-testimonial-three__slider__nav__prev").on("click", function () {
		$(".srex-testimonial-three__slider").slick("slickPrev");
	});

	$(".srex-testimonial-three__slider__nav__next").on("click", function () {
		$(".srex-testimonial-three__slider").slick("slickNext");
	});


	


	/**
	 * Brand Slider.
	 */
	$(".srex-sponsor__items").slick({
		dots: false,
		arrows: false,
		autoplay: true,
		autoplaySpeed: 2000,
		slidesToShow: 5,
		slidesToScroll: 5,
		fade: false,
		responsive: [
			{
				breakpoint: 1024,
				settings: {
					slidesToShow: 4,
					slidesToScroll: 4,
					infinite: true,
				},
			},
			{
				breakpoint: 600,
				settings: {
					slidesToShow: 3,
					slidesToScroll: 3,
				},
			},
			{
				breakpoint: 480,
				settings: {
					slidesToShow: 2,
					slidesToScroll: 2,
				},
			},
		],
	});

	/**
	 * Project Slider.
	 */
	$(".srex-portfolio-three__slider").slick({
		dots: false,
		arrows: false,
		autoplay: true,
		autoplaySpeed: 2000,
		slidesToShow: 4,
		slidesToScroll: 4,
		fade: false,
		// centerMode: true,
		// centerPadding: $('.slick').find('.single-slide-whatever-you-named-it').outerWidth() / 2,
		// slidesToShow: 1,
		responsive: [
			{
				breakpoint: 1024,
				settings: {
					slidesToShow: 4,
					slidesToScroll: 4,
					infinite: true,
				},
			},
			{
				breakpoint: 600,
				settings: {
					slidesToShow: 3,
					slidesToScroll: 3,
				},
			},
			{
				breakpoint: 480,
				settings: {
					slidesToShow: 2,
					slidesToScroll: 2,
				},
			},
		],
	});

	/**
	 * Filter
	 */
	if ($("#srex-ho-filter").length) {
		$("#srex-ho-filter").mixItUp({
			selectors: {
				target: ".filter-item",
				filter: ".filter",
				sort: ".sort-btn",
			},
			animation: {
				animateResizeContainer: false,
				effects: "fade scale",
			},
		});
	}

	/**
	 * Counter Up.
	 */
	$(".counter").counterUp({
		delay: 10,
		time: 1000,
	});

})(jQuery);