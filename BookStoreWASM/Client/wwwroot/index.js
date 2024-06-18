window.setCssVariable = (variable, value) => {
    document.documentElement.style.setProperty(variable, value);
};

window.removeCssVariable = (variable) => {
    document.documentElement.style.removeProperty(variable);
};