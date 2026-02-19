export function moveToSlide(carouselRef, slideNumber) {
    const carousel = getCarouselInstanceWithCallback(carouselRef);
    carousel.to(slideNumber);
}

export function moveNext(carouselRef) {
    const carousel = getCarouselInstanceWithCallback(carouselRef);
    carousel.next();
}

export function movePrev(carouselRef) {
    const carousel = getCarouselInstanceWithCallback(carouselRef);
    carousel.prev();
}

export function cycle(carouselRef) {
    const carousel = getCarouselInstanceWithCallback(carouselRef);

    if (!carouselRef._isCycling) {
        carousel.cycle();
        carouselRef._isCycling = true;
    }
}

export function pause(carouselRef) {
    const carousel = getCarouselInstanceWithCallback(carouselRef);

    carousel.pause();
    carouselRef._isCycling = false;
}

export function addCycleCallback(carouselRef) {
    if (!carouselRef) return;
    if (carouselRef._cycleHandler) return;

    const cycleHandler = () => cycle(carouselRef);

    carouselRef._cycleHandler = cycleHandler;
    carouselRef.addEventListener('slid.bs.carousel', cycleHandler);
}

export function removeCycleCallback(carouselRef) {
    if (!carouselRef || !carouselRef._cycleHandler) return;

    carouselRef.removeEventListener('slid.bs.carousel', carouselRef._cycleHandler);
    delete carouselRef._cycleHandler;
    carouselRef._isCycling = false;
}

export function dispose(carouselRef) {
    if (!carouselRef) return;

    removeCycleCallback(carouselRef);
    const carousel = bootstrap.Carousel.getInstance(carouselRef);
    if (carousel) {
        carousel.dispose();
    }
}

function getCarouselInstanceWithCallback(carouselRef) {
    if (!carouselRef) return;

    // A creation should not also trigger riding, similar like https://github.com/RiRiSharp/Wader/issues/22
    const carousel = bootstrap.Carousel.getOrCreateInstance(carouselRef, {ride: false});

    addSlideCallback(carouselRef);
    return carousel;
}

// Set 'active' on the indicator buttons with data-bs-slide-to=slide.to 
// Bootstrap does not do this automatically when data-bs-target has not been set, which we purposefully avoid doing.
function addSlideCallback(carouselRef) {
    if (!carouselRef || carouselRef._indicatorSyncEnabled) return;

    carouselRef.addEventListener('slid.bs.carousel', function (event) {
        const indicators = carouselRef.querySelectorAll('.carousel-indicators [type="button"]');
        indicators.forEach(btn => {
            const attributeSlideNumber = parseInt(btn.getAttribute('data-bs-slide-to'));
            if (attributeSlideNumber === event.to) {
                btn.classList.add('active');
            } else {
                btn.classList.remove('active');
            }
        });
    });

    carouselRef._indicatorSyncEnabled = true;
}