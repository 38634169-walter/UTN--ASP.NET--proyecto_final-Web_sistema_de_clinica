# UTN--ASP.NET--proyecto_final-Web_sistema_de_clinica

SISTEMA DE CLINICA:


>>>>>>>>>PERMISOS Y ROLES:
-Completamente administrables, hecho desde la base de datos, puede cederse permisos a cualquier usuario los cuales pueden ser 3... doctores, secretarias y administrador, cualquiera puede utilizar cualquier opcion que se le otorgen los permisos, teniendo en cuenta que para poder editar y eliminar algun registro, primero tienen que tener el permiso de poder ver los datos.


>>>>>>>>>HORARIOS DE LOS MEDICOS CON SUS DIAS COMPLETAMENTE ADMINISTRABLES Y DINAMICOS:
-Al ingresar un medico al sistema ya se lo hace con un rango de horario, en los dias que se quiere con una especialidad que se quiera, tambien su usuario, contraseña y datos personales especificos.
-Luego se puede continuar asignando horarios en otros dias que se deseen o incluso en el msimo dia pero que no sea el horario que el medico ya se encuentra ocupado, por ejemplo si se ingreso el "lunes y jueves de 18hs a 22hs", no se puede asignar horarios de trabajo para el dia lunes y jueves de 18hs a 21hs (debido a que a las 22hs el medico se encontraria desocupado, si se le puede dar un horario a las 22hs).
-Al ingresarse un horario al medico se podra registrar turnos para ese medico con esa especialidad en esos horarios y dias.
-Para asignarle un horario con sus dias al medico se lo puede hacer con cualquiera de sus especialidades las cuales tambien se le pueden asignar de cualquier especialidad que ya se haya registrado en el sistema.


>>>>>>>>>MANEJO DE LAS ESPECIALIDADES DE LOS MEDICOS:
-El sistema no permite que se registren especialidades que ya se encuentra en el sistema ya sea con uppercase o lowercase o cualquiera de sus combinaicones.
-Al registrar una especialidad al sistema ya se puede otorgar la misma a cualquier medico para luego ser utilizada para la asignacion de horarios indicando el horario, dias y especilidades que el medico tiene asignadas.


>>>>>>>>>FUNCIONALIDAD DE RESERVA DE TURNOS:
-Al reservar un turno se pedira el dni y si el paciente no esta registrado, el sistema lo lleva a registrarse.
-Luego del DNI se pide ingresar una especialidad, al ingresarla se da una lista de medicos que tienen horario asignado para esa especialidad y se muestra los dias y horarios que ese medico cubre esa especialidad para que se puedan ingresar bien, se se ingresa un dia que el medico no trabaja, el sistema lo notifica aclarandolo.
-Luego se pide ingresar la fecha y al ingresar la fecha permite elegir un horario que no fue reservado en ese dia, si no hay horarios disponibles el sistema lo indica y si los hay los muestra.


>>>>>>>>>MEDICO,TURNOS, PACIENTES Y HISTORIALES:
-Los historiales se encuentran asociados a un turno, lo que genera que solamente se pueda poner un historial sobre ese turno que le pertenece a un paciente y solamente el medico que lo atiende puede ingresar la observacion en el historial, al ingresar la observacion y guardarla, esta misma no es editable y tampoco se puede eliminar solamente se puede ver y puede ser vista por cualquier medico que solicite verla(solamente los medicos o quienes tengan permiso en el sistema de roles y permisos para poder verla).
-Tambien se puede ver una lista de todos los historiales de los pacientes. 


>>>>>>>>>VER, EDITAR Y DAR DE BAJA TURNOS:
-El sistema manja estados en los turnos los cuales son atendido, esperando, modificado y cancelado.
-Si al ver los turnos el medico ya atendio el paciente el estado se pasa a atendido y  muestra botones para su cancelacion o edicion debido a que el paciente ya fue atendido y el turno ya paso.
-No se pueden ver los turnos cancelados pero todavia estan dentro del sistema debido a que manejan una baja logica implementada con TRIGGERS desde la base de datos.


>>>>>>>>>REGISTRO DE MEDICOS EN EL SISTEMA:
-Al registrarlos se lo debe hacer con un rango de horarios y dias que va a atender con una especialidad que se encuentre registrada en el sistema, junto con su usuario, clave y datos personales.
-Se valida correspondientemente que el DNI no pertenezca a un paciente o un empleado que ya esta registrado. Tambien se valida usuario existente.


>>>>>>>>>FILTRADO DE DATOS:
-En los pacientes se puede filtrar por DNI
-En el caso de turnos se puede filtrar tanto por DNI del paciente o fecha o ambos al mismo tiempo.


>>>>>>>>>VALIDACION:
-Muchas validaciones, todas las necesarias, pruebas realizadas en todo aspecto.
