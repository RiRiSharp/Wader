export function toggle(buttonRef) {
    if (!buttonRef) return;

    const buttonInstance = bootstrap.Button.getOrCreateInstance(buttonRef);
    buttonInstance.toggle();

}

export function dispose(buttonRef) {
    if (!buttonRef) return;

    const buttonInstance = bootstrap.Button.getOrCreateInstance(buttonRef);
    buttonInstance.dispose();
}