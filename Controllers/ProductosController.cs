using ApiRest_Tienda.Datos;
using ApiRest_Tienda.Modelo;
using Microsoft.AspNetCore.Mvc;

namespace ApiRest_Tienda.Controllers
{
    //Referencias a ocupar librerías
    [ApiController]
    //A donde va a apuntar la ruta de consumo de la api
    [Route("api/productos")]
    public class ProductosController:ControllerBase
    {
        //Metodos de funcion de consumo de la api
        /*Tarea asincrona espera a que se espera que cumpla los procesos antes de comenzar con otro
        Task = nombre de la clase
        -- Rescatar los datos que se van a devolver -- 
        Action Result = Para devolver el codigo de la accion 200/300/400
        List = Mostrar los datos
        Mproductos = Se muestra el modelado de los datos productos
        Get() = nombres cualquiera
        */
        [HttpGet]        
        public async Task <ActionResult<List<Mproductos>>> Get() 
        {
            var funcion = new Dproductos();
            var lista = await funcion.Mostrarproductos();
            return lista;
        }
        [HttpPost]
        public async Task Post([FromBody] Mproductos parametros)
        {
            var funcion = new Dproductos();
            await funcion.InsertarProductos(parametros);
        }
        [HttpPut("{id}")]
        public async Task <ActionResult> Put(int id, [FromBody] Mproductos parametros)
        {
            var funcion = new Dproductos();
            parametros.id = id;
            await funcion.EditarProductos(parametros);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var funcion = new Dproductos();
            var parametros = new Mproductos();
            parametros.id = id;
            await funcion.EliminarProductos(parametros);
            return NoContent();
        }
    }
}
