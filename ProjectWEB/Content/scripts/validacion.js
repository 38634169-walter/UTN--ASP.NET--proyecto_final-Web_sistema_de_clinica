
function validar_paciente() {
    var vali = true;
    
    if ($('#TextBoxNombre').val() == "") {
        $('#TextBoxNombre').addClass('is-invalid');
        $('#TextBoxNombre').removeClass('is-valid');
        vali = false;
    }
    else {
        $('#TextBoxNombre').addClass('is-valid');
        $('#TextBoxNombre').removeClass('is-invalid');
    }
    
    if ($('#TextBoxApellido').val() == "") {
        $('#TextBoxApellido').addClass('is-invalid');
        $('#TextBoxApellido').removeClass('is-valid');
        vali = false;
    }
    else {
        $('#TextBoxApellido').addClass('is-valid');
        $('#TextBoxApellido').removeClass('is-invalid');
    }
    if ($('#TextBoxDni').val() == "") {
        $('#TextBoxDni').addClass('is-invalid');
        $('#TextBoxDni').removeClass('is-valid');
        vali = false;
    }
    else {
        $('#TextBoxDni').addClass('is-valid');
        $('#TextBoxDni').removeClass('is-invalid');
    }
    if ($('#TextBoxEmail').val() == "") {
        $('#TextBoxEmail').addClass('is-invalid');
        $('#TextBoxEmail').removeClass('is-valid');
        vali = false;
    }
    else {
        $('#TextBoxEmail').addClass('is-valid');
        $('#TextBoxEmail').removeClass('is-invalid');
    }
    if ($('#TextBoxTelefono').val() == "") {
        $('#TextBoxTelefono').addClass('is-invalid');
        $('#TextBoxTelefono').removeClass('is-valid');
        vali = false;
    }
    else {
        $('#TextBoxTelefono').addClass('is-valid');
        $('#TextBoxTelefono').removeClass('is-invalid');
    }

    return vali;
}

function validar_historial() {
    var vali = true;

    if ($('#TextBoxObservacion').val() == "") {
        $('#TextBoxObservacion').addClass('is-invalid');
        $('#TextBoxObservacion').removeClass('is-valid');
        vali = false;
    }
    else {
        $('#TextBoxObservacion').addClass('is-valid');
        $('#TextBoxObservacion').removeClass('is-invalid');
    }
    return vali;
}

function validar_horario_doctor() {
    var vali = true;

    if ($('#TextBoxHorarioInicio').val() == "") {
        $('#TextBoxHorarioInicio').addClass('is-invalid');
        $('#TextBoxHorarioInicio').removeClass('is-valid');
        vali = false;
    }
    else {
        $('#TextBoxHorarioInicio').addClass('is-valid');
        $('#TextBoxHorarioInicio').removeClass('is-invalid');
    }
    if ($('#TextBoxHorarioFin').val() == "") {
        $('#TextBoxHorarioFin').addClass('is-invalid');
        $('#TextBoxHorarioFin').removeClass('is-valid');
        vali = false;
    }
    else {
        $('#TextBoxHorarioFin').addClass('is-valid');
        $('#TextBoxHorarioFin').removeClass('is-invalid');
    }

    return vali;
}

function validar_especialidad(){
    var vali = true;

    if ($('#TextBoxEspecialidad').val() == "") {
        $('#TextBoxEspecialidad').addClass('is-invalid');
        $('#TextBoxEspecialidad').removeClass('is-valid');
        vali = false;
    }
    else {
        $('#TextBoxEspecialidad').addClass('is-valid');
        $('#TextBoxEspecialidad').removeClass('is-invalid');
    }
    return vali;
}

function validar_agregar_doctor() {
    var vali = true;

    if ($('#TextBoxNombre').val() == "") {
        $('#TextBoxNombre').addClass('is-invalid');
        $('#TextBoxNombre').removeClass('is-valid');
        vali = false;
    }
    else {
        $('#TextBoxNombre').addClass('is-valid');
        $('#TextBoxNombre').removeClass('is-invalid');
    }
    if ($('#TextBoxApellido').val() == "") {
        $('#TextBoxApellido').addClass('is-invalid');
        $('#TextBoxApellido').removeClass('is-valid');
        vali = false;
    }
    else {
        $('#TextBoxApellido').addClass('is-valid');
        $('#TextBoxApellido').removeClass('is-invalid');
    }
    if ($('#TextBoxDni').val() == "") {
        $('#TextBoxDni').addClass('is-invalid');
        $('#TextBoxDni').removeClass('is-valid');
        vali = false;
    }
    else {
        $('#TextBoxDni').addClass('is-valid');
        $('#TextBoxDni').removeClass('is-invalid');
    }
    if ($('#TextBoxTelefono').val() == "") {
        $('#TextBoxTelefono').addClass('is-invalid');
        $('#TextBoxTelefono').removeClass('is-valid');
        vali = false;
    }
    else {
        $('#TextBoxTelefono').addClass('is-valid');
        $('#TextBoxTelefono').removeClass('is-invalid');
    }
    if ($('#TextBoxEmail').val() == "") {
        $('#TextBoxEmail').addClass('is-invalid');
        $('#TextBoxEmail').removeClass('is-valid');
        vali = false;
    }
    else {
        $('#TextBoxEmail').addClass('is-valid');
        $('#TextBoxEmail').removeClass('is-invalid');
    }
    if ($('#TextBoxSueldo').val() == "") {
        $('#TextBoxSueldo').addClass('is-invalid');
        $('#TextBoxSueldo').removeClass('is-valid');
        vali = false;
    }
    else {
        $('#TextBoxSueldo').addClass('is-valid');
        $('#TextBoxSueldo').removeClass('is-invalid');
    }
    if ($('#DropEspecilidad').val() == "") {
        $('#DropEspecilidad').addClass('is-invalid');
        $('#DropEspecilidad').removeClass('is-valid');
        vali = false;
    }
    else {
        $('#DropEspecilidad').addClass('is-valid');
        $('#DropEspecilidad').removeClass('is-invalid');
    }
    if ($('#TextBoxHorarioEntrada').val() == "") {
        $('#TextBoxHorarioEntrada').addClass('is-invalid');
        $('#TextBoxHorarioEntrada').removeClass('is-valid');
        vali = false;
    }
    else {
        $('#TextBoxHorarioEntrada').addClass('is-valid');
        $('#TextBoxHorarioEntrada').removeClass('is-invalid');
    }
    if ($('#TextBoxHorarioSalida').val() == "") {
        $('#TextBoxHorarioSalida').addClass('is-invalid');
        $('#TextBoxHorarioSalida').removeClass('is-valid');
        vali = false;
    }
    else {
        $('#TextBoxHorarioSalida').addClass('is-valid');
        $('#TextBoxHorarioSalida').removeClass('is-invalid');
    }
    if ($('#TextBoxUsuario').val() == "") {
        $('#TextBoxUsuario').addClass('is-invalid');
        $('#TextBoxUsuario').removeClass('is-valid');
        vali = false;
    }
    else {
        $('#TextBoxUsuario').addClass('is-valid');
        $('#TextBoxUsuario').removeClass('is-invalid');
    }
    if ($('#TextBoxClave').val() == "") {
        $('#TextBoxClave').addClass('is-invalid');
        $('#TextBoxClave').removeClass('is-valid');
        vali = false;
    }
    else {
        $('#TextBoxClave').addClass('is-valid');
        $('#TextBoxClave').removeClass('is-invalid');
    }

    return vali;
}