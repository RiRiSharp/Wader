export function create(hostElementRef, options) {
    if (!hostElementRef) return;

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