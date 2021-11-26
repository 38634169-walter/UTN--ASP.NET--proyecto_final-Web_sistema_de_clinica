function validar_permiso(identificador) {
    var elem = document.querySelectorAll(`.${identificador}`);
    elem.forEach(element => {
        element.classList.add("d-block");
        element.classList.remove("d-none");
    });
}