using Microsoft.AspNetCore.Mvc;
using tp_final.Modelo;
using tp_final.Repository;
using tp_final.ResponseQuery;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace tp_final.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly INorthwindRepository _repository;

        public EmpleadoController(INorthwindRepository repository)
        {
            this._repository = repository;
        }

        /// <summary>
        /// Obtiene todos los empleados.
        /// </summary>
        /// <returns>Lista de empleados.</returns>
        [HttpGet]
        [Route("api/TodosLosEmpleados")]
        public async Task<List<Employee>> GetAll()
        {

            return await _repository.ObtenerTodosLosEmpleados();
        }
        /// <summary>
        /// Obtiene la cantidad total de empleados.
        /// </summary>
        /// <returns>Número de empleados.</returns>
        [HttpGet]
        [Route("api/CantidadEmpleados")]
        public async Task<int> CantidadEmpleado()
        {

            return await _repository.ObtenerCantidadDeEmpleados();
        }

        /// <summary>
        /// Obtiene un empleado por su ID.
        /// </summary>
        /// <param name="idEmpleado">ID del empleado a buscar.</param>
        /// <returns>Empleado encontrado o NotFound.</returns>
        [HttpGet("EmpleadoPorId")]
        public async Task<ActionResult<Employee>> EmpleadoPorId(int idEmpleado)
        {
            var empleado = await _repository.ObtenerEmpleadoPorId(idEmpleado);

            if (empleado == null)
                return NotFound($"No se encontró ningún empleado con el ID {idEmpleado}");

            return Ok(empleado);
        }

        /// <summary>
        /// Obtiene un empleado por su nombre o apellido.
        /// </summary>
        /// <param name="nombreEmpleado">Nombre o apellido a buscar.</param>
        /// <returns>Empleado encontrado o NotFound.</returns>
        [HttpGet("EmpleadoPorNombre")]
        public async Task<ActionResult<Employee>> EmpleadoPorNombre([FromQuery] string nombreEmpleado)
        {
            var empleado = await _repository.ObtenerEmpleadoPorNombre(nombreEmpleado);

            if (empleado == null)
                return NotFound($"No se encontró ningún empleado con el nombre o apellido {nombreEmpleado}");

            return Ok(empleado);
        }

        /// <summary>
        /// Obtiene el ID del empleado según su título.
        /// </summary>
        /// <param name="tituloEmpleado">Título del empleado.</param>
        /// <returns>ID del empleado o NotFound.</returns>
        [HttpGet("IDEmpleadoPorTitulo")]
        public async Task<ActionResult<int>> IDEmpleadoPorTitulo([FromQuery] string tituloEmpleado)
        {
            var id = await _repository.ObtenerIDEmpleadoPorTitulo(tituloEmpleado);

            if (id == 0)
                return NotFound($"No se encontró ningún empleado con el título '{tituloEmpleado}'.");

            return Ok(id);
        }


        /// <summary>
        /// Obtiene un empleado por país.
        /// </summary>
        /// <param name="pais">Nombre del país.</param>
        /// <returns>Empleado encontrado o NotFound.</returns>
        [HttpGet("EmpleadoPorPais")]
        public async Task<ActionResult<Employee>> EmpleadoPorPais([FromQuery] string pais)
        {
            var empleado = await _repository.ObtenerEmpleadoPorPais(pais);

            if (empleado == null)
                return NotFound($"No se encontró ningún empleado con el nombre o apellido {empleado}");

            return Ok(empleado);
        }

        /// <summary>
        /// Obtiene todos los empleados de un país específico.
        /// </summary>
        /// <param name="pais">Nombre del país.</param>
        /// <returns>Lista de empleados o NotFound.</returns>
        [HttpGet("TodosLosEmpleadosPorPais")]
        public async Task<ActionResult<List<Employee>>> TodosLosEmpleadosPorPais([FromQuery] string pais)
        {
            var empleados = await _repository.ObtenerEmpleadosPorPais(pais);

            if (empleados == null || empleados.Count == 0)
                return NotFound($"No se encontraron empleados en el país '{pais}'.");

            return Ok(empleados);
        }


        /// <summary>
        /// Obtiene el empleado más grande (mayor edad o antigüedad según lógica del repositorio).
        /// </summary>
        /// <returns>Empleado más grande.</returns>
        [HttpGet("EmpleadoMasGrande")]
        public async Task<ActionResult<Employee>> EmpleadoMasGrande()
        {
            return await _repository.ObtenerEmpleadoMAsGrande();
        }

        /// <summary>
        /// Obtiene la cantidad de empleados agrupados por título.
        /// </summary>
        /// <returns>Lista de títulos y cantidad de empleados por cada uno.</returns>
        [HttpGet("CantidadEmpleadosPorTitulos")]
        public async Task<ActionResult<List<CantidadEmpleadosResponse>>> GetGroupedByTitle()
        {
            return await _repository.ObtenerEmpleadosPorTituloCroupBy();
        }




    }
}
