document.querySelectorAll('[data-slider]').forEach(function (slider) {
    var track = slider.querySelector('.pf-slider__track');
    var slides = Array.from(track.children);
    var dots = Array.from(slider.querySelectorAll('.pf-slider__dot'));
    var prev = slider.querySelector('.pf-slider__btn--prev');
    var next = slider.querySelector('.pf-slider__btn--next');
    var reduceMotion = window.matchMedia('(prefers-reduced-motion: reduce)').matches;
    var index = 0;

    function fitHeight() {
        track.style.height = slides[index].offsetHeight + 'px';
    }

    function update() {
        dots.forEach(function (dot, i) {
            if (i === index) dot.setAttribute('aria-current', 'true');
            else dot.removeAttribute('aria-current');
        });
        if (prev) prev.disabled = index === 0;
        if (next) next.disabled = index === slides.length - 1;
        fitHeight();
    }

    function go(i) {
        index = Math.max(0, Math.min(slides.length - 1, i));
        track.scrollTo({
            left: index * track.clientWidth,
            behavior: reduceMotion ? 'auto' : 'smooth'
        });
        update();
    }

    // keep the dots in sync when the user swipes or scrolls
    var timer;
    track.addEventListener('scroll', function () {
        clearTimeout(timer);
        timer = setTimeout(function () {
            var i = Math.round(track.scrollLeft / track.clientWidth);
            if (i !== index) { index = i; update(); }
        }, 80);
    });

    if (prev) prev.addEventListener('click', function () { go(index - 1); });
    if (next) next.addEventListener('click', function () { go(index + 1); });
    dots.forEach(function (dot, i) { dot.addEventListener('click', function () { go(i); }); });

    slider.addEventListener('keydown', function (e) {
        if (e.key === 'ArrowLeft') go(index - 1);
        if (e.key === 'ArrowRight') go(index + 1);
    });

    // resize the frame once each image has loaded, and when the window changes size
    slider.querySelectorAll('img').forEach(function (img) {
        if (img.complete) fitHeight();
        else img.addEventListener('load', fitHeight);
    });
    window.addEventListener('resize', function () { go(index); });

    update();
});