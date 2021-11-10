function eliminarHorario() {
    Swal.fire({
        title: 'Seguro que deseas dar de baja el turno?',
        text: "Se dara de baja!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#d33',
        confirmButtonText: 'Confirmar',
        showCancelButton: true,
        cancelButtonColor: '#3085d6',
        cancelButtonText: 'Cancelar'
    }).then((result) => {
        if (result.isConfirmed) {
            var elimi = document.getElementById('eliminarHorario');
            window.location.href = "/eliminarHorario.aspx?id=" + elimi.value;
        }
    })
}