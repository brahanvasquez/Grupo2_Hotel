using Datos.Interfeces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos;
using MySql.Data.MySqlClient;
using Dapper;

namespace Datos.Repositorios
{
    public class LoginRepositorio : ILoginRepositorio
    {
        //Creamos la valiable Cadena de Conexion
        private string CadenaConexion;


        //Creamos un constructor con el mismo nombre de la clase con el parametro _cadenaConexion que seria la la variable CadenaConexion
        public LoginRepositorio(string _cadenaConexion)
        {
            CadenaConexion = _cadenaConexion;
        }


        //Creamos un metodo que devuelva un objeto de Conexion
        private MySqlConnection Conexion() //No recibe ningun parametros solo devolvera una conexion
        {
            //Abrimos la conexion
            return new MySqlConnection(CadenaConexion);
        }
        public async Task<bool> ValidarUsuario(Login login)
        {//Creamos una variable booleana tipo false para validar los datos del usuario
            bool valido = false;

            try
            {
                //Utilizamos el Using MysqlConecction para establecer una conexion pero la mandamos a llamar del metodo Conexion() 
                using MySqlConnection conexion = Conexion();

                //abrimos la conexion Async
                await conexion.OpenAsync();

                //Cramos el Query del sql donde validamos que el usuario ingrese correctamente el codigo y la clave para poder ingresar
                string sql = "SELECT 1 FROM usuario WHERE Codigo = @Codigo AND Clave = @Clave;";

                //Ejercemos la validacion de la variable bool con el metodo ExcuteSacalarAsync donde mandamos a llamar la conexion sql y los parametros de login siendo estos Usuario y Clave
                valido = await conexion.ExecuteScalarAsync<bool>(sql, new { login.Codigo, login.Clave });
            }
            catch (Exception ex)
            {
            }
            return valido;
        }
    }
}
