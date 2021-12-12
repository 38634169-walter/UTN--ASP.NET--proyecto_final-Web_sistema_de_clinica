<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ProjectWEB.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="~/Content/bootstrap5/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.3.1/css/all.css">
    <link href="https://fonts.googleapis.com/css2?family=Abril+Fatface&display=swap" rel="stylesheet">
    <!-- google font -->
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Abril+Fatface&display=swap" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css2?family=Bebas+Neue&family=Fredoka+One&display=swap" rel="stylesheet">
    <style>
        body{
            background: linear-gradient(90deg, rgba(2,0,36,1) 0%, rgba(9,121,55,1) 0%, rgba(0,212,255,1) 100%);
        }
        .titulo{font-family: 'Abril Fatface', cursive;}
        .titulo2{font-family: 'Fredoka One', cursive;color:white;}
    </style>
</head>
<body>
    <h1 class="text-center mt-4 shadow p-3 titulo text-dark">Bienvenido a clinica Milagro</h1>
    <div class="text-light d-flex justify-content-center align-items-center flex-sm-row flex-column p-3">
        <img src="/Content/img/giftAnimado1.gif" alt="Imagen no disponible" />
        <div class="w-10 text-sm-start text-center ms-sm-5">
            <h2 class="titulo2">Nuestra identidad importa</h2>
            <p class="titulo2">Hacemos de el mundo un lugar mejor para que todos puedan tener su oportunidad</p>
            <a class="btn btn-success" href="/login.aspx" >Ingresar al sistema</a>
        </div>
    </div>
</body>
</html>
