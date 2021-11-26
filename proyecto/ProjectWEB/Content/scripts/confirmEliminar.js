var object = { status: false, ele: null };
var b = 1;

function eliminar_confirmacion(e) {

    if (object.status) { return true; };


    Swal.fire({
        title: 'Seguro que deseas dar de baja el turno?',
        text: "Se dara de baja!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#d33',
        confirmButtonText: 'Confirmar',
        showCancelButton: true,
        cancelButtonColor: '#3085d6',
        cancelButtonText: 'Cancelar',
        closeOnConfirm: true

    }).then((result) => {
        if (result.isConfirmed) {
            object.status = true;
            object.ele = e;
            object.ele.click();
            eliminarTurno(this);
            b = 0;
        }
    })
    return false;

};