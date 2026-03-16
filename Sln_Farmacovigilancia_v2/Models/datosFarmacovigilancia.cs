using System.ComponentModel.DataAnnotations;

namespace Sln_Farmacovigilancia_v2.Models
{
    public class datosFarmacovigilancia
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El Campo es requerido")]
        [Display(Name = "Nombres o Iniciales")]
        public string nombrePaciente { get; set; }
        
        [Required(ErrorMessage = "El Campo es requerido")]
        [Display(Name = "Edad")]
        public int edadPaciente { get; set; }

        [Required(ErrorMessage = "Seleccione un sexo")]
        [Display(Name = "Sexo")]
        public string sexoPaciente { get; set; }

        [Required(ErrorMessage = "El Campo es requerido")]
        [Display(Name = "Número de contacto")]
        public int celularPaciente { get; set; }

        [Required(ErrorMessage = "El Campo es requerido")]
        [Display(Name = "Nombre del producto")]
        public string nombreProducto { get; set; }

        [Required(ErrorMessage = "El Campo es requerido")]
        [Display(Name = "Narración de la reacción adversa")]
        public string? descripcionRAM { get; set; }

        [Required(ErrorMessage = "El Campo es requerido")]
        [Display(Name = "Nombre Notificador")]
        public string? nombreNotificador { get; set; }

        [Required(ErrorMessage = "El Campo es requerido")]
        [Display(Name = "Numero Notificador")]
        public int? celularNotificador { get; set; }

    }
}
