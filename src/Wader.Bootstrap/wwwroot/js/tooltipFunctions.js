export function createOrUpdate(hostElementRef, jsonOptions) {
    if (!hostElementRef || !jsonOptions) return;

    const normalizedOptions = normalizeOptions(jsonOptions);

    const existing = bootstrap.Tooltip.getInstance(hostElementRef);
    if (existing) {
        existing.dispose();
    }

    return new bootstrap.Tooltip(hostElementRef, normalizedOptions);
}

export function toggle(hostElementRef) {
    const tooltip = bootstrap.Tooltip.getInstance(hostElementRef);
    if (tooltip) {
        tooltip.toggle();
    }
}

export function show(hostElementRef) {
    const tooltip = bootstrap.Tooltip.getInstance(hostElementRef);
    if (tooltip) {
        tooltip.show();
    }
}

export function hide(hostElementRef) {
    const tooltip = bootstrap.Tooltip.getInstance(hostElementRef);
    if (tooltip) {
        tooltip.hide();
    }
}

export function updatePosition(hostElementRef) {
    const tooltip = bootstrap.Tooltip.getInstance(hostElementRef);
    if (tooltip) {
        tooltip.update();
    }
}

export function toggleEnabled(hostElementRef) {
    const tooltip = bootstrap.Tooltip.getInstance(hostElementRef);
    if (tooltip) {
        tooltip.toggleEnabled();
    }
}

export function enable(hostElementRef) {
    const tooltip = bootstrap.Tooltip.getInstance(hostElementRef);
    if (tooltip) {
        tooltip.enable();
    }
}

export function disable(hostElementRef) {
    const tooltip = bootstrap.Tooltip.getInstance(hostElementRef);
    if (tooltip) {
        tooltip.disable();
    }
}

export function dispose(hostElementRef) {
    const tooltip = bootstrap.Tooltip.getInstance(hostElementRef);
    if (tooltip) {
        tooltip.dispose();
    }
}

function normalizeOptions(options) {
    const normalized = Object.fromEntries(
        Object.entries(options)
            .filter(([, value]) => value !== null && value !== undefined));

    if (options.title?.dataset?.wdRemoveWrapper === "true") {
        normalized.title = normalized.title.innerHTML;
    }

    if (options.tooltipOptions) {
        options.popperConfig = JSON.parse(options.tooltipOptions);
    }

    return normalized;
}
