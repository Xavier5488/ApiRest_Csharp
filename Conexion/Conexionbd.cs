namespace ApiRest_Tienda.Conexion
{
    public class Conexionbd
    {
        // Se crean las variables
        private string connectionString = string.Empty;
        // Constructor
        public Conexionbd()
        {
            //Ingresar al archivo appsettings.json
            //Conexion a la ConfigurationBuilder para ingresar a un directorio
            var constructor = new ConfigurationBuilder().SetBasePath
                (Directory.GetCurrentDirectory()).AddJsonFile
                ("appsettings.json").Build();
            //Se pasa a la variable connectionString
            //GetSetion = Se accede a las secciones del archivo appsettings.json
            //Value = Acceder al valor ConnectionStrings:conexionmaestra
            connectionString = constructor.GetSection
                ("ConnectionStrings:conexionmaestra").Value;
        }
        //Para que sea reconocido desde cualquier parte del proyecto
        //Se crea una clase para ser llamada 
        public string cadenaSQL()
        {
            return connectionString;
        }
    }
}
