export function toggle(offcanvasRef) {
    const offcanvas = getOffcanvasInstance(offcanvasRef);
    if (offcanvas) {
        offcanvas.toggle();
    }
}

export function show(offcanvasRef) {
    const offcanvas = getOffcanvasInstance(offcanvasRef);
    if (offcanvas) {
        offcanvas.show();
    }
}

export function close(offcanvasRef) {
    const offcanvas = getOffcanvasInstance(offcanvasRef);
    if (offcanvas) {
        offcanvas.hide();
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