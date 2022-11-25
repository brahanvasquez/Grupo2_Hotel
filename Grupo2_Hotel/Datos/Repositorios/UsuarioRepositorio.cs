using Dapper;
using Datos.Interfeces;
using Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private string CadenaConexion;

        public UsuarioRepositorio(string _cadenaConexion)
        {
            CadenaConexion = _cadenaConexion;
        }

        private MySqlConnection Conexion()
        {
            return new MySqlConnection(CadenaConexion);
        }

        public Task<bool> Actualizar(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(string codigo)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Usuario>> GetLista()
        {
            throw new NotImplementedException();
        }

        public async Task<Usuario> GetPorCodigo(string codigo)
        {
            Usuario user = new Usuario();

            try
            {
                //Utilizamos el Using MysqlConecction para establecer una conexion pero la mandamos a llamar del metodo Conexion() 
                using MySqlConnection conexion = Conexion();

                //abrimos la conexion Async
                await conexion.OpenAsync();

                //Cramos el Query del sql donde validamos que el usuario ingrese correctamente el codigo y la clave para poder ingresar
                string sql = "SELECT * FROM usuario WHERE Codigo = @Codigo;";

                //Ejercemos la validacion de la variable bool con el metodo ExcuteSacalarAsync donde mandamos a llamar la conexion sql y los parametros de login siendo estos Usuario y Clave
                user = await conexion.QueryFirstAsync<Usuario>(sql, new { codigo });
            }
            catch (Exception ex)
            {
            }
            return user;
        }

        public Task<bool> Nuevo(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}
