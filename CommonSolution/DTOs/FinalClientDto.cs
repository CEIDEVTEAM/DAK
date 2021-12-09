using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonSolution.DTOs
{
    public class FinalClientDto : ClientDto
    {
        public int IdClient { get; set; }

        [Remote(action: "ExistClientDocNumber", controller: "Client", ErrorMessage = "El documento ya está ingresado")]
        [StringLength(15, ErrorMessage = "El documento no puede superar los 15 caracteres")]
        [Required(ErrorMessage = "El documento es requerido")]
        [DisplayName("Documento")]
        public string DocumentNumber { get; set; }

        [StringLength(20, ErrorMessage = "El nombre no puede superar los 20 caracteres")]
        [Required(ErrorMessage = "El nombre es requerido")]
        [DisplayName("Nombre")]
        public string Name { get; set; }

        [StringLength(20, ErrorMessage = "El apellido no puede superar los 20 caracteres")]
        [Required(ErrorMessage = "El apellido es requerido")]
        [DisplayName("Apellido")]
        public string LastName { get; set; }
    }
}
