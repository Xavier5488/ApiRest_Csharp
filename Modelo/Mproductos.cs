namespace ApiRest_Tienda.Modelo
{
    public class Mproductos
    {
        //Se pasan los campos a utilizar en la base de datos
        // ? = Permite pasar campos vacíos/nulos en descriipcion
        public int id { get; set; }
        public string descripcion { get; set; }
        public decimal precio { get; set; }
    }
}
