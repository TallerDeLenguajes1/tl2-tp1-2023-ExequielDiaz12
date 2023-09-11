using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using Serilog;

class AccesoCSV : AccesoADatos
{
    private string clienteCSVFilePath = "clientes.csv";
    //private string cadeteCSVFilePath = "cadetes.csv";

    private ILogger logger;
    public AccesoCSV()
    {
        logger = new LoggerConfiguration()
            .WriteTo.Console()
            .CreateLogger();
    }
    public override List<Cliente> CargarClientes()
    {
        try{
            using (var reader = new StreamReader(clienteCSVFilePath))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                var clientes = csv.GetRecords<Cliente>().ToList();
                return clientes;
            }
        }catch(Exception ex){
            logger.Error(ex, "Error al cargar clientes desde CSV");
            return new List<Cliente>(); //¿podría no devolver nada?
        }
    }
    public override void GuardarClientes(List<Cliente> clientes)
    {
        try
            {
                using (var writer = new StreamWriter(clienteCSVFilePath))
                using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
                {
                    csv.WriteRecords(clientes);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar clientes en CSV: {ex.Message}");
            }
        }
}

//¿lo de cadetes debo hacerlo aquí también?¿qué pasa con el principio de responsabilidad única?