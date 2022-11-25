using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Interfeces
{
    public interface IUsuarioRepositorio
    {
        //Vamos a tener un metodo asincrono que devuelva un usuario
        Task<Usuario> GetPorCodigo(string codigo);

        //Metodo para agregar un nuevo usuario
        Task<bool> Nuevo(Usuario usuario);

        //Metodo para actualizar un usuario
        Task<bool> Actualizar(Usuario usuario);

        //Metodo para eliminar un usuario
        Task<bool> Eliminar(string codigo);

        //Metodo para desplegar la lista de usuarios
        Task<IEnumerable<Usuario>> GetLista();

    }
}
