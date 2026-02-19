export function modal(modalRef) {
    const modal = getModalInstance(modalRef);
    if (modal) {
        modal.hide();
    }
}

export function show(modalRef) {
    const modal = getModalInstance(modalRef);
    if (modal) {
        modal.show();
    }
}

export function toggle(modalRef) {
    const modal = getModalInstance(modalRef);
    if (modal) {
        modal.toggle();
    }
}

export function handleUpdate(modalRef) {
    const modal = getModalInstance(modalRef);
    if (modal) {
        modal.handleUpdate();
    }
}

export function dispose(modalRef) {
    const modal = getModalInstance(modalRef);
    if (modal) {
        modal.dispose();
    }
}

function getModalInstance(modalRef) {
    if (!modalRef) return;

    return bootstrap.Modal.getOrCreateInstance(modalRef);
}