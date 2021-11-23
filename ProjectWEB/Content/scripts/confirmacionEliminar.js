
var object = { status: false, element: null };

function eliminarTurno(e) {

    if (object.status) { return true; };
    Swal.fire({
        title: 'Seguro que deseas dar de baja el turno?',
        text: "Se dara de baja!" + id,
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#d33',
        confirmButtonText: 'Confirmar',
        showCancelButton: true,
        cancelButtonColor: '#3085d6',
        cancelButtonText: 'Cancelar',
        closeOnConfirm: true
    },
        function () {
            object.status = true;
            object.element = e;
            object.element.click();
        
        }
    );
    return false;
}