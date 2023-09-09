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
}