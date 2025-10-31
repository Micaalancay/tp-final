using tp_final.Modelo;
using tp_final.ResponseQuery;
namespace tp_final.Repository
{
    public interface INorthwindRepository
    {
        Task<int> ObtenerCantidadDeEmpleados();
        Task<List<Employee>> ObtenerTodosLosEmpleados();
     
        Task<Employee> ObtenerEmpleadoPorId(int idEmpleado);
        Task<Employee> ObtenerEmpleadoPorNombre(string nombreEmpleado);
        Task<Employee> ObtenerEmpleadoMAsGrande();
        Task<int> ObtenerIDEmpleadoPorTitulo(string tituloEmpleado);
        Task<Employee> ObtenerEmpleadoPorPais(string pais);
        Task<List<Employee>> ObtenerEmpleadosPorTitulos(string tituloEmpleado);
        Task<List<Employee>> ObtenerEmpleadosPorCiudad(string ciudad);
        Task<List<Employee>> ObtenerEmpleadosPorPais(string pais);
        Task<List<CantidadEmpleadosResponse>> ObtenerEmpleadosPorTituloCroupBy();
        Task<List<ProductoCategoriaResponse>> ObtenerProductosyCategorias();
        Task<List<Products>> ObtenerProductosQueContienen(string palabra);
        Task<bool> ModificarNombreEmpleado(int employeeID, string nuevoNombre);
        Task<bool> InsertarEmpleado();

        
    }
}
