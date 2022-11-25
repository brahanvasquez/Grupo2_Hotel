using Datos.Interfeces;
using Datos.Repositorios;
using Hotel.Interfaces;
using Modelos;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace Hotel.Servicios
{
    public class LoginServicio : ILoginServicio
    {
        //Metodo para podernos conectar a nuestro repositorio mediante la cadena de conexion
        private readonly Config _configuracion;

        //Llamamos el repositorio
        private ILoginRepositorio loginRepositorio;

        //Creamos el constructor de la clase actual
        public LoginServicio(Config config)
        {
            _configuracion = config;
            loginRepositorio = new LoginRepositorio(config.CadenaConexion);

        }

        public async Task<bool> ValidarUsuario(Login login)
        {
            return await loginRepositorio.ValidarUsuario(login);
        }
    }
}
