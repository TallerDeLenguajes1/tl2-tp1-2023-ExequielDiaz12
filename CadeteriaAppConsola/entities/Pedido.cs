using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

enum EstadoPedido
{
    Pendiente,
    Entregado
}
class Pedido
{
    public int Id { get; set; }
    public string Producto { get; set; }
    public string DireccionEntrega { get; set; }
    public EstadoPedido Estado { get; set; }
    public Cadete CadeteAsignado { get; set; }
    public Cliente Cliente { get; set; }

    public Pedido(){}//eso
    public Pedido(int id, string producto, string direccionEntrega, Cliente cliente)
    {
        Id = id;
        Producto = producto;
        DireccionEntrega = direccionEntrega;
        Estado = EstadoPedido.Pendiente;
        Cliente = cliente;
        
    }

    public void CambiarEstadoPedido(EstadoPedido nuevoEstado)
    {
        Estado = nuevoEstado;
    }

    public void ReasignarCadete(Cadete nuevoCadete)
    {
        CadeteAsignado = nuevoCadete;
    }

    public void MostrarDireccionCliente(){
        Console.WriteLine($"La direccion del cliente {Cliente.Nombre} es {Cliente.Direccion}");
    }

    public void MostrarDatosCliente(){
        Console.WriteLine($"Id: {Cliente.Id}");
        Console.WriteLine($"Nombre: {Cliente.Nombre}");
        Console.WriteLine($"Direccion: {Cliente.Direccion}");
        Console.WriteLine($"Telefono: {Cliente.NumeroTelefono}");
    }

    public void GuardarPedidoEnCSV(string filePath)
    {
        using (var writer = new StreamWriter(filePath))
        using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
        {
            csv.WriteRecord(this);
        }
    }
    public static Pedido LeerPedidoDesdeCSV(string filePath)
    {
        using (var reader = new StreamReader(filePath))
        using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
        {
            return csv.GetRecords<Pedido>().FirstOrDefault();
        }
    }
}