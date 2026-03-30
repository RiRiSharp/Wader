export function createOrUpdate(hostElementRef, options) {
    if (!hostElementRef || !options) return;

    const normalizedOptions = normalizeOptions(options);

    const existing = bootstrap.Popover.getInstance(hostElementRef);
    if (existing) {
        existing.dispose();
    }

    return new bootstrap.Popover(hostElementRef, normalizedOptions);
}

export function toggle(hostElementRef) {
    const popover = bootstrap.Popover.getInstance(hostElementRef);
    if (popover) {
        popover.toggle();
    }
}

export function show(hostElementRef) {
    const popover = bootstrap.Popover.getInstance(hostElementRef);
    if (popover) {
        popover.show();
    }
}

export function hide(hostElementRef) {
    const popover = bootstrap.Popover.getInstance(hostElementRef);
    if (popover) {
        popover.hide();
    }
}

export function updatePosition(hostElementRef) {
    const popover = bootstrap.Popover.getInstance(hostElementRef);
    if (popover) {
        popover.update();
    }
}

export function dispose(hostElementRef) {
    const popover = bootstrap.Popover.getInstance(hostElementRef);
    if (popover) {
        popover.dispose();
    }
}

function normalizeOptions(options) {
    const normalized = {...options};
    
    normalized.container =
        options.containerRef ??
        options.containerString ??
        options.container ??
        false;


    normalized.content = normalized.contentRef
        ? normalized.contentRef.innerHTML
        : '';

    normalized.title = normalized.titleRef
        ? normalized.titleRef.innerHTML
        : '';

    return normalized;
}
