

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
    if ($('#TextBoxDni').val() == "" || parseInt($('#TextBoxDni').val()) < 1 ) {
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
    if ($('#TextBoxTelefono').val() == "" || parseInt($('#TextBoxTelefono').val()) < 1 ) {
        $('#TextBoxTelefono').addClass('is-invalid');
        $('#TextBoxTelefono').removeClass('is-valid');
        vali = false;
    }
    else {
        $('#TextBoxTelefono').addClass('is-valid');
        $('#TextBoxTelefono').removeClass('is-invalid');
    }
    if ($('#TextBoxFechaNacimiento').val() == "") {
        $('#TextBoxFechaNacimiento').addClass('is-invalid');
        $('#TextBoxFechaNacimiento').removeClass('is-valid');
        vali = false;
    }
    else {
        $('#TextBoxFechaNacimiento').addClass('is-valid');
        $('#TextBoxFechaNacimiento').removeClass('is-invalid');
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

    if ($('#TextBoxHorarioInicio').val() == "" || parseInt($('#TextBoxHorarioInicio').val()) < 0 || parseInt($('#TextBoxHorarioInicio').val()) > 24 ) {
        $('#TextBoxHorarioInicio').addClass('is-invalid');
        $('#TextBoxHorarioInicio').removeClass('is-valid');
        vali = false;
    }
    else {
        $('#TextBoxHorarioInicio').addClass('is-valid');
        $('#TextBoxHorarioInicio').removeClass('is-invalid');
    }
    if ($('#TextBoxHorarioFin').val() == "" || parseInt($('#TextBoxHorarioFin').val()) < 0 || parseInt($('#TextBoxHorarioFin').val()) > 24 ) {
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
    if ($('#TextBoxTelefono').val() == "" || parseInt($('#TextBoxTelefono').val()) < 1 ) {
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
    if ($('#TextBoxSueldo').val() == "" || parseInt($('#TextBoxSueldo').val()) < 1 ) {
        $('#TextBoxSueldo').addClass('is-invalid');
        $('#TextBoxSueldo').removeClass('is-valid');
        vali = false;
    }
    else {
        $('#TextBoxSueldo').addClass('is-valid');
        $('#TextBoxSueldo').removeClass('is-invalid');
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

    var clave = $('#TextBoxClave').val();
    var validarClave = true;
    for (var i = 0; i < clave.length; i++) {
        if (clave[i] == "?" || clave[i] == ":" || clave[i] == "=" || clave[i] == "\'" || clave[i] == ")'" || clave[i] == "('" ) {
            validarClave = false;
            $('#LabelError').html("*No se puede utilizar los siguientes simbolos para la contraseña  ? , : , \' , = , ) , ( ");
            $('#errorClave').html("*No se puede utilizar los siguientes simbolos  ? , : , \' , = , ) , ( ");
        }
    }
    if (clave == "") validarClave = false;

    if (validarClave == false) {
        $('#TextBoxClave').addClass('is-invalid');
        $('#TextBoxClave').removeClass('is-valid');
        vali = false;
    }
    else {
        $('#TextBoxClave').addClass('is-valid');
        $('#TextBoxClave').removeClass('is-invalid');
    }

    if ($('#TextBoxDni').val() == "" || parseInt($('#TextBoxDni').val()) < 1) {
        $('#TextBoxDni').addClass('is-invalid');
        $('#TextBoxDni').removeClass('is-valid');
        vali = false;
    }
    else {
        $('#TextBoxDni').addClass('is-valid');
        $('#TextBoxDni').removeClass('is-invalid');
    }
    if ($('#TextBoxFechaNacimiento').val() == "") {
        $('#TextBoxFechaNacimiento').addClass('is-invalid');
        $('#TextBoxFechaNacimiento').removeClass('is-valid');
        vali = false;
    }
    else {
        $('#TextBoxFechaNacimiento').addClass('is-valid');
        $('#TextBoxFechaNacimiento').removeClass('is-invalid');
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
    if ($('#TextBoxHorarioEntrada').val() == "" || parseInt($('#TextBoxHorarioEntrada').val()) < 0 || parseInt($('#TextBoxHorarioEntrada').val()) > 24 ) {
        $('#TextBoxHorarioEntrada').addClass('is-invalid');
        $('#TextBoxHorarioEntrada').removeClass('is-valid');
        vali = false;
    }
    else {
        $('#TextBoxHorarioEntrada').addClass('is-valid');
        $('#TextBoxHorarioEntrada').removeClass('is-invalid');
    }

    if ($('#TextBoxHorarioSalida').val() == "" || parseInt($('#TextBoxHorarioSalida').val()) < 0 || parseInt($('#TextBoxHorarioSalida').val()) > 24 ) {
        $('#TextBoxHorarioSalida').addClass('is-invalid');
        $('#TextBoxHorarioSalida').removeClass('is-valid');
        vali = false;
    }
    else {
        $('#TextBoxHorarioSalida').addClass('is-valid');
        $('#TextBoxHorarioSalida').removeClass('is-invalid');
    }

    return vali;
}


function validar_modificar_doctor() {
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
    if ($('#TextBoxTelefono').val() == "" || parseInt($('#TextBoxTelefono').val()) < 1 ) {
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
    if ($('#TextBoxSueldo').val() == "" || parseInt($('#TextBoxSueldo').val()) < 1 ) {
        $('#TextBoxSueldo').addClass('is-invalid');
        $('#TextBoxSueldo').removeClass('is-valid');
        vali = false;
    }
    else {
        $('#TextBoxSueldo').addClass('is-valid');
        $('#TextBoxSueldo').removeClass('is-invalid');
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


    var clave = $('#TextBoxClave').val();
    var validarClave = true;
    for (var i = 0; i < clave.length; i++) {
        if (clave[i] == "?" || clave[i] == ":" || clave[i] == "=" || clave[i] == "\'" || clave[i] == ")'" || clave[i] == "('") {
            validarClave = false;
            $('#LabelError').html("*No se puede utilizar los siguientes simbolos para la contraseña  ? , : , \' , = , ) , ( ");
            $('#errorClave').html("*No se puede utilizar los siguientes simbolos  ? , : , \' , = , ) , ( ");
        }
    }

    if (clave == "") validarClave = false;

    if (validarClave == false) {
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


function validar_turno() {
    var vali = true;

    if ($('#TextBoxDni').val() == "" || parseInt($('#TextBoxDni').val()) < 1) {
        $('#TextBoxDni').addClass('is-invalid');
        $('#TextBoxDni').removeClass('is-valid');
        vali = false;
    }
    else {
        $('#TextBoxDni').addClass('is-valid');
        $('#TextBoxDni').removeClass('is-invalid');
    }
    if ($('#DropEspecialidad').val() == "" || $('#DropEspecialidad').val() == 0) {
        $('#DropEspecialidad').addClass('is-invalid');
        $('#DropEspecialidad').removeClass('is-valid');
        vali = false;
    }
    else {
        $('#DropEspecialidad').addClass('is-valid');
        $('#DropEspecialidad').removeClass('is-invalid');
    }
    if ($('#DropPersonalDisponible').val() == "" || $('#DropPersonalDisponible').val() == 0) {
        $('#DropPersonalDisponible').addClass('is-invalid');
        $('#DropPersonalDisponible').removeClass('is-valid');
        vali = false;
    }
    else {
        $('#DropPersonalDisponible').addClass('is-valid');
        $('#DropPersonalDisponible').removeClass('is-invalid');
    }
    if ($('#TextBoxfecha').val() == "") {
        $('#TextBoxfecha').addClass('is-invalid');
        $('#TextBoxfecha').removeClass('is-valid');
        vali = false;
    }
    else {
        $('#TextBoxfecha').addClass('is-valid');
        $('#TextBoxfecha').removeClass('is-invalid');
    }
    if ($('#DropHora').val() == "" || parseInt($('#DropHora').val()) < 1 || parseInt($('#DropHora').val()) > 24 ) {
        $('#DropHora').addClass('is-invalid');
        $('#DropHora').removeClass('is-valid');
        vali = false;
    }
    else {
        $('#DropHora').addClass('is-valid');
        $('#DropHora').removeClass('is-invalid');
    }

    return vali;
}


