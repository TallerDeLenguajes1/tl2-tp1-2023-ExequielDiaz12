class Cadete
{
    public int Id { get; set; }
    public string Direccion { get; set; }
    public string Nombre { get; set; }
    public string NumeroTelefono { get; set; }
    public List<Pedido> Pedidos { get; set; }

    public Cadete(int id, string direccion, string nombre, string numeroTelefono)
    {
        Id = id;
        Direccion = direccion;
        Nombre = nombre;
        NumeroTelefono = numeroTelefono;
        Pedidos = new List<Pedido>();
    }

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
}