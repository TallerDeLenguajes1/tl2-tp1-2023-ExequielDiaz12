class Cadeteria
{
    public int Id { get; set;}
    public string Nombre { get; set; }
    public string NumeroTelefono { get; set; }
    public List<Cliente> Clientes { get; set; }
    public List<Pedido> Pedidos { get; set; }
    public List<Cadete> Cadetes { get; set; }

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
}