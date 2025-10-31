# API REST - Empleados y Productos

Se desea desarrollar una **API REST en ASP.NET Core** que permita consultar información de empleados y productos de la empresa.

---

##  Descripción general

El sistema debe implementar un controlador llamado `EmpleadosController` que exponga distintos endpoints **GET** para consultar la información almacenada en la base de datos mediante un repositorio (`_repository`).

---

## 📋 Requisitos funcionales

### 1. Consultar empleados

- **GET** `api/TodosLosEmpleados` → Devuelve la lista completa de empleados.  
- **GET** `api/CantidadEmpleados` → Devuelve el número total de empleados en la empresa.  
- **GET** `api/EmpleadoPorID?empleadoID=5` → Devuelve la información de un empleado a partir de su ID.  
- **GET** `api/EmpleadosPorNombre?nombreEmpleado=""` → Devuelve el empleado cuyo nombre coincida con el valor ingresado.  
- **GET** `api/IDempleadoPorTitulo?titulo=Manager` → Devuelve el empleado que ocupa el puesto indicado.  
- **GET** `api/EmpleadoPorPais?country=""` → Devuelve un empleado que viva en el país especificado.  
- **GET** `api/TodosLosEmpleadosPorPais?country=""` → Devuelve todos los empleados de un país determinado.  
- **GET** `api/ElEmpleadoMasGrande` → Devuelve el empleado de mayor edad.  

---

### 2. Estadísticas de empleados

- **GET** `api/CantidadEmpleadosPorTitulos` → Devuelve una lista con la cantidad de empleados agrupados por cada título (cargo/puesto).

---

### 3. Productos

- **GET** `api/ObtenerProductosConCategoria` → Devuelve una lista de productos junto con la categoría a la que pertenecen.  
- **GET** `api/ObtenerProductosQueContienen?palabra=""` → Devuelve todos los productos cuyo nombre contenga la palabra indicada.

---

## ⚙️ Notas técnicas

- Todos los métodos deben ser **asíncronos (`async`)** y retornar los tipos adecuados (`List<Employees>`, `Employees`, `int`, etc.).  
- Los parámetros deben recibirse mediante `[FromQuery]`.  
- Se utilizará un **repositorio inyectado en el controlador (`_repository`)** para realizar las consultas.  

---

✍️ **Autor:** Mica Alancay  
🕓 **Versión:** 1.0  
📅 **Última actualización:** Octubre 2025
