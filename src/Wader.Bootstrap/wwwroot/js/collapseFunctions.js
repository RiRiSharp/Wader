export function collapse(collapseRef) {
    const collapse = getCollapseInstance(collapseRef);
    if (collapse) {
        collapse.hide();
    }
}

export function show(collapseRef) {
    const collapse = getCollapseInstance(collapseRef);
    if (collapse) {
        collapse.show();
    }
}

export function toggle(collapseRef) {
    const collapse = getCollapseInstance(collapseRef);
    if (collapse) {
        collapse.toggle();
    }
}

export function dispose(collapseRef) {
    const collapse = getCollapseInstance(collapseRef);
    if (collapse) {
        collapse.dispose();
    }
}

function getCollapseInstance(collapseRef) {
    if (!collapseRef) return;
    
    // A creation should not also trigger a toggle: https://github.com/RiRiSharp/Wader/issues/22
    return bootstrap.Collapse.getOrCreateInstance(collapseRef, {toggle: false});
}