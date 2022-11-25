namespace Hotel
{
    //Creamos la clase Config, nos va aservir para poderle pasar la cadena de conexion al servicio que va a llamar el repositorio
    public class Config
    {
        public string CadenaConexion { set; get; }

        public Config(string cadenaConexion)
        {
            CadenaConexion = cadenaConexion;
        }
    }
}
