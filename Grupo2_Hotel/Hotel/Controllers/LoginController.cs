using Datos.Interfeces;
using Datos.Repositorios;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Modelos;
using System.Security.Claims;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace Hotel.Controllers
{
    public class LoginController : Controller
    {
        //Vamos a mandar a llamar como lectura nada mas Config
        private readonly Config _configuracion;

        private ILoginRepositorio _loginRepositorio;

        //Mandamos a llamar el repositorio
        private IUsuarioRepositorio _usuarioRepositorio;



        public LoginController(Config config)
        {
            _configuracion = config;
            _loginRepositorio = new LoginRepositorio(config.CadenaConexion);
            _usuarioRepositorio = new UsuarioRepositorio(config.CadenaConexion);
        }

        //Pasaremos una Ruta para establecer el inicio de sesion
        [HttpPost("/account/login")]
        public async Task<IActionResult> login(Login login)
        {
            //Declaramos una variable local para el Rol del usuario
            string rol = string.Empty;

            try
            {
                //Creamos un booleano para validar el usuario
                bool usuarioValido = await _loginRepositorio.ValidarUsuario(login);

                if (usuarioValido)
                {
                    //Si es valido mandamos a llamar al usurio mediante el codigo
                    Usuario user = await _usuarioRepositorio.GetPorCodigo(login.Codigo);

                    if (user.EstaActivo)
                    {
                        rol = user.Rol;

                        var clains = new[]
                        {
                            new Claim(ClaimTypes.Name, user.Codigo),
                            new Claim(ClaimTypes.Role, rol)
                        };

                        //Autenticacion mediante Coockie de la web
                        ClaimsIdentity claimsIdentity = new ClaimsIdentity(clains, CookieAuthenticationDefaults.AuthenticationScheme);
                        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                        //Nos va a servir para crear la sesion y el tiempo de duracion de la sesion
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, new AuthenticationProperties { IsPersistent = true, ExpiresUtc = DateTime.UtcNow.AddMinutes(5) });

                    }
                    else
                    {
                        return LocalRedirect("/login/El usuario no esta activo");
                    }

                }
                else
                {
                    return LocalRedirect("/Login/Datos de usuario invalido");
                }
            }
            catch (Exception ex)
            {
            }

            return LocalRedirect("/");
        }


        //Pasamos una ruta para establecer el final de la sesion
        [HttpPost("/account/Logout")]

        public async Task<IActionResult> logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return LocalRedirect("/login");
        }



    }
}

