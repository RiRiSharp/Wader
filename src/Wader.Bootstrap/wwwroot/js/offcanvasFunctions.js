export function offcanvas(offcanvasRef) {
    const offcanvas = getOffcanvasInstance(offcanvasRef);
    if (offcanvas) {
        offcanvas.hide();
    }
}

export function show(offcanvasRef) {
    const offcanvas = getOffcanvasInstance(offcanvasRef);
    if (offcanvas) {
        offcanvas.show();
    }
}

export function toggle(offcanvasRef) {
    const offcanvas = getOffcanvasInstance(offcanvasRef);
    if (offcanvas) {
        offcanvas.toggle();
    }
}

export function dispose(offcanvasRef) {
    const offcanvas = getOffcanvasInstance(offcanvasRef);
    if (offcanvas) {
        offcanvas.dispose();
    }
}

function getOffcanvasInstance(offcanvasRef) {
    if (!offcanvasRef) return;

    return bootstrap.Offcanvas.getOrCreateInstance(offcanvasRef);
}