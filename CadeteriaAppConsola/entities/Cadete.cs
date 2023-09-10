using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

class Cadete
{
    public int Id { get; set; }
    public string Direccion { get; set; }
    public string Nombre { get; set; }
    public string NumeroTelefono { get; set; }
    //public List<Pedido> Pedidos { get; set; }

    public Cadete(){} //lo necesito por csvHelper
    public Cadete(int id, string direccion, string nombre, string numeroTelefono)
    {
        Id = id;
        Direccion = direccion;
        Nombre = nombre;
        NumeroTelefono = numeroTelefono;
        //Pedidos = new List<Pedido>();
    }
/*
    public void AgregarPedido(Pedido pedido)
    {
        Pedidos.Add(pedido);
    }

    public void EliminarPedido(Pedido pedido)
    {
        Pedidos.Remove(pedido);
    }

    public decimal CalcularJornal()
    {
        int pedidosEntregados = Pedidos.Count(pedido => pedido.Estado == EstadoPedido.Entregado);
        decimal jornal = pedidosEntregados * 500;
        return jornal;
    }
*/
    public void GuardarCadeteEnCSV(string filePath)
    {
        using (var writer = new StreamWriter(filePath))
        using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
        {
            csv.WriteRecord(this);
        }
    }

    public static Cadete LeerCadeteDesdeCSV(string filePath)
    {
        using (var reader = new StreamReader(filePath))
        using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
        {
            return csv.GetRecords<Cadete>().FirstOrDefault();
        }
    }
}