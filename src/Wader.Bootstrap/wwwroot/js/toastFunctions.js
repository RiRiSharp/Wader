export function create(toastRef, options) {
    if (!toastRef) return;

    // Makes settings immutable
    const existing = bootstrap.Toast.getInstance(toastRef);
    if (existing) {
        existing.dispose();
    }

    if (options) {
        return bootstrap.Toast.getOrCreateInstance(toastRef, options);
    }
    return bootstrap.Toast.getOrCreateInstance(toastRef);
}

export function show(toastRef) {
    if (!toastRef) return;

    const toast = bootstrap.Toast.getInstance(toastRef);
    toast.show();
}

export function hide(toastRef) {
    if (!toastRef) return;

    const toast = bootstrap.Toast.getInstance(toastRef);
    if (toast) {
        toast.hide();
    }
}

export function dispose(hostElementRef) {
    const toast = bootstrap.Toast.getInstance(hostElementRef);
    if (toast) {
        toast.dispose();
    }
}