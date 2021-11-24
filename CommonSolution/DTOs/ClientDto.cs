using CommonSolution.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonSolution.DTOs
{
    public abstract class ClientDto : IDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El grupo de cliente es requerido")]
        [DisplayName("Grupo de cliente")]
        public string BillingType { get; set; }

        [StringLength(15, ErrorMessage = "El teléfono no puede superar los 15 caracteres")]
        [Required(ErrorMessage = "El teléfono es requerido")]
        [DisplayName("Teléfono")]
        public string PhoneNumber { get; set; }

        [StringLength(100, ErrorMessage = "La dirección no puede superar los 100 caracteres")]
        [Required(ErrorMessage = "La dirección es requerida")]
        [DisplayName("Dirección")]
        public string Address { get; set; }

        [StringLength(50, ErrorMessage = "El Email no puede superar los 50 caracteres")]
        [Required(ErrorMessage = "El Email es requerida")]
        [EmailAddress(ErrorMessage = "El Email no es válido")]
        [DisplayName("Email")]
        public string EMail { get; set; }
    }
}
