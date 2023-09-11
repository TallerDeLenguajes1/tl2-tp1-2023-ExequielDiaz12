abstract class AccesoADatos{
    public abstract List<Cliente> CargarClientes();
    public abstract void GuardarClientes(List<Cliente> clientes);
}