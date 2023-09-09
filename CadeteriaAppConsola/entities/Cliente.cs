class Cliente
{
    public int Id;
    public string Nombre { get; set; }
    public string Direccion { get; set; }
    public string NumeroTelefono { get; set; }
    public List<Pedido> Pedidos { get; set; }

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
}