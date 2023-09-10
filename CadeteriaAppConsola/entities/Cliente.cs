using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

class Cliente
{
    public int Id;
    public string Nombre { get; set; }
    public string Direccion { get; set; }
    public string NumeroTelefono { get; set; }
    public List<Pedido> Pedidos { get; set; }

    public Cliente(){} //necesito un construcot vacio para usar csvHelper
    public Cliente(int id, string nombre, string direccion, string numeroTelefono)
    {
        Id = id;
        Nombre = nombre;
        Direccion = direccion;
        NumeroTelefono = numeroTelefono;
        Pedidos = new List<Pedido>();
    }

    public void EliminarCliente()
    {
        // Eliminar cliente y sus pedidos
        foreach (var pedido in Pedidos)
        {
            pedido.Cliente = null;
        }
    }

    public void GuardarClienteEnCSV(string filePath)
    {
        using (var writer = new StreamWriter(filePath))
        using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
        {
            csv.WriteRecord(this);
        }
    }

    public static Cliente LeerClienteDesdeCSV(string filePath)
    {
        using (var reader = new StreamReader(filePath))
        using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
        {
            return csv.GetRecords<Cliente>().FirstOrDefault();
        }
    }
}