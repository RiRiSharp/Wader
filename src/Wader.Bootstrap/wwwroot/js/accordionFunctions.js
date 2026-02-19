const togglingState = new WeakMap();

export function showAll(accordionRef) {
    if (!accordionRef) return;

    const items = accordionRef.querySelectorAll('.accordion-item');
    items.forEach(item => show(item, true)); // use public version with locking
}

export function collapseAll(accordionRef) {
    if (!accordionRef) return;

    const items = accordionRef.querySelectorAll('.accordion-item');
    items.forEach(collapse); // use public version with locking
}


export function collapseAllButOne(accordionRef, accordionItemRef) {
    if (!accordionRef || !accordionItemRef) return;

    const items = accordionRef.querySelectorAll('.accordion-item');
    items.forEach(item => {
        if (item === accordionItemRef) {
            show(item);
            return;
        }
        collapse(item);
    });
}

export function toggle(accordionItemRef, alwaysOpen = false) {
    const collapseElement = accordionItemRef.querySelector('.accordion-collapse');
    const buttonElement = accordionItemRef.querySelector('.accordion-button');
    if (!collapseElement || togglingState.get(collapseElement)) return;

    togglingState.set(collapseElement, true);

    const isCollapsed = buttonElement.classList.contains('collapsed');
    updateButtonState(buttonElement, !isCollapsed);

    const collapseInstance = bootstrap.Collapse.getOrCreateInstance(collapseElement);
    collapseInstance.toggle();

    if (!alwaysOpen) {
        collapseOtherAccordionItems(accordionItemRef);
    }

    const clearState = () => togglingState.set(collapseElement, false);
    collapseElement.addEventListener('shown.bs.collapse', clearState, {once: true});
    collapseElement.addEventListener('hidden.bs.collapse', clearState, {once: true});
}

export function show(accordionItemRef, alwaysOpen = false) {
    const collapseElement = accordionItemRef.querySelector('.accordion-collapse');
    if (!collapseElement || togglingState.get(collapseElement)) return;

    if (collapseElement.classList.contains('show')) {
        return; // Already shown, no need to proceed
    }

    togglingState.set(collapseElement, true);
    showInt(accordionItemRef);

    if (!alwaysOpen) {
        collapseOtherAccordionItems(accordionItemRef);
    }

    collapseElement.addEventListener('shown.bs.collapse', () => {
        togglingState.set(collapseElement, false);
    }, {once: true});
}

export function collapse(accordionItemRef) {
    const collapseElement = accordionItemRef.querySelector('.accordion-collapse');
    if (!collapseElement || togglingState.get(collapseElement)) return;

    if (!collapseElement.classList.contains('show')) {
        return; // Already collapsed, no need to proceed
    }

    togglingState.set(collapseElement, true);
    collapseInt(accordionItemRef);

    collapseElement.addEventListener('hidden.bs.collapse', () => {
        togglingState.set(collapseElement, false);
    }, {once: true});
}

export function registerCollapseCallback(hasCollapseElementReference, hasCollapseDotNetRef) {
    if (!hasCollapseElementReference) return;

    let parent = hasCollapseElementReference.closest('.accordion-item');
    if (!parent) return;

    // Find the collapse element inside that item
    let collapseEl = parent.querySelector('.accordion-collapse');
    if (!collapseEl) return;

    collapseEl.addEventListener('shown.bs.collapse', () => {
        hasCollapseDotNetRef.invokeMethodAsync('UpdateCollapseState', false);
    });

    collapseEl.addEventListener('hidden.bs.collapse', () => {
        hasCollapseDotNetRef.invokeMethodAsync('UpdateCollapseState', true);
    });
}

export function dispose(accordionItemRef) {
    const collapseElement = accordionItemRef.querySelector('.accordion-collapse');
    if (!collapseElement) return;

    const collapseInstance = bootstrap.Collapse.getOrCreateInstance(collapseElement, {toggle: false});
    collapseInstance.dispose();
}

function updateButtonState(buttonElement, isCollapsed) {
    if (!buttonElement) return;
    buttonElement.setAttribute('aria-expanded', String(!isCollapsed));
    buttonElement.classList.toggle('collapsed', isCollapsed);
}

function collapseOtherAccordionItems(accordionItemRef) {
    const accordionParent = accordionItemRef.closest('.accordion');
    if (accordionParent) {
        const otherItems = Array.from(accordionParent.querySelectorAll('.accordion-item'))
            .filter(item => item !== accordionItemRef);
        otherItems.forEach(collapseInt);
    }
}

function showInt(accordionItemRef) {
    const collapseElement = accordionItemRef.querySelector('.accordion-collapse');
    const buttonElement = accordionItemRef.querySelector('.accordion-button');
    if (!collapseElement) return;

    const collapseInstance = bootstrap.Collapse.getOrCreateInstance(collapseElement, {toggle: false});
    collapseInstance.show();
    updateButtonState(buttonElement, false);
}

function collapseInt(accordionItemRef) {
    const collapseElement = accordionItemRef.querySelector('.accordion-collapse');
    const buttonElement = accordionItemRef.querySelector('.accordion-button');
    if (!collapseElement || !buttonElement) return;

    const collapseInstance = bootstrap.Collapse.getOrCreateInstance(collapseElement, {toggle: false});
    collapseInstance.hide();
    updateButtonState(buttonElement, true);
}