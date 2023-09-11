using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Serilog;

//creo el log para anotar los errores 
    Log.Logger = new LoggerConfiguration()
        .WriteTo.Console()
        .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
        .CreateLogger();

    
    var accesoCsv = new AccesoCSV();
    var accesoJson = new AccesoJson();

    try
    {
        // Creo una instancia de Cadeteria
        Cadeteria cadeteria = new Cadeteria(1,"Mercado Libre","0800-888-9999");

        // Creo los clientes
        Cliente cliente1 = new Cliente(1,"Exequiel", "Dirección1", "123-456-7890");
        Cliente cliente2 = new Cliente(2,"Daiana", "Dirección2", "987-654-3210");

        // Agregar clientes a la Cadeteria ¿debería ser composicion o agregacion o depende del diseño del programador?
        cadeteria.AgregarCliente(cliente1);//aqui hay una relacion de agregacion porque cadeteria no crea los clientes
        cadeteria.AgregarCliente(cliente2);
        accesoCsv.GuardarClientes(cadeteria.Clientes);
        accesoJson.GuardarClientes(cadeteria.Clientes);
        // Cre0 cadetes 
        Cadete cadete1 = new Cadete(1,"Exeiza","Correo Argentino", "555-555-5555");
        Cadete cadete2 = new Cadete(2,"Capital federal","Andreani", "444-444-4444");

        // Agregar cadetes a la Cadeteria
        cadeteria.Cadetes.Add(cadete1);
        cadeteria.Cadetes.Add(cadete2);

        // Creo pedidos
        Pedido pedido1 = new Pedido(1,"PC gamer", "Dirección1", cliente1);//¿acá de beria hacer client1.Direccion?
        Pedido pedido2 = new Pedido(2,"Coleccion Nietzche", "Dirección2", cliente2);

        // Agregar pedidos a la Cadeteria
        cadeteria.AgregarPedido(pedido1);
        cadeteria.AgregarPedido(pedido2);

        // Asignar pedidos a cadetes
        
        cadeteria.AsignarCadeteAPedido(1,1);
        cadeteria.AsignarCadeteAPedido(2, 2);

        // Cambiar estado de un pedido
        pedido1.CambiarEstadoPedido(EstadoPedido.Entregado);
        // Generar informe de actividad
    
        Console.WriteLine($"el jornal a caobrar de {cadete1.Nombre} es {cadeteria.JornalACobrar(1)}");
        cadeteria.GuardarCadeteriaEnCSV("cadeteria.csv");
    }
    catch (Exception ex)
    {
        Log.Error(ex, $"Error: {ex}");
        throw;
    }

    
    
    //cierro el log
    Log.CloseAndFlush();
