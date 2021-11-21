function agregado() {
    $('#alerta').addClass('visible');
    $('#alerta').removeClass('invisible');
    $('#texto').html('Agregado con exito');
}

function eliminado() {
    $('#alerta').addClass('visible');
    $('#alerta').removeClass('invisible');
    $('#texto').html('Eliminado con exito');
}

function modificado() {
    $('#alerta').addClass('visible');
    $('#alerta').removeClass('invisible');
    $('#texto').html('Modificado con exito');
}

function confirmarEli(validar) {
    Swal.fire({
        title: 'Seuro que deseas eliminarlo?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            validar = true;
        }
    })
}