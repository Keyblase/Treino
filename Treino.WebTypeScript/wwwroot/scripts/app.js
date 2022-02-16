function sayHello() {
    const compiler = document.getElementById("compiler")
        .value;
    const framework = document.getElementById("framework")
        .value;
    return `Hello from ${compiler} and ${framework}!`;
}
function teste() {
    const toggle = document.getElementById("toggle");
    const toggle_label = document.getElementById("toggle-label");
    const body = document.getElementById("body");
    const inverts = document.querySelectorAll(".invert");
    body.classList.toggle("dark-mode");
    toggle.classList.toggle("toggle-switch");
    toggle_label.innerHTML = toggle_label.innerHTML === "dark" ? "light" : "dark";
    inverts.forEach((node) => node.classList.toggle("dark-mode"));
}
//# sourceMappingURL=app.js.map