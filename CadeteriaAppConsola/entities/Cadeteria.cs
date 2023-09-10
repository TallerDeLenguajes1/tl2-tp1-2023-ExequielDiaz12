using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

class Cadeteria
{
    public int Id { get; set;}
    public string Nombre { get; set; }
    public string NumeroTelefono { get; set; }
    public List<Cliente> Clientes { get; set; }
    public List<Pedido> Pedidos { get; set; }
    public List<Cadete> Cadetes { get; set; }

    public Cadeteria(){}
    public Cadeteria(int id, string nombre, string numeroTelefono)
    {
        Id = id;
        Nombre = nombre;    
        NumeroTelefono = numeroTelefono;
        Clientes = new List<Cliente>();
        Pedidos = new List<Pedido>();
        Cadetes = new List<Cadete>();
    }

    public void AgregarCliente(Cliente cliente)
    {
        Clientes.Add(cliente);
    }

    public void EliminarCliente(Cliente cliente)
    {
        Clientes.Remove(cliente);
        cliente.EliminarCliente();
    }

    public void AgregarPedido(Pedido pedido)
    {
        Pedidos.Add(pedido);
    }

    public void AsignarPedidoACadete(Pedido pedido, Cadete cadete)
    {
        pedido.ReasignarCadete(cadete);
        cadete.AgregarPedido(pedido);
    }

    public void GenerarInformeActividad()
    {
        foreach (var cadete in Cadetes)
        {
            decimal jornal = cadete.CalcularJornal();
            Console.WriteLine($"Cadete: {cadete.Nombre}, Jornal: ${jornal}");
        }

        var pedidosPendientes = Pedidos.Count(pedido => pedido.Estado == EstadoPedido.Pendiente);
        Console.WriteLine($"Pedidos Pendientes: {pedidosPendientes}");
    }

    public void GuardarCadeteriaEnCSV(string filePath)
    {
        using (var writer = new StreamWriter(filePath))
        using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
        {
            csv.WriteRecords(this.Clientes);
            csv.WriteRecords(this.Pedidos);
            csv.WriteRecords(this.Cadetes);
        }
    }

    public static Cadeteria LeerCadeteriaDesdeCSV(string filePath)
    {
        var cadeteria = new Cadeteria();
        using (var reader = new StreamReader(filePath))
        using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
        {
            cadeteria.Clientes.AddRange(csv.GetRecords<Cliente>());
            cadeteria.Pedidos.AddRange(csv.GetRecords<Pedido>());
            cadeteria.Cadetes.AddRange(csv.GetRecords<Cadete>());
        }
        return cadeteria;
    }
}