using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using Serilog;

class AccesoJson : AccesoADatos
{
    private string clienteJsonFilePath = "clientes.json";
    private ILogger logger;

    public AccesoJson()
    {
        logger = new LoggerConfiguration()
            .WriteTo.Console()
            .CreateLogger();
    }

    public override List<Cliente> CargarClientes()
    {
        try
        {
            if (File.Exists(clienteJsonFilePath))
            {
                List<Cliente> clientes;

                using (var reader = new StreamReader(clienteJsonFilePath))
                {
                    string json = reader.ReadToEnd();
                    clientes = JsonConvert.DeserializeObject<List<Cliente>>(json);
                }

                return clientes;
            }
            else
            {
                return new List<Cliente>();
            }
        }
        catch (Exception ex)
        {
            logger.Error(ex, $"Error al cargar clientes desde JSON: {ex.Message}");
            return new List<Cliente>();
        }
    }

    public override void GuardarClientes(List<Cliente> clientes)
    {
        try
        {
            string json = JsonConvert.SerializeObject(clientes, Formatting.Indented);

            File.WriteAllText(clienteJsonFilePath, json);
        }
        catch (Exception ex)
        {
            logger.Error(ex, $"Error al guardar clientes en JSON: {ex.Message}");
        }
    }
}
