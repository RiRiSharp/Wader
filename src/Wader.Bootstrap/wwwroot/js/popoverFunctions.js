export function createOrUpdate(hostElementRef, jsonOptions) {
    if (!hostElementRef || !jsonOptions) return;

    const normalizedOptions = normalizeOptions(jsonOptions);

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

export function toggleEnabled(hostElementRef) {
    const popover = bootstrap.Popover.getInstance(hostElementRef);
    if (popover) {
        popover.toggleEnabled();
    }
}

export function enable(hostElementRef) {
    const popover = bootstrap.Popover.getInstance(hostElementRef);
    if (popover) {
        popover.enable();
    }
}

export function disable(hostElementRef) {
    const popover = bootstrap.Popover.getInstance(hostElementRef);
    if (popover) {
        popover.disable();
    }
}

export function dispose(hostElementRef) {
    const popover = bootstrap.Popover.getInstance(hostElementRef);
    if (popover) {
        popover.dispose();
    }
}

function normalizeOptions(options) {
    const normalized = Object.fromEntries(
        Object.entries(options)
            .filter(([, value]) => value !== null && value !== undefined));

    if (options.content?.dataset?.wdRemoveWrapper === "true") {
        normalized.content = normalized.content.innerHTML;
    }

    if (options.title?.dataset?.wdRemoveWrapper === "true") {
        normalized.title = normalized.title.innerHTML;
    }

    if (options.popoverOptions) {
        options.popperConfig = JSON.parse(options.popoverOptions);
    }

    return normalized;
}
