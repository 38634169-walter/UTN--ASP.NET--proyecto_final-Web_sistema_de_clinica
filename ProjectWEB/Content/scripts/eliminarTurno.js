function eliminarTurno(id) {
    Swal.fire({
        title: 'Seguro que deseas dar de baja el turno?',
        text: "Se dara de baja!" + id,
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#d33',
        confirmButtonText: 'Confirmar',
        showCancelButton: true,
        cancelButtonColor: '#3085d6',
        cancelButtonText: 'Cancelar'
    }).then((result) => {
        if (result.isConfirmed) {
            window.location.href = "/eliminarTurnos.aspx?id=" + id;
        }
    })
}