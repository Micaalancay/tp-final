using Microsoft.EntityFrameworkCore;
using tp_final.Contexto;
using tp_final.Modelo;
using tp_final.ResponseQuery;
namespace tp_final.Repository
{
    public class NorthwindRepository : INorthwindRepository
    {
        // Inyección de dependencia del DataContext
        private readonly DataContext _NorthwindDataContext;
        // Constructor que recibe el DataContext
        public NorthwindRepository(DataContext context)
        {
            _NorthwindDataContext = context;
        }
        public async Task<List<Employee>> ObtenerTodosLosEmpleados()
        {
            return await _NorthwindDataContext.Employees.ToListAsync();
        }

        public async Task<int> ObtenerCantidadDeEmpleados()
        {
            return await _NorthwindDataContext.Employees.CountAsync();
        }
        public async Task<Employee> ObtenerEmpleadoPorId(int idEmpleado)
        {
            var resultado = await _NorthwindDataContext.Employees.Where(e => e.EmployeeID == idEmpleado).FirstOrDefaultAsync();
            return resultado;
        }
        public async Task<Employee> ObtenerEmpleadoPorNombre(string nombreEmpleado)
        {
            var nombreLower = nombreEmpleado.ToLower();

            var resultado = await _NorthwindDataContext.Employees
                .FirstOrDefaultAsync(e =>
                    e.FirstName.ToLower().Contains(nombreLower) ||
                    e.LastName.ToLower().Contains(nombreLower));

            return resultado;
        }

        public async Task<int> ObtenerIDEmpleadoPorTitulo(string tituloEmpleado)
        {
            var resultado = from emp in _NorthwindDataContext.Employees
                            where emp.Title == tituloEmpleado
                            select emp.EmployeeID;

            var id = await resultado.FirstOrDefaultAsync(); // devuelve 0 si no hay ninguno
            return id;
        }



        public async Task<Employee> ObtenerEmpleadoPorPais(string pais)
        {
            var resultado = await (from emp in _NorthwindDataContext.Employees
                                   where emp.Country == pais
                                   select new Employee
                                   {

                                       LastName = emp.LastName,
                                       FirstName = emp.FirstName,
                                       Country = emp.Country
                                   }).FirstOrDefaultAsync();

            return resultado;
        }
        public async Task<List<Employee>> ObtenerEmpleadosPorTitulos(string tituloEmpleado)
        {
            var resultado = await (from emp in _NorthwindDataContext.Employees
                                   where emp.Title == tituloEmpleado
                                   orderby emp.FirstName
                                   select emp).ToListAsync();
            return resultado;
        }
        public async Task<Employee> ObtenerEmpleadoMAsGrande()
        {
            var resultado = await (from emp in _NorthwindDataContext.Employees
                                   orderby emp.BirthDate
                                   select emp).FirstOrDefaultAsync();
            return resultado;
        }
        public async Task<List<Employee>> ObtenerEmpleadosPorCiudad(string ciudad)
        {
            var resultado = await (from emp in _NorthwindDataContext.Employees
                                   where emp.City.Contains(ciudad) // Uso de Contains para coincidencia parcial 
                                   orderby emp.LastName
                                   select emp).ToListAsync();
            return resultado;
        }

        public async Task<List<Employee>> ObtenerEmpleadosPorPais(string pais)
        {
            var resultado = await (from emp in _NorthwindDataContext.Employees
                                   where emp.Country.Contains(pais) // coincidencia parcial
                                   orderby emp.LastName
                                   select emp).ToListAsync();

            return resultado;
        }


        public async Task<List<CantidadEmpleadosResponse>> ObtenerEmpleadosPorTituloCroupBy()
        {
            var resultado = await (from emp in _NorthwindDataContext.Employees
                                   group emp by emp.Title into grupoEmpleados
                                   select new CantidadEmpleadosResponse
                                   {
                                       Titulo = grupoEmpleados.Key,
                                       CantidadEmpleados = grupoEmpleados.Count()
                                   }).ToListAsync();
            return resultado;
        }

        public async Task<List<ProductoCategoriaResponse>> ObtenerProductosyCategorias()
        {
            var resultado = await (from prod in _NorthwindDataContext.Products
                                   join cat in _NorthwindDataContext.Categories
                                       on prod.CategoryID equals cat.CategoryID
                                   select new ProductoCategoriaResponse
                                   {
                                       NombreProducto = prod.ProductName,
                                       NombreCategoria = cat.CategoryName
                                   }).ToListAsync();
            return resultado;
        }

        public async Task<List<Products>> ObtenerProductosQueContienen(string palabra)
        {
            return await _NorthwindDataContext.Products
                .Where(p => p.ProductName.ToLower().Contains(palabra))
                .ToListAsync();
        }
        public async Task<bool> ModificarNombreEmpleado(int employeeID, string nuevoNombre)
        {
            bool actualizado = false;
            Employee resultado = await _NorthwindDataContext.Employees.Where(e => e.EmployeeID == employeeID).FirstOrDefaultAsync();
            var result = (resultado != null) ? true : false;
            if (resultado != null)
            {
                resultado.FirstName = nuevoNombre;
                var resulta = _NorthwindDataContext.SaveChanges();
                actualizado = true;
            }

            return actualizado;
        }

      /*  public async Task<bool> EliminarOrdenPorID(int orderID)
        {
            Orders? orden = await _NorthwindDataContext.Orders.Where(o => o.OrderID == orderID).FirstOrDefaultAsync();
            OrderDetails? orderDetails = await _NorthwindDataContext.OrderDetails.Where(od => od.OrderID == orderID).FirstOrDefaultAsync();

            _NorthwindDataContext.OrderDetails.Remove(orderDetails);
            _NorthwindDataContext.Orders.Remove(orden);

            var resulta = _NorthwindDataContext.SaveChanges();
            return true;
        }
      */
        public async Task<bool> InsertarEmpleado()
        {
            Employee nuevoEmpleado = new Employee();
            nuevoEmpleado.Title = "Sales Representative";
            nuevoEmpleado.City = "Buenos Aires";
            nuevoEmpleado.Country = "Argentina";
            nuevoEmpleado.FirstName = "Laura";
            nuevoEmpleado.LastName = "Gonzalez";
            nuevoEmpleado.HireDate = DateTime.Now;
            nuevoEmpleado.BirthDate = new DateTime(1990, 5, 15);

            var newEmpleado = await _NorthwindDataContext.AddAsync(nuevoEmpleado);
            var resultl = _NorthwindDataContext.SaveChanges();

            return (resultl > 0);
        }
    }
}