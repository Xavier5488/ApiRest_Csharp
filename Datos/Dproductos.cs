using ApiRest_Tienda.Modelo; //Llama a las clases de la carpeta modelo
using ApiRest_Tienda.Conexion;//Llama a la conexion a la base de datos
using System.Data.SqlClient;
using System.Data;

namespace ApiRest_Tienda.Datos
{
    public class Dproductos
    {
        //Se crea un constructor para la clase Conexionbd
        Conexionbd cn = new Conexionbd();
        //Se crea una funcion Mostrar productos para consumir los procedimientos almacenados de la base de datos
        public async Task <List<Mproductos>> Mostrarproductos()
        {
            // var lista = es porque se necesita retornar una lista = <List<Mproductos>>
            var lista = new List<Mproductos>();
            //SqlConnection = Crea la conexion para instalar SqlClient y se consume la funcion cadenaSQL
            using(var sql = new SqlConnection(cn.cadenaSQL()))
            {
                //Se llama a los comandos de sqlserver y se llama al procedimiento almacenado
                using(var cmd = new SqlCommand("mostrarProductos",sql))
                {
                    //Se abre la conexion con un await y con OpenAsync
                    await sql.OpenAsync();
                    //Llama al procedimiento almacenado
                    cmd.CommandType = CommandType.StoredProcedure;
                    //Ejecuta el procedimiento
                    using(var item = await cmd.ExecuteReaderAsync()) 
                    {
                        //Trae toda la data de la base de datos
                        while(await item.ReadAsync()) 
                        {
                            //trae el modelado de la clase Mproductos
                            var mproductos = new Mproductos();
                            mproductos.id = (int)item["id"];
                            mproductos.descripcion = (String)item["descripcion"];
                            mproductos.precio = (decimal)item["precio"];
                            lista.Add(mproductos);
                            
                        }
                    }
                }
            }
            return lista;
        }
        //Se crea una funcion para el procedimiento de insertar
        public async Task InsertarProductos(Mproductos parametros)
        {
            using(var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using(var cmd = new SqlCommand("insertarProductos",sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@descripcion",parametros.descripcion);
                    cmd.Parameters.AddWithValue("@precio", parametros.precio);
                    await cmd.ExecuteReaderAsync();
                }
            }
        }
        //Se crea una funcion para el procedimiento de editar
        public async Task EditarProductos(Mproductos parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("editarProductos", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", parametros.id);
                    cmd.Parameters.AddWithValue("@precio", parametros.precio);
                    await cmd.ExecuteReaderAsync();
                }
            }
        }
        //Se crea una funcion para el procedimiento de eliminar
        public async Task EliminarProductos(Mproductos parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("eliminarProductos", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", parametros.id);
                    await cmd.ExecuteReaderAsync();
                }
            }
        }
    }
}
