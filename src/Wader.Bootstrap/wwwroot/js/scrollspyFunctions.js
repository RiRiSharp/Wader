export function create(hostElementRef, targetElementRef, options) {
    if (!hostElementRef) return;
    if (!targetElementRef) return;

    options.target = targetElementRef;

    // Makes settings immutable
    const existing = bootstrap.ScrollSpy.getInstance(hostElementRef);
    if (existing) {
        existing.dispose();
    }

    return bootstrap.ScrollSpy.getOrCreateInstance(hostElementRef, options)
}

export function dispose(hostElementRef) {
    const popover = bootstrap.Scrollspy.getInstance(hostElementRef);
    if (popover) {
        popover.dispose();
    }
}