using System.ComponentModel.DataAnnotations;

namespace JwtAutorizacionAutenciacionEnRoles.Core.Dtos
{
    public class RegisterDto
    {
        // Los DTOs son objetos que se utilizan para transportar datos entre diferentes componentes de un sistema, como capas de una aplicacion o servicios web. Generalmente se usan en aplicaciones donde hay una separacion entre las capas de presentacion, logica de negocio y acceso a datos
        // En este caso se usan para transportar datos entre los controladores de la API (donde se reciben las solicitudes HTTP) y los servicios de aplicacion (donde se procesan y se realizan las operacioens de negocio) Los DTOs pueden contener los datos necesarios para las operaciones de autenticacion y autorizacion
        [Required(ErrorMessage = "FirstName is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "UserName is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

    }
}
